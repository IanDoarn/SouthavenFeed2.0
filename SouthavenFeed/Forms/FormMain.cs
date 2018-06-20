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

            generateListViewItems();
        }

        private void generateListViewItems()
        {
            // ====================
            // Referenced from here
            // http://denricdenise.info/2016/01/metrolistview-is-coming-in-metroframework/
            // ====================
            metroListViewFeedOrganizer.BeginUpdate();
            metroListViewFeedOrganizer.Items.Clear();
            metroListViewFeedOrganizer.View = View.Details;

            metroListViewFeedOrganizer.Columns.Add("Col1");
            metroListViewFeedOrganizer.Columns.Add("Col2");
            metroListViewFeedOrganizer.Columns.Add("Col2");
            metroListViewFeedOrganizer.CheckBoxes = true;

            for (int i = 0; i < 1000; i++)
            {
                ListViewItem lvi;
                lvi = new ListViewItem(new string[] { "Aaaaa Sample" + i, "Bbbbb" + i, "Cccccc" + i });
                metroListViewFeedOrganizer.Items.Add(lvi);
                metroListViewFeedOrganizer.Items[0].Checked = true;
            }

            metroListViewFeedOrganizer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            metroListViewFeedOrganizer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            metroListViewFeedOrganizer.EndUpdate();
            metroListViewFeedOrganizer.AllowSorting = true;
        }
    }
}
