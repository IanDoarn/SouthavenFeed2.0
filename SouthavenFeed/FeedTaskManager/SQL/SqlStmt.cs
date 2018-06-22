using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthavenFeed.FeedTaskManager.SQL
{
    public class SQLStmt
    {
        public string StmtString;
        public string StmtName;

        public SQLStmt(string stmtstring, string stmtname)
        {
            this.StmtString = stmtstring;
            this.StmtName = stmtname;
        }
    }
}
