WITH BREAKOUT AS (
    SELECT
      M.ID                                                 AS MOVEMENT_ID,
      T.ID                                                 AS TRANSFER_ID,
      ORD.ID                                               AS ORDER_ID,
      'MOV-' || M.ID                                       AS MOVEMENT_NUMBER,
      'X-' || T.ID                                         AS TRANSFER_NUMBER,
      'ORD-' || ORD.ID                                     AS ORDER_NUMBER,
      M.CREATED_DATE - 5 / 24                              AS MOV_CREATED_DATE,
      COALESCE(M.COMPLETED_DATE - 5 / 24, NULL)            AS MOV_COMPLETED_DATE,
      CASE
      WHEN T.STATUS = 0
        THEN 'UNASSIGNED'
      WHEN T.STATUS = 1
        THEN 'ASSIGNED'
      WHEN T.STATUS = 2
        THEN 'COMPLETED'
      WHEN T.STATUS = 3
        THEN 'CANCELED'
      END                                                  AS TRANSFER_STATUS,
      CASE
      WHEN M.STATUS = 1
        THEN 'BUILDING'
      WHEN M.STATUS = 3
        THEN 'COMPLETED'
      WHEN M.STATUS = 4
        THEN 'CANCELED'
      END                                                  AS MOVEMENT_STATUS,
      UT.USERNAME,
      COALESCE(EM.FIRST_NAME || ' ' || EM.LAST_NAME, NULL) AS ASSIGNED_EMPLOYEE,
      S.ID                                                 AS STOCK_ID,
      P.PRODUCT_NUMBER,
      COALESCE(P.EDI_NUMBER, P.PRODUCT_NUMBER)             AS EDI_NUMBER,
      P.DESCRIPTION,
      COALESCE(TO_CHAR(PS.SERIAL_NUMBER), PL.LOT_NUMBER)   AS LOT_SERIAL_NUMBER,
      CASE
      WHEN T.FROM_CONTAINER_TYPE = 1
        THEN B.ZONE || '-' || B.POSITION || '-' || B.SHELF
      END                                                  AS FROM_CONTAINER,
      CASE
      WHEN T.TO_CONTAINER_TYPE = 3 AND PKG.ID IS NOT NULL
        THEN 'PKG-' || PKG.ID
      WHEN T.TO_CONTAINER_TYPE = 3 AND PKG.ID IS NULL
        THEN 'MOV-' || M.ID
      ELSE NULL
      END                                                  AS TO_CONTAINER
    FROM
      SMS_WRITE.MOVEMENT M
      LEFT JOIN SMS_WRITE.TRANSFER T ON T.MOVEMENT_ID = M.ID
      LEFT JOIN SMS_WRITE.PACKAGE PKG ON T.TO_CONTAINER_ID = PKG.ID
      LEFT JOIN SMS_WRITE.ORDER_LINE ORD ON M.ORDER_ID = ORD.ID
      LEFT JOIN SMS_WRITE.USER_TABLE UT ON T.ASSIGNED_USER_ID = UT.ID
      LEFT JOIN SMS_WRITE.EMPLOYEE EM ON UT.ID = EM.USER_ID
      LEFT JOIN SMS_WRITE.BIN B ON T.FROM_CONTAINER_ID = B.ID
      LEFT JOIN SMS_WRITE.STOCK S ON T.FROM_STOCK_ID = S.ID
      LEFT JOIN SMS_WRITE.PRODUCT P ON S.PRODUCT_ID = P.ID
      LEFT JOIN SMS_WRITE.PRODUCT_SERIAL PS ON S.SERIAL_ID = PS.ID
      LEFT JOIN SMS_WRITE.PRODUCT_LOT PL ON S.LOT_ID = PL.ID
    WHERE
      M.FROM_LOCATION_ID = 370
      AND TO_DATE(TO_CHAR(M.CREATED_DATE, 'MM-DD-YYYY'), 'MM-DD-YYYY') BETWEEN TO_DATE(
                                                                                   TO_CHAR(CURRENT_DATE - 5 / 24,
                                                                                           'MM-DD-YYYY'), 'MM-DD-YYYY')
                                                                               - 100 AND TO_DATE(
          TO_CHAR(CURRENT_DATE - 5 / 24, 'MM-DD-YYYY'), 'MM-DD-YYYY')
      AND M.PULL_BY_DATE BETWEEN CURRENT_DATE - FLOOR(7 / 2) AND CURRENT_DATE + CEIL(7 / 2)
      AND M.STATUS = 1
      AND T.TRANSFER_TYPE IN (3, 4, 15, 16, 18, 19)
      AND T.STATUS IN (0, 1, 2)
    GROUP BY
      M.ID, M.STATUS, M.CREATED_DATE, M.COMPLETED_DATE,
      ORD.ID,
      UT.USERNAME,
      EM.FIRST_NAME, EM.LAST_NAME,
      T.STATUS, T.ID, T.TO_CONTAINER_TYPE, T.FROM_CONTAINER_TYPE,
      PKG.ID,
      B.ZONE, B.POSITION, B.SHELF,
      P.PRODUCT_NUMBER, P.EDI_NUMBER, P.DESCRIPTION,
      PL.LOT_NUMBER, PS.SERIAL_NUMBER,
      S.ID
    ORDER BY
      M.ID
)
SELECT DISTINCT
  ASSIGNED_EMPLOYEE                  AS EMPLOYEE,
  COUNT(TRANSFER_NUMBER)
  OVER (
    PARTITION BY ASSIGNED_EMPLOYEE ) AS OUTBOUND_TRNFS,
  COUNT(DISTINCT MOVEMENT_NUMBER)
  OVER (
    PARTITION BY ASSIGNED_EMPLOYEE ) AS OUTBOUND_MVMT
FROM
  BREAKOUT
WHERE
  MOVEMENT_STATUS = 'BUILDING'
  AND TRANSFER_STATUS = 'ASSIGNED'