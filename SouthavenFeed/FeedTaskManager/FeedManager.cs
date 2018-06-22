using SouthavenFeed.DataBase;
using SouthavenFeed.FeedTaskManager.QQueue;
using SouthavenFeed.FeedTaskManager.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;


namespace SouthavenFeed.FeedTaskManager
{
    public class FeedManager
    {
        private OracleDB oracle;

        public FeedManager(OracleDB oracle)
        {
            this.oracle = oracle;
        }

        public void BuildQueryQueue(List<string> names)
        {
            // TODO: implement this: https://stackoverflow.com/questions/363377/how-do-i-run-a-simple-bit-of-code-in-a-new-thread

            Queue<Query> queue = GetSQLQrys(names);

            new Thread(() =>
            {
                Query q = queue.Dequeue();
                ExecuteQuery(q);
                queue.Enqueue(q);
            }
            );
        }

        private void ExecuteQuery(Query q)
        {
            if (q.Get())
            {
                q.FormatResults();
                q.WriteJSONFile();
            }
            else
            {
                MessageBox.Show(
                    string.Format("Error executing query [{0}]", q.Error.ToString()), "Execution Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error
                    );
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

        private Queue<Query> GetSQLQrys(List<string> names)
        {
            Queue<Query> QueryQueue = new Queue<Query>();

            foreach (string name in names)
            {
                try
                {
                    switch (name)
                    {
                        case "productivity":
                            SQLStmt sql1 = SQLStatementLoader.Get(EStatement.COMPLETED_WORK);
                            QueryQueue.Enqueue(new CompletedWorkQuery(oracle, sql1.StmtString, sql1.StmtName + ".json", sql1.StmtName));
                            break;
                        case "otherproductivity":
                            SQLStmt sql2 = SQLStatementLoader.Get(EStatement.COMPLETED_WORK_OTHER);
                            QueryQueue.Enqueue(new CompletedWorkQuery(oracle, sql2.StmtString, sql2.StmtName + ".json", sql2.StmtName));
                            break;
                        case "outboundproductivity":
                            throw new NotImplementedException();
                        case "movements":
                            throw new NotImplementedException();
                        case "transfers":
                            throw new NotImplementedException();
                        case "inboundproductivity":
                            throw new NotImplementedException();
                        case "motto":
                            break;
                        default:
                            throw new Exception("Unknown task name");
                    }
                }
                catch (NotImplementedException nierror)
                {
                    MessageBox.Show(
                        string.Format("This report has not been implemented. [{0}] [{1}]", name, nierror.ToString()),
                        "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error
                        );
                }
            }

            return QueryQueue;
        }
    }
}
