namespace FileManager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            TopPanel = new System.Windows.Forms.Panel();
            lb_title = new System.Windows.Forms.Label();
            bt_Setting = new System.Windows.Forms.Button();
            Mainpanel = new System.Windows.Forms.Panel();
            tbc_Main = new System.Windows.Forms.TabControl();
            tP_LOG = new System.Windows.Forms.TabPage();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            bt_restart = new System.Windows.Forms.Button();
            tP_TreeView = new System.Windows.Forms.TabPage();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            tv_superPath = new System.Windows.Forms.TreeView();
            bt_SetDeleteList = new System.Windows.Forms.Button();
            ltb_deletList = new System.Windows.Forms.ListBox();
            bt_SavedeleteList = new System.Windows.Forms.Button();
            TopPanel.SuspendLayout();
            Mainpanel.SuspendLayout();
            tbc_Main.SuspendLayout();
            tP_LOG.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tP_TreeView.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // TopPanel
            // 
            TopPanel.Controls.Add(lb_title);
            TopPanel.Controls.Add(bt_Setting);
            TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            TopPanel.Location = new System.Drawing.Point(0, 0);
            TopPanel.Name = "TopPanel";
            TopPanel.Size = new System.Drawing.Size(745, 41);
            TopPanel.TabIndex = 0;
            // 
            // lb_title
            // 
            lb_title.AutoSize = true;
            lb_title.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lb_title.Location = new System.Drawing.Point(4, 4);
            lb_title.Name = "lb_title";
            lb_title.Size = new System.Drawing.Size(154, 32);
            lb_title.TabIndex = 1;
            lb_title.Text = "File Manager";
            // 
            // bt_Setting
            // 
            bt_Setting.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            bt_Setting.Image = Properties.Resources.setting_logpath;
            bt_Setting.Location = new System.Drawing.Point(709, 5);
            bt_Setting.Name = "bt_Setting";
            bt_Setting.Size = new System.Drawing.Size(31, 31);
            bt_Setting.TabIndex = 0;
            bt_Setting.UseVisualStyleBackColor = true;
            bt_Setting.Click += bt_Setting_Click;
            // 
            // Mainpanel
            // 
            Mainpanel.Controls.Add(tbc_Main);
            Mainpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            Mainpanel.Location = new System.Drawing.Point(0, 41);
            Mainpanel.Name = "Mainpanel";
            Mainpanel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            Mainpanel.Size = new System.Drawing.Size(745, 341);
            Mainpanel.TabIndex = 1;
            // 
            // tbc_Main
            // 
            tbc_Main.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            tbc_Main.Controls.Add(tP_LOG);
            tbc_Main.Controls.Add(tP_TreeView);
            tbc_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            tbc_Main.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            tbc_Main.ItemSize = new System.Drawing.Size(69, 25);
            tbc_Main.Location = new System.Drawing.Point(5, 0);
            tbc_Main.Margin = new System.Windows.Forms.Padding(5);
            tbc_Main.Multiline = true;
            tbc_Main.Name = "tbc_Main";
            tbc_Main.SelectedIndex = 0;
            tbc_Main.Size = new System.Drawing.Size(735, 336);
            tbc_Main.TabIndex = 2;
            tbc_Main.TabStop = false;
            // 
            // tP_LOG
            // 
            tP_LOG.Controls.Add(tableLayoutPanel2);
            tP_LOG.Location = new System.Drawing.Point(4, 4);
            tP_LOG.Name = "tP_LOG";
            tP_LOG.Padding = new System.Windows.Forms.Padding(3);
            tP_LOG.Size = new System.Drawing.Size(727, 303);
            tP_LOG.TabIndex = 1;
            tP_LOG.Text = "Logs";
            tP_LOG.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.051384F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.948616F));
            tableLayoutPanel2.Controls.Add(bt_restart, 1, 0);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new System.Drawing.Size(721, 297);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // bt_restart
            // 
            bt_restart.Dock = System.Windows.Forms.DockStyle.Fill;
            bt_restart.Location = new System.Drawing.Point(572, 3);
            bt_restart.Name = "bt_restart";
            bt_restart.Size = new System.Drawing.Size(146, 291);
            bt_restart.TabIndex = 1;
            bt_restart.Text = "RESTART";
            bt_restart.UseVisualStyleBackColor = true;
            // 
            // tP_TreeView
            // 
            tP_TreeView.Controls.Add(tableLayoutPanel1);
            tP_TreeView.Location = new System.Drawing.Point(4, 4);
            tP_TreeView.Margin = new System.Windows.Forms.Padding(5);
            tP_TreeView.Name = "tP_TreeView";
            tP_TreeView.Padding = new System.Windows.Forms.Padding(5);
            tP_TreeView.Size = new System.Drawing.Size(727, 303);
            tP_TreeView.TabIndex = 0;
            tP_TreeView.Text = "Set Path";
            tP_TreeView.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.2222214F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.Controls.Add(tv_superPath, 0, 0);
            tableLayoutPanel1.Controls.Add(bt_SetDeleteList, 3, 0);
            tableLayoutPanel1.Controls.Add(ltb_deletList, 2, 0);
            tableLayoutPanel1.Controls.Add(bt_SavedeleteList, 1, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(717, 293);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tv_superPath
            // 
            tv_superPath.Dock = System.Windows.Forms.DockStyle.Fill;
            tv_superPath.Location = new System.Drawing.Point(3, 3);
            tv_superPath.Name = "tv_superPath";
            tv_superPath.Size = new System.Drawing.Size(233, 287);
            tv_superPath.TabIndex = 0;
            // 
            // bt_SetDeleteList
            // 
            bt_SetDeleteList.Dock = System.Windows.Forms.DockStyle.Fill;
            bt_SetDeleteList.Location = new System.Drawing.Point(640, 3);
            bt_SetDeleteList.Name = "bt_SetDeleteList";
            bt_SetDeleteList.Size = new System.Drawing.Size(74, 287);
            bt_SetDeleteList.TabIndex = 2;
            bt_SetDeleteList.Text = "SAVE";
            bt_SetDeleteList.UseVisualStyleBackColor = true;
            // 
            // ltb_deletList
            // 
            ltb_deletList.Dock = System.Windows.Forms.DockStyle.Fill;
            ltb_deletList.FormattingEnabled = true;
            ltb_deletList.ItemHeight = 20;
            ltb_deletList.Location = new System.Drawing.Point(401, 3);
            ltb_deletList.Name = "ltb_deletList";
            ltb_deletList.Size = new System.Drawing.Size(233, 287);
            ltb_deletList.TabIndex = 3;
            // 
            // bt_SavedeleteList
            // 
            bt_SavedeleteList.BackColor = System.Drawing.Color.Transparent;
            bt_SavedeleteList.Dock = System.Windows.Forms.DockStyle.Fill;
            bt_SavedeleteList.Image = Properties.Resources.arrow_next_right;
            bt_SavedeleteList.Location = new System.Drawing.Point(242, 3);
            bt_SavedeleteList.Name = "bt_SavedeleteList";
            bt_SavedeleteList.Size = new System.Drawing.Size(153, 287);
            bt_SavedeleteList.TabIndex = 1;
            bt_SavedeleteList.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(745, 382);
            Controls.Add(Mainpanel);
            Controls.Add(TopPanel);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "FileManager";
            TopPanel.ResumeLayout(false);
            TopPanel.PerformLayout();
            Mainpanel.ResumeLayout(false);
            tbc_Main.ResumeLayout(false);
            tP_LOG.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tP_TreeView.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Button bt_Setting;
        private System.Windows.Forms.Panel Mainpanel;
        private System.Windows.Forms.TabControl tbc_Main;
        private System.Windows.Forms.TabPage tP_TreeView;
        private System.Windows.Forms.TabPage tP_LOG;
        private System.Windows.Forms.Label lb_title;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView tv_superPath;
        private System.Windows.Forms.Button bt_SavedeleteList;
        private System.Windows.Forms.Button bt_SetDeleteList;
        private System.Windows.Forms.ListBox ltb_deletList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button bt_restart;
    }
}
