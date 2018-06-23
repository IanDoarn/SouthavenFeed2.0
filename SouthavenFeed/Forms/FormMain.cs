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
using SouthavenFeed.FeedTaskManager;

namespace SouthavenFeed.Forms
{
    public partial class FormMain : MetroForm
    {
        private OracleDB oracle;

        private StringCollection defaultNavigationOrder = Properties.Settings.Default.DEFAULT_NAVIGATION_ORDER;
        private StringCollection feedPages = Properties.Settings.Default.FEED_PAGES;
        private List<ListViewItem> queuedItems = new List<ListViewItem>();

        private FeedManager fManager;

        public FormMain(FeedManager fManager, OracleDB ora)
        {
            this.oracle = ora;
            this.fManager = fManager;

            InitializeComponent();

            metroComboBoxPresetQueues.SelectedIndex = 0;

            generateListViewItems();
        }

        private string formatListName(string name)
        {
            string[] temp = name.ToLower().Split(' ');
            return string.Join("", temp);
        }

        private void generateListViewItems()
        {
            // ====================
            // Referenced from here
            // http://denricdenise.info/2016/01/metrolistview-is-coming-in-metroframework/
            // ====================
            metroListViewFeedOrganizer.BeginUpdate();

            metroListViewFeedQueue.BeginUpdate();

            metroListViewFeedOrganizer.AllowDrop = true;
            metroListViewFeedOrganizer.Items.Clear();
            metroListViewFeedOrganizer.View = View.Details;

            metroListViewFeedQueue.Items.Clear();
            metroListViewFeedQueue.View = View.Details;

            metroListViewFeedOrganizer.Columns.Add("Page Name");
            metroListViewFeedOrganizer.CheckBoxes = true;

            metroListViewFeedQueue.Columns.Add("Page Name");

            List<string> queueItems = new List<string>();

            foreach (String s in defaultNavigationOrder)
            {
                ListViewItem item = new ListViewItem(s);
                item.Checked = true;

                metroListViewFeedOrganizer.Items.Add(item);            
                metroListViewFeedQueue.Items.Add(new ListViewItem(s));


                queuedItems.Add(item);

                queueItems.Add(item.Text);

            }

            fManager.BuildNavigationQueue(queueItems);

            foreach (String s in feedPages)
            {
                metroListViewFeedOrganizer.Items.Add(new ListViewItem(s));
            }

            metroListViewFeedOrganizer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            metroListViewFeedOrganizer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            metroListViewFeedQueue.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            metroListViewFeedQueue.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            metroListViewFeedOrganizer.EndUpdate();
            metroListViewFeedQueue.EndUpdate();
        }

        private void selectQueueItemsByName(string[] names)
        {
            List<string> queueItems = new List<string>();

            metroListViewFeedQueue.BeginUpdate();

            foreach(string s in names)
            {
                foreach (ListViewItem lvi in metroListViewFeedOrganizer.Items)
                {
                    if(lvi.Text.Equals(s))
                    {
                        lvi.Checked = true;

                        ListViewItem l = (ListViewItem)lvi.Clone();

                        metroListViewFeedQueue.Items.Add(l);

                        queuedItems.Add(l);

                        queueItems.Add(lvi.Text);
                    }
                }
            }

            metroListViewFeedQueue.EndUpdate();

            fManager.BuildNavigationQueue(queueItems);
        }

        private void metroButtonAddItemsToQueue_Click(object sender, EventArgs e)
        {
            metroListViewFeedQueue.Items.Clear();
            queuedItems.Clear();

            List<string> queueItems = new List<string>();

            metroListViewFeedQueue.BeginUpdate();

            foreach(ListViewItem lvi in metroListViewFeedOrganizer.Items)
            {
                if(lvi.Checked)
                {                
                    ListViewItem l = (ListViewItem)lvi.Clone();

                    metroListViewFeedQueue.Items.Add(l);

                    queuedItems.Add(l);

                    queueItems.Add(lvi.Text);
                }
            }

            metroListViewFeedQueue.EndUpdate();

            fManager.BuildNavigationQueue(queueItems);
        }

        private void metroButtonClearQueue_Click(object sender, EventArgs e)
        {
            metroListViewFeedQueue.Items.Clear();
            queuedItems.Clear();

            foreach (ListViewItem lvi in metroListViewFeedOrganizer.Items)
            {
                if (lvi.Checked)
                    lvi.Checked = false;            
            }
        }

        private void metroButtonQueueAll_Click(object sender, EventArgs e)
        {
            metroListViewFeedQueue.Items.Clear();
            queuedItems.Clear();

            List<string> queueItems = new List<string>();

            metroListViewFeedQueue.BeginUpdate();

            foreach (ListViewItem lvi in metroListViewFeedOrganizer.Items)
            {
                if (!lvi.Checked)
                    lvi.Checked = true;

                ListViewItem l = (ListViewItem)lvi.Clone();

                metroListViewFeedQueue.Items.Add(l);

                queuedItems.Add(l);

                queueItems.Add(lvi.Text);
            }

            metroListViewFeedQueue.EndUpdate();

            fManager.BuildNavigationQueue(queueItems);

        }

        private void metroButtonRun_Click(object sender, EventArgs e)
        {
            List<string> queuedItemsNames = new List<string>();

            foreach(ListViewItem lvi in queuedItems)
            {
                queuedItemsNames.Add(formatListName(lvi.Text));
            }

            fManager.BuildQueryQueue(queuedItemsNames);
            fManager.Start();
        }

        private void metroButtonStop_Click(object sender, EventArgs e)
        {
            if (fManager.Status())
                fManager.Stop();
        }

        private void metroComboBoxPresetQueues_SelectedIndexChanged(object sender, EventArgs e)
        {
            metroListViewFeedQueue.Items.Clear();
            queuedItems.Clear();

            foreach (ListViewItem lvi in metroListViewFeedOrganizer.Items)
            {
                if (lvi.Checked)
                    lvi.Checked = false;
            }

            switch (metroComboBoxPresetQueues.SelectedItem.ToString())
            {
                case "General":
                    selectQueueItemsByName(new string[] {"Productivity", "Other Productivity", "Motto" });
                    break;
                case "Inbound":
                    selectQueueItemsByName(new string[] { "Inbound Productivity", "Transfers", "Motto" });
                    break;
                case "Outbound":
                    selectQueueItemsByName(new string[] { "Outbound Productivity", "Movements", "Motto" });
                    break;
                default:
                    break;
            }
        }
    }
}
