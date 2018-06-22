using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthavenFeed.FeedTaskManager.QQueue
{
    public class QueryResult
    {
        private DataTable result;
        private Dictionary<int, Dictionary<string, string>> fresults;
        private List<string> headers;

        public List<string> Headers { get { return headers; } }
        public Dictionary<int, Dictionary<string, string>> Results { get { return fresults; } }
        public DataTable RawResults { get { return result; } }

        public QueryResult(DataTable result)
        {
            this.result = result;

            _GetHeaders();
            _ResultsToDictionary();
        }

        private void _GetHeaders()
        {
            headers = new List<string>();

            foreach (DataColumn dc in result.Columns)
                headers.Add(dc.ColumnName);
        }

        private void _ResultsToDictionary()
        {
            int rowNumber = 1;
            fresults = new Dictionary<int, Dictionary<string, string>>();

            foreach(DataRow row in result.Rows)
            {
                Dictionary<string, string> rowData = new Dictionary<string, string>();

                for(int i = 0; i < headers.Count; i++)
                {
                    rowData.Add(headers[i], row[i].ToString());
                }

                fresults.Add(rowNumber, rowData);

                rowNumber++;                     
            }
        }
    }
}
