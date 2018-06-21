using SouthavenFeed.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthavenFeed.FeedTaskManager
{
    public class FeedManager
    {
        private OracleDB oracle;

        private string navigationFileName = "navigation.json";

        public FeedManager(OracleDB oracle)
        {
            this.oracle = oracle;
        }

        public void BuildNavigationQueue(List<string> navigationData)
        {
            Dictionary<string, string> navDict = new Dictionary<string, string>();

            foreach(string s in navigationData)
            {
                navDict.Add(s, s + ".html");
            }

            Jsonifiyer.BuildJSONFile(navDict, "navigation.json");
        }
    }
}
