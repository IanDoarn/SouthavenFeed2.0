using SouthavenFeed.DataBase;
using SouthavenFeed.Forms;
using SouthavenFeed.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SouthavenFeed
{
    static class Program
    {
        private static bool connectionAvailable = false;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if(Properties.Settings.Default.DEV_MODE)
            {
                /// <summary>       
                /// Dev mode is designed to isgnore oracle and launch without
                /// databse connections.
                /// Dev mode will instead use dummy data from json files in the 
                /// ExampleData Folder
                /// </summary>

                //OracleDB oracle = new OracleDB(LoadOracleConfig("log78gist"));

                //oracle.OpenConnection();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain(ora: null, fManager: new FeedTaskManager.FeedManager(null)));
            }
            else
            {
                /// <summary>
                /// Regular application mode.
                /// </summary>

                OracleDB oracle = new OracleDB(LoadOracleConfig());

                try
                {

                    TestConnections(oracle);
                    connectionAvailable = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Unable to connect to Oracle. [{}]", ex.ToString()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    connectionAvailable = false;
                }
                finally
                {
                    if (connectionAvailable)
                    {
                        oracle.OpenConnection();

                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new FormMain(oracle, new FeedTaskManager.FeedManager(oracle)));

                        oracle.CloseConnection();
                    }
                    else
                    {
                        MessageBox.Show(
                            ErrorMessages.Message(EMsgCodes.UNABLE_TO_CONNECT_TO_DATABASE),
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error
                        );
                    }
                }

            }
        }

        /// <summary>
        /// Load oracle config object
        /// </summary>
        /// <returns>OracleConfig</returns>
        private static OracleConfig LoadOracleConfig()
        {
            string password = Microsoft.VisualBasic.Interaction.InputBox("Oracle Password", "Enter oracle password", "", 0, 0);

            return new OracleConfig(
                Properties.Settings.Default.ORACLE_HOST,
                Properties.Settings.Default.ORACLE_SID,
                Properties.Settings.Default.ORACLE_PORT,
                Properties.Settings.Default.ORACLE_USERNAME,
                password
            );
        }

        /// <summary>
        /// Load oracle config object,
        /// allows dev to pass password without prompt
        /// </summary>
        /// <returns>OracleConfig</returns>
        private static OracleConfig LoadOracleConfig(string password)
        {

            return new OracleConfig(
                Properties.Settings.Default.ORACLE_HOST,
                Properties.Settings.Default.ORACLE_SID,
                Properties.Settings.Default.ORACLE_PORT,
                Properties.Settings.Default.ORACLE_USERNAME,
                password
            );
        }

        private static void TestConnections(OracleDB ora)
        {
            ora.TestConnection();
        }
    }
}
