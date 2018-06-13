using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using SouthavenFeed.DataBase;
using SouthavenFeed.Forms;
using SouthavenFeed.Exceptions;


namespace SouthavenFeed.Forms
{
    public partial class FormMain : MetroForm
    {
        private OracleDB oracle;
        private StringCollection defaultNavigationOrder = Properties.Settings.Default.DEFAULT_NAVIGATION_ORDER;

        public FormMain(OracleDB ora)
        {
            this.oracle = ora;

            InitializeComponent();
        }

        private void generateListViewItems()
        {
            // ====================
            // Referenced from here
            // http://denricdenise.info/2016/01/metrolistview-is-coming-in-metroframework/
            // ====================
            this.metroListViewFeedOrganizer.BeginUpdate();
            this.metroListViewFeedOrganizer.Items.Clear();
            this.metroListViewFeedOrganizer.View = View.Details;

            this.metroListViewFeedOrganizer.Columns
        }
    }
}
