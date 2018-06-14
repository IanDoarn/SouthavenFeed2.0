﻿SELECT DISTINCT
  'X-' || T.ID                                         AS TRANSFER_NUMBER,
  CASE
  WHEN T.STATUS = 0
    THEN 'UNASSIGNED'
  WHEN T.STATUS = 1
    THEN 'ASSIGNED'
  END                                                  AS TRANSFER_STATUS,
  U.USERNAME,
  CASE
  WHEN T.STATUS = 1
    THEN EM.FIRST_NAME || ' ' || EM.LAST_NAME
  ELSE 'NONE'
  END                                                  AS ASSIGNED_USER,
  P.PRODUCT_NUMBER,
  PL.LOT_NUMBER,
  B.ZONE || '-' || B.POSITION || '-' || B.SHELF        AS FROM_BIN,
  P2.PRODUCT_NUMBER                                    AS TO_KIT_NUMBER,
  PS.SERIAL_NUMBER                                     AS TO_KIT_SERIAL_NUMBER,
  B2.ZONE || '-' || B2.POSITION || '-' || B2.SHELF     AS TO_BIN,
  S2.HOLD_REASON                                       AS KIT_HOLD_REASON_CODE,
  CASE
  WHEN S2.HOLD_REASON = 1
    THEN 'CORPORATE_HOLD'
  WHEN S2.HOLD_REASON = 2
    THEN 'AWAITING_QC_CHECK'
  WHEN S2.HOLD_REASON = 3
    THEN 'INVENTORY_STAGING'
  WHEN S2.HOLD_REASON = 4
    THEN 'MISSING_ITEMS'
  WHEN S2.HOLD_REASON = 5
    THEN 'PICK_SHORTAGE'
  WHEN S2.HOLD_REASON = 6
    THEN 'CYCLE_COUNT_IN_PROGRESS'
  WHEN S2.HOLD_REASON = 7
    THEN 'NOT_FOUND_DURING_CYCLE_COUNT'
  END                                                  AS KIT_HOLD_REASON,
  S2.HOLD_NOTE                                         AS KIT_HOLD_NOTE
FROM
  SMS_WRITE.TRANSFER T
  LEFT JOIN SMS_WRITE.STOCK S ON S.ID = T.FROM_STOCK_ID
  LEFT JOIN SMS_WRITE.PRODUCT P ON S.PRODUCT_ID = P.ID
  LEFT JOIN SMS_WRITE.PRODUCT_LOT PL ON S.LOT_ID = PL.ID
  LEFT JOIN SMS_WRITE.BIN B ON T.FROM_CONTAINER_ID = B.ID AND T.FROM_CONTAINER_TYPE = 1
  LEFT JOIN SMS_WRITE.PRODUCT P2 ON T.TO_KIT_PRODUCT_ID = P2.ID
  LEFT JOIN SMS_WRITE.PRODUCT_SERIAL PS ON T.TO_KIT_SERIAL_ID = PS.ID
  LEFT JOIN SMS_WRITE.STOCK S2 ON T.TO_KIT_PRODUCT_ID = S2.PRODUCT_ID
  LEFT JOIN SMS_WRITE.BIN B2 ON T.TO_KIT_CONTAINER_ID = B2.ID
  LEFT JOIN SMS_WRITE.USER_TABLE U ON U.ID = T.ASSIGNED_USER_ID
  LEFT JOIN SMS_WRITE.CORPORATE_USER E ON E.USER_ID = U.ID
  LEFT JOIN SMS_WRITE.EMPLOYEE EM ON EM.USER_ID = U.ID
WHERE
  S.LOCATION_ID = 370
  AND T.LOCATION_ID = 370
  AND T.DISTRIBUTOR_ID = 168
  AND T.LOCATION_TYPE = 1
  AND T.TRANSFER_TYPE = 1
  AND T.STATUS IN (0, 1)
  AND T.TRANSFER_TYPE = 1
  AND B.DISTRIBUTOR_ID = 168
  AND B2.DISTRIBUTOR_ID = 168
  AND B.LOCATION_ID = 370
  AND B.LOCATION_ID = 370
  AND S2.LOCATION_ID = 370
ORDER BY
  P.PRODUCT_NUMBER