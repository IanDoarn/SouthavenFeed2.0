using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SouthavenFeed.DataBase;

namespace SouthavenFeed.QQueue
{

    class CompletedWorkQuery : Query
    {
        private sealed class Employee
        {
            public string EMPLOYEE { get; set; }
            public int KIT_INBOUND_TRANSFER { get; set; }
            public int PIECE_INBOUND_TRANSFER { get; set; }
            public int INSTRUMENT_INBOUND_TRANSFER { get; set; }
            public int PUTAWAY_TRANSFER { get; set; }
            public int KIT_BUILD_TRANSFER { get; set; }
            public int OUTBOUND_TRANSFER { get; set; }
            public int OTHER_TRANSFER { get; set; }
            public double TOTAL_PRODUCTIVITY { get; set; }

            public Employee(
                string EMPLOYEE,
                int KIT_INBOUND_TRANSFER, int PIECE_INBOUND_TRANSFER,
                int INSTRUMENT_INBOUND_TRANSFER, int PUTAWAY_TRANSFER,
                int KIT_BUILD_TRANSFER, int OUTBOUND_TRANSFER,
                int OTHER_TRANSFER, double TOTAL_PRODUCTIVITY
                )
            {
                this.EMPLOYEE = EMPLOYEE;
                this.KIT_INBOUND_TRANSFER = KIT_INBOUND_TRANSFER;
                this.PIECE_INBOUND_TRANSFER = PIECE_INBOUND_TRANSFER;
                this.INSTRUMENT_INBOUND_TRANSFER = INSTRUMENT_INBOUND_TRANSFER;
                this.PUTAWAY_TRANSFER = PUTAWAY_TRANSFER;
                this.KIT_BUILD_TRANSFER = KIT_BUILD_TRANSFER;
                this.OUTBOUND_TRANSFER = OUTBOUND_TRANSFER;
                this.OTHER_TRANSFER = OTHER_TRANSFER;
                this.TOTAL_PRODUCTIVITY = TOTAL_PRODUCTIVITY;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat(@"EMPLOYEE: {0} KIT_INBOUND_TRANSFER: {1} PIECE_INBOUND_TRANSFER: {2} INSTRUMENT_INBOUND_TRANSFER: {3} PUTAWAY_TRANSFER: {4} KIT_BUILD_TRANSFER: {5} OUTBOUND_TRANSFER: {6} OTHER_TRANSFER: {7} TOTAL_PRODUCTIVITY: {8}",
                        this.EMPLOYEE,
                        this.KIT_INBOUND_TRANSFER,
                        this.PIECE_INBOUND_TRANSFER,
                        this.INSTRUMENT_INBOUND_TRANSFER,
                        this.PUTAWAY_TRANSFER,
                        this.KIT_BUILD_TRANSFER,
                        this.OUTBOUND_TRANSFER,
                        this.OTHER_TRANSFER,
                        this.TOTAL_PRODUCTIVITY);
                return sb.ToString();
            }
        }

        private DataTable results;
        private OracleDB connection;
        private Exception error;
        private List<Employee> employees;

        private string queryString;
        private string fileName;
        private string queryName;

        public override string FileName { get { return fileName; } }
        public override string QueryName { get { return queryName; } }

        public Exception Error { get { return error; } }

        public CompletedWorkQuery(OracleDB connection, string queryString, string fileName, string queryName)
        {
            this.connection = connection;
            this.queryString = queryString;
            this.fileName = fileName;
            this.queryName = queryName;
        }

        public override bool Get()
        {
            try
            {
                results = connection.execute(queryString);
                return true;
            }
            catch(Exception er)
            {
                this.error = er;
                return false;
            }
        }

        public override void FormatResults()
        {
            employees = new List<Employee>();
            
            foreach(DataRow row in results.Rows)
            {
                employees.Add(new Employee(
                    row["EMPLOYEE"].ToString(),
                    Convert.ToInt32(row["KIT_INBOUND_TRANSFER"].ToString()),
                    Convert.ToInt32(row["PIECE_INBOUND_TRANSFER"].ToString()),
                    Convert.ToInt32(row["INSTRUMENT_INBOUND_TRANSFER"].ToString()),
                    Convert.ToInt32(row["PUTAWAY_TRANSFER"].ToString()),
                    Convert.ToInt32(row["KIT_BUILD_TRANSFER"].ToString()),
                    Convert.ToInt32(row["OUTBOUND_TRANSFER"].ToString()),
                    Convert.ToInt32(row["OTHER_TRANSFER"].ToString()),
                    Convert.ToDouble(row["TOTAL_PRODUCTIVITY"].ToString())
                    ));
            }
        }

        public override void WriteJSONFile()
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(employees, Formatting.Indented));
        }
    }
}
