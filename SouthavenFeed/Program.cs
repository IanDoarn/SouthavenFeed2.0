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
            OracleDB oracle = new OracleDB(LoadOracleConfig());

            try
            {
                TestConnections(oracle);
                connectionAvailable = true;
            }
            catch(Exception ex)
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
                    Application.Run(new FormMain(oracle));

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

        private static OracleConfig LoadOracleConfig()
        {
            return new OracleConfig(
                Properties.Settings.Default.ORACLE_HOST,
                Properties.Settings.Default.ORACLE_SID,
                Properties.Settings.Default.ORACLE_PORT,
                Properties.Settings.Default.ORACLE_USERNAME,
                Properties.Settings.Default.ORACLE_PASSWORD
            );
        }

        private static void TestConnections(OracleDB ora)
        {
            ora.TestConnection();
        }
    }
}
