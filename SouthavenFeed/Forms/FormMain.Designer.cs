namespace SouthavenFeed.Forms
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainInnerPanel = new MetroFramework.Controls.MetroPanel();
            this.tableLayoutPanelInnerPanel = new System.Windows.Forms.TableLayoutPanel();
            this.metroPanelMainRight = new MetroFramework.Controls.MetroPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.metroListViewFeedQueue = new MetroFramework.Controls.MetroListView();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroPanelMainLeft = new MetroFramework.Controls.MetroPanel();
            this.tableLayoutPanelFeedOrganizer = new System.Windows.Forms.TableLayoutPanel();
            this.metroPanelFeedOrganizer = new MetroFramework.Controls.MetroPanel();
            this.metroPanelFeedOrganizerControls = new MetroFramework.Controls.MetroPanel();
            this.metroButtonClearQueue = new MetroFramework.Controls.MetroButton();
            this.metroButtonAddItemsToQueue = new MetroFramework.Controls.MetroButton();
            this.metroListViewFeedOrganizer = new SouthavenFeed.Forms.FormExtras.ListViewWithReordering();
            this.metroToggleQueueAll = new MetroFramework.Controls.MetroToggle();
            this.mainInnerPanel.SuspendLayout();
            this.tableLayoutPanelInnerPanel.SuspendLayout();
            this.metroPanelMainRight.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.metroPanelMainLeft.SuspendLayout();
            this.tableLayoutPanelFeedOrganizer.SuspendLayout();
            this.metroPanelFeedOrganizer.SuspendLayout();
            this.metroPanelFeedOrganizerControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainInnerPanel
            // 
            this.mainInnerPanel.Controls.Add(this.tableLayoutPanelInnerPanel);
            this.mainInnerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainInnerPanel.HorizontalScrollbarBarColor = true;
            this.mainInnerPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.mainInnerPanel.HorizontalScrollbarSize = 10;
            this.mainInnerPanel.Location = new System.Drawing.Point(20, 60);
            this.mainInnerPanel.Name = "mainInnerPanel";
            this.mainInnerPanel.Size = new System.Drawing.Size(578, 315);
            this.mainInnerPanel.TabIndex = 0;
            this.mainInnerPanel.VerticalScrollbarBarColor = true;
            this.mainInnerPanel.VerticalScrollbarHighlightOnWheel = false;
            this.mainInnerPanel.VerticalScrollbarSize = 10;
            // 
            // tableLayoutPanelInnerPanel
            // 
            this.tableLayoutPanelInnerPanel.ColumnCount = 2;
            this.tableLayoutPanelInnerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelInnerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelInnerPanel.Controls.Add(this.metroPanelMainRight, 1, 0);
            this.tableLayoutPanelInnerPanel.Controls.Add(this.metroPanelMainLeft, 0, 0);
            this.tableLayoutPanelInnerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelInnerPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelInnerPanel.Name = "tableLayoutPanelInnerPanel";
            this.tableLayoutPanelInnerPanel.RowCount = 1;
            this.tableLayoutPanelInnerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelInnerPanel.Size = new System.Drawing.Size(578, 315);
            this.tableLayoutPanelInnerPanel.TabIndex = 2;
            // 
            // metroPanelMainRight
            // 
            this.metroPanelMainRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanelMainRight.Controls.Add(this.tableLayoutPanel1);
            this.metroPanelMainRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanelMainRight.HorizontalScrollbarBarColor = true;
            this.metroPanelMainRight.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanelMainRight.HorizontalScrollbarSize = 10;
            this.metroPanelMainRight.Location = new System.Drawing.Point(292, 3);
            this.metroPanelMainRight.Name = "metroPanelMainRight";
            this.metroPanelMainRight.Size = new System.Drawing.Size(283, 309);
            this.metroPanelMainRight.TabIndex = 0;
            this.metroPanelMainRight.VerticalScrollbarBarColor = true;
            this.metroPanelMainRight.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanelMainRight.VerticalScrollbarSize = 10;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.metroListViewFeedQueue, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.81759F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.18241F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(281, 307);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // metroListViewFeedQueue
            // 
            this.metroListViewFeedQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroListViewFeedQueue.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroListViewFeedQueue.FullRowSelect = true;
            this.metroListViewFeedQueue.Location = new System.Drawing.Point(3, 27);
            this.metroListViewFeedQueue.Name = "metroListViewFeedQueue";
            this.metroListViewFeedQueue.OwnerDraw = true;
            this.metroListViewFeedQueue.Size = new System.Drawing.Size(275, 277);
            this.metroListViewFeedQueue.TabIndex = 2;
            this.metroListViewFeedQueue.UseCompatibleStateImageBehavior = false;
            this.metroListViewFeedQueue.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(3, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(81, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Feed Queue";
            // 
            // metroPanelMainLeft
            // 
            this.metroPanelMainLeft.Controls.Add(this.tableLayoutPanelFeedOrganizer);
            this.metroPanelMainLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanelMainLeft.HorizontalScrollbarBarColor = true;
            this.metroPanelMainLeft.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanelMainLeft.HorizontalScrollbarSize = 10;
            this.metroPanelMainLeft.Location = new System.Drawing.Point(3, 3);
            this.metroPanelMainLeft.Name = "metroPanelMainLeft";
            this.metroPanelMainLeft.Size = new System.Drawing.Size(283, 309);
            this.metroPanelMainLeft.TabIndex = 1;
            this.metroPanelMainLeft.VerticalScrollbarBarColor = true;
            this.metroPanelMainLeft.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanelMainLeft.VerticalScrollbarSize = 10;
            // 
            // tableLayoutPanelFeedOrganizer
            // 
            this.tableLayoutPanelFeedOrganizer.ColumnCount = 1;
            this.tableLayoutPanelFeedOrganizer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelFeedOrganizer.Controls.Add(this.metroPanelFeedOrganizer, 0, 1);
            this.tableLayoutPanelFeedOrganizer.Controls.Add(this.metroPanelFeedOrganizerControls, 0, 0);
            this.tableLayoutPanelFeedOrganizer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFeedOrganizer.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelFeedOrganizer.Name = "tableLayoutPanelFeedOrganizer";
            this.tableLayoutPanelFeedOrganizer.RowCount = 2;
            this.tableLayoutPanelFeedOrganizer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.01294F));
            this.tableLayoutPanelFeedOrganizer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.98706F));
            this.tableLayoutPanelFeedOrganizer.Size = new System.Drawing.Size(283, 309);
            this.tableLayoutPanelFeedOrganizer.TabIndex = 2;
            // 
            // metroPanelFeedOrganizer
            // 
            this.metroPanelFeedOrganizer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanelFeedOrganizer.Controls.Add(this.metroListViewFeedOrganizer);
            this.metroPanelFeedOrganizer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanelFeedOrganizer.HorizontalScrollbarBarColor = true;
            this.metroPanelFeedOrganizer.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanelFeedOrganizer.HorizontalScrollbarSize = 10;
            this.metroPanelFeedOrganizer.Location = new System.Drawing.Point(3, 138);
            this.metroPanelFeedOrganizer.Name = "metroPanelFeedOrganizer";
            this.metroPanelFeedOrganizer.Size = new System.Drawing.Size(277, 168);
            this.metroPanelFeedOrganizer.TabIndex = 0;
            this.metroPanelFeedOrganizer.VerticalScrollbarBarColor = true;
            this.metroPanelFeedOrganizer.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanelFeedOrganizer.VerticalScrollbarSize = 10;
            // 
            // metroPanelFeedOrganizerControls
            // 
            this.metroPanelFeedOrganizerControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanelFeedOrganizerControls.Controls.Add(this.metroToggleQueueAll);
            this.metroPanelFeedOrganizerControls.Controls.Add(this.metroButtonClearQueue);
            this.metroPanelFeedOrganizerControls.Controls.Add(this.metroButtonAddItemsToQueue);
            this.metroPanelFeedOrganizerControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanelFeedOrganizerControls.HorizontalScrollbarBarColor = true;
            this.metroPanelFeedOrganizerControls.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanelFeedOrganizerControls.HorizontalScrollbarSize = 10;
            this.metroPanelFeedOrganizerControls.Location = new System.Drawing.Point(3, 3);
            this.metroPanelFeedOrganizerControls.Name = "metroPanelFeedOrganizerControls";
            this.metroPanelFeedOrganizerControls.Size = new System.Drawing.Size(277, 129);
            this.metroPanelFeedOrganizerControls.TabIndex = 1;
            this.metroPanelFeedOrganizerControls.VerticalScrollbarBarColor = true;
            this.metroPanelFeedOrganizerControls.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanelFeedOrganizerControls.VerticalScrollbarSize = 10;
            // 
            // metroButtonClearQueue
            // 
            this.metroButtonClearQueue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButtonClearQueue.Location = new System.Drawing.Point(84, 3);
            this.metroButtonClearQueue.Name = "metroButtonClearQueue";
            this.metroButtonClearQueue.Size = new System.Drawing.Size(75, 23);
            this.metroButtonClearQueue.TabIndex = 3;
            this.metroButtonClearQueue.Text = "Clear Queue";
            this.metroButtonClearQueue.UseSelectable = true;
            this.metroButtonClearQueue.Click += new System.EventHandler(this.metroButtonClearQueue_Click);
            // 
            // metroButtonAddItemsToQueue
            // 
            this.metroButtonAddItemsToQueue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButtonAddItemsToQueue.Location = new System.Drawing.Point(3, 3);
            this.metroButtonAddItemsToQueue.Name = "metroButtonAddItemsToQueue";
            this.metroButtonAddItemsToQueue.Size = new System.Drawing.Size(75, 23);
            this.metroButtonAddItemsToQueue.TabIndex = 2;
            this.metroButtonAddItemsToQueue.Text = "Queue Items";
            this.metroButtonAddItemsToQueue.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButtonAddItemsToQueue.UseSelectable = true;
            this.metroButtonAddItemsToQueue.Click += new System.EventHandler(this.metroButtonAddItemsToQueue_Click);
            // 
            // metroListViewFeedOrganizer
            // 
            this.metroListViewFeedOrganizer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroListViewFeedOrganizer.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroListViewFeedOrganizer.FullRowSelect = true;
            this.metroListViewFeedOrganizer.Location = new System.Drawing.Point(0, 0);
            this.metroListViewFeedOrganizer.Name = "metroListViewFeedOrganizer";
            this.metroListViewFeedOrganizer.OwnerDraw = true;
            this.metroListViewFeedOrganizer.Size = new System.Drawing.Size(275, 166);
            this.metroListViewFeedOrganizer.TabIndex = 2;
            this.metroListViewFeedOrganizer.UseCompatibleStateImageBehavior = false;
            this.metroListViewFeedOrganizer.UseSelectable = true;
            // 
            // metroToggleQueueAll
            // 
            this.metroToggleQueueAll.AutoSize = true;
            this.metroToggleQueueAll.Location = new System.Drawing.Point(3, 32);
            this.metroToggleQueueAll.Name = "metroToggleQueueAll";
            this.metroToggleQueueAll.Size = new System.Drawing.Size(80, 17);
            this.metroToggleQueueAll.TabIndex = 4;
            this.metroToggleQueueAll.Text = "Off";
            this.metroToggleQueueAll.UseSelectable = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(618, 395);
            this.Controls.Add(this.mainInnerPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Resizable = false;
            this.Text = "Feed Control";
            this.mainInnerPanel.ResumeLayout(false);
            this.tableLayoutPanelInnerPanel.ResumeLayout(false);
            this.metroPanelMainRight.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.metroPanelMainLeft.ResumeLayout(false);
            this.tableLayoutPanelFeedOrganizer.ResumeLayout(false);
            this.metroPanelFeedOrganizer.ResumeLayout(false);
            this.metroPanelFeedOrganizerControls.ResumeLayout(false);
            this.metroPanelFeedOrganizerControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel mainInnerPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelInnerPanel;
        private MetroFramework.Controls.MetroPanel metroPanelMainRight;
        private MetroFramework.Controls.MetroPanel metroPanelMainLeft;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFeedOrganizer;
        private MetroFramework.Controls.MetroPanel metroPanelFeedOrganizer;
        private MetroFramework.Controls.MetroPanel metroPanelFeedOrganizerControls;
        private FormExtras.ListViewWithReordering metroListViewFeedOrganizer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroListView metroListViewFeedQueue;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton metroButtonAddItemsToQueue;
        private MetroFramework.Controls.MetroButton metroButtonClearQueue;
        private MetroFramework.Controls.MetroToggle metroToggleQueueAll;
    }
}