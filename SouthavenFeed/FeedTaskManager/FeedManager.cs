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

        public FeedManager(OracleDB oracle)
        {
            this.oracle = oracle;
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
    }
}
