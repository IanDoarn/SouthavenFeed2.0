using SouthavenFeed.DataBase;
using SouthavenFeed.FeedTaskManager.QQueue;
using SouthavenFeed.FeedTaskManager.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SouthavenFeed.FeedTaskManager
{
    public class FeedManager
    {
        private OracleDB oracle;

        private Queue<Query> QueryQueue;

        public FeedManager(OracleDB oracle)
        {
            this.oracle = oracle;
        }

        public void BuildQueryQueue(List<string> names)
        {

            QueryQueue = new Queue<Query>();

            foreach(SQLStmt sqlstmt in GetSQLStmts(names))
            {

            }
        }

        public bool BuildNavigationQueue(List<string> navigationData)
        {
            /*
             * Navigation file is used by the javascript to determine
             * what page is to be shown next. This means disctionary generated
             * and sent to the Jsonifiyer has to have its values as the next key.
             * 
             * For example:
             *      List = ["1", "2", "3", "4"]
             *      
             *      resulting dictionary will be
             *      
             *      Dict = {
             *          "1": "2", 
             *          "2": "3", 
             *          "3": "4",
             *          "4": "1"
             *          }
             */

            Dictionary<string, string> navDict = new Dictionary<string, string>();

            for (int i = 0; i < navigationData.Count; i++)
            {
                if(i == navigationData.Count - 1)
                    navDict.Add(navigationData[i], navigationData[0] + ".html");
                else
                    navDict.Add(navigationData[i], navigationData[i + 1] + ".html");
            }

            return Jsonifiyer.BuildJSONFile(navDict, "navigation.json");
        }

        private LinkedList<SQLStmt> GetSQLStmts(List<string> names)
        {
            LinkedList<SQLStmt> statments = new LinkedList<SQLStmt>();

            foreach (string name in names)
            {
                switch (name)
                {
                    case "productivity":
                        statments.AddLast(SQLStatementLoader.Get(EStatement.COMPLETED_WORK));
                        break;
                    case "otherproductivity":
                        statments.AddLast(SQLStatementLoader.Get(EStatement.COMPLETED_WORK_OTHER));
                        break;
                    case "outboundproductivity":
                        statments.AddLast(SQLStatementLoader.Get(EStatement.ASSIGNED_OUTBOUND_TRANSFERS));
                        statments.AddLast(SQLStatementLoader.Get(EStatement.COMPLETED_OUTBOUND_TRANSFERS));
                        break;
                    case "movements":
                        statments.AddLast(SQLStatementLoader.Get(EStatement.CURRENT_MOVEMENTS));
                        statments.AddLast(SQLStatementLoader.Get(EStatement.COMPLETED_MOVEMENTS));
                        break;
                    case "transfers":
                        statments.AddLast(SQLStatementLoader.Get(EStatement.CURRENT_TRANSFERS));
                        break;
                    case "inboundproductivity":
                        statments.AddLast(SQLStatementLoader.Get(EStatement.COMPLETED_WORK));
                        statments.AddLast(SQLStatementLoader.Get(EStatement.CURRENT_TRANSFERS));
                        break;
                    case "motto":
                        break;
                    default:
                        throw new Exception("Unknown task name");
                }
            }

            return statments;
        }
    }
}
