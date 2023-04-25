﻿namespace FileManager
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            TopPanel = new System.Windows.Forms.Panel();
            lb_title = new System.Windows.Forms.Label();
            bt_Setting = new System.Windows.Forms.Button();
            Mainpanel = new System.Windows.Forms.Panel();
            tbc_Main = new System.Windows.Forms.TabControl();
            tP_Log = new System.Windows.Forms.TabPage();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            bt_restart = new System.Windows.Forms.Button();
            rtb_LogPrint = new System.Windows.Forms.RichTextBox();
            tP_TreeView = new System.Windows.Forms.TabPage();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            bt_SavedeleteList = new System.Windows.Forms.Button();
            gb_List = new System.Windows.Forms.GroupBox();
            tv_superPath = new System.Windows.Forms.TreeView();
            gb_Delete = new System.Windows.Forms.GroupBox();
            ltb_deletList = new System.Windows.Forms.ListBox();
            ofDialog = new System.Windows.Forms.OpenFileDialog();
            fsWatcher = new System.IO.FileSystemWatcher();
            nfIcon = new System.Windows.Forms.NotifyIcon(components);
            ctMenuStrp = new System.Windows.Forms.ContextMenuStrip(components);
            sm_show = new System.Windows.Forms.ToolStripMenuItem();
            sm_exit = new System.Windows.Forms.ToolStripMenuItem();
            TopPanel.SuspendLayout();
            Mainpanel.SuspendLayout();
            tbc_Main.SuspendLayout();
            tP_Log.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tP_TreeView.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            gb_List.SuspendLayout();
            gb_Delete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fsWatcher).BeginInit();
            ctMenuStrp.SuspendLayout();
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
            Mainpanel.Size = new System.Drawing.Size(745, 424);
            Mainpanel.TabIndex = 1;
            // 
            // tbc_Main
            // 
            tbc_Main.Controls.Add(tP_Log);
            tbc_Main.Controls.Add(tP_TreeView);
            tbc_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            tbc_Main.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            tbc_Main.ItemSize = new System.Drawing.Size(69, 25);
            tbc_Main.Location = new System.Drawing.Point(5, 0);
            tbc_Main.Margin = new System.Windows.Forms.Padding(5);
            tbc_Main.Multiline = true;
            tbc_Main.Name = "tbc_Main";
            tbc_Main.SelectedIndex = 0;
            tbc_Main.Size = new System.Drawing.Size(735, 419);
            tbc_Main.TabIndex = 2;
            tbc_Main.TabStop = false;
            // 
            // tP_Log
            // 
            tP_Log.Controls.Add(tableLayoutPanel2);
            tP_Log.Location = new System.Drawing.Point(4, 29);
            tP_Log.Name = "tP_Log";
            tP_Log.Padding = new System.Windows.Forms.Padding(3);
            tP_Log.Size = new System.Drawing.Size(727, 386);
            tP_Log.TabIndex = 1;
            tP_Log.Text = "Logs";
            tP_Log.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.051384F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.948616F));
            tableLayoutPanel2.Controls.Add(bt_restart, 1, 0);
            tableLayoutPanel2.Controls.Add(rtb_LogPrint, 0, 0);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new System.Drawing.Size(721, 380);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // bt_restart
            // 
            bt_restart.Dock = System.Windows.Forms.DockStyle.Fill;
            bt_restart.Location = new System.Drawing.Point(572, 3);
            bt_restart.Name = "bt_restart";
            bt_restart.Size = new System.Drawing.Size(146, 374);
            bt_restart.TabIndex = 1;
            bt_restart.Text = "RESTART";
            bt_restart.UseVisualStyleBackColor = true;
            bt_restart.Click += bt_restart_Click;
            // 
            // rtb_LogPrint
            // 
            rtb_LogPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            rtb_LogPrint.Location = new System.Drawing.Point(3, 3);
            rtb_LogPrint.Name = "rtb_LogPrint";
            rtb_LogPrint.Size = new System.Drawing.Size(563, 374);
            rtb_LogPrint.TabIndex = 2;
            rtb_LogPrint.Text = "";
            // 
            // tP_TreeView
            // 
            tP_TreeView.Controls.Add(tableLayoutPanel1);
            tP_TreeView.Location = new System.Drawing.Point(4, 29);
            tP_TreeView.Margin = new System.Windows.Forms.Padding(5);
            tP_TreeView.Name = "tP_TreeView";
            tP_TreeView.Padding = new System.Windows.Forms.Padding(5);
            tP_TreeView.Size = new System.Drawing.Size(727, 386);
            tP_TreeView.TabIndex = 0;
            tP_TreeView.Text = "Set Path";
            tP_TreeView.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.2222214F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(bt_SavedeleteList, 1, 0);
            tableLayoutPanel1.Controls.Add(gb_List, 0, 0);
            tableLayoutPanel1.Controls.Add(gb_Delete, 2, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(717, 376);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // bt_SavedeleteList
            // 
            bt_SavedeleteList.BackColor = System.Drawing.Color.Transparent;
            bt_SavedeleteList.Dock = System.Windows.Forms.DockStyle.Fill;
            bt_SavedeleteList.Image = Properties.Resources.arrow_next_right;
            bt_SavedeleteList.Location = new System.Drawing.Point(271, 3);
            bt_SavedeleteList.Name = "bt_SavedeleteList";
            bt_SavedeleteList.Size = new System.Drawing.Size(173, 370);
            bt_SavedeleteList.TabIndex = 1;
            bt_SavedeleteList.UseVisualStyleBackColor = false;
            bt_SavedeleteList.Click += bt_SavedeleteList_Click;
            // 
            // gb_List
            // 
            gb_List.Controls.Add(tv_superPath);
            gb_List.Dock = System.Windows.Forms.DockStyle.Fill;
            gb_List.Location = new System.Drawing.Point(3, 3);
            gb_List.Name = "gb_List";
            gb_List.Size = new System.Drawing.Size(262, 370);
            gb_List.TabIndex = 4;
            gb_List.TabStop = false;
            gb_List.Text = "LIST";
            // 
            // tv_superPath
            // 
            tv_superPath.CheckBoxes = true;
            tv_superPath.Dock = System.Windows.Forms.DockStyle.Fill;
            tv_superPath.Location = new System.Drawing.Point(3, 23);
            tv_superPath.Name = "tv_superPath";
            tv_superPath.Size = new System.Drawing.Size(256, 344);
            tv_superPath.TabIndex = 2;
            tv_superPath.AfterSelect += tv_superPath_AfterCheck;
            // 
            // gb_Delete
            // 
            gb_Delete.Controls.Add(ltb_deletList);
            gb_Delete.Dock = System.Windows.Forms.DockStyle.Fill;
            gb_Delete.Location = new System.Drawing.Point(450, 3);
            gb_Delete.Name = "gb_Delete";
            gb_Delete.Size = new System.Drawing.Size(264, 370);
            gb_Delete.TabIndex = 5;
            gb_Delete.TabStop = false;
            gb_Delete.Text = "DELETE";
            // 
            // ltb_deletList
            // 
            ltb_deletList.Dock = System.Windows.Forms.DockStyle.Fill;
            ltb_deletList.FormattingEnabled = true;
            ltb_deletList.ItemHeight = 20;
            ltb_deletList.Location = new System.Drawing.Point(3, 23);
            ltb_deletList.Margin = new System.Windows.Forms.Padding(0);
            ltb_deletList.Name = "ltb_deletList";
            ltb_deletList.Size = new System.Drawing.Size(258, 344);
            ltb_deletList.TabIndex = 0;
            // 
            // ofDialog
            // 
            ofDialog.FileName = "openFileDialog1";
            // 
            // fsWatcher
            // 
            fsWatcher.EnableRaisingEvents = true;
            fsWatcher.SynchronizingObject = this;
            // 
            // nfIcon
            // 
            nfIcon.ContextMenuStrip = ctMenuStrp;
            nfIcon.Icon = (System.Drawing.Icon)resources.GetObject("nfIcon.Icon");
            nfIcon.Text = "FileManager";
            nfIcon.Visible = true;
            nfIcon.MouseDoubleClick += Tray_Icon_MouseDoubleClick;
            // 
            // ctMenuStrp
            // 
            ctMenuStrp.ImageScalingSize = new System.Drawing.Size(20, 20);
            ctMenuStrp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { sm_show, sm_exit });
            ctMenuStrp.Name = "ctMenuStrp";
            ctMenuStrp.Size = new System.Drawing.Size(124, 52);
            // 
            // sm_show
            // 
            sm_show.Name = "sm_show";
            sm_show.Size = new System.Drawing.Size(123, 24);
            sm_show.Text = "SHOW";
            sm_show.Click += Sm_show_Click;
            // 
            // sm_exit
            // 
            sm_exit.Name = "sm_exit";
            sm_exit.Size = new System.Drawing.Size(123, 24);
            sm_exit.Text = "EXIT";
            sm_exit.Click += Sm_exit_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(745, 465);
            Controls.Add(Mainpanel);
            Controls.Add(TopPanel);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "FileManager";
            TopPanel.ResumeLayout(false);
            TopPanel.PerformLayout();
            Mainpanel.ResumeLayout(false);
            tbc_Main.ResumeLayout(false);
            tP_Log.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tP_TreeView.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            gb_List.ResumeLayout(false);
            gb_Delete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)fsWatcher).EndInit();
            ctMenuStrp.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Button bt_Setting;
        private System.Windows.Forms.Panel Mainpanel;
        private System.Windows.Forms.TabControl tbc_Main;
        private System.Windows.Forms.TabPage tP_TreeView;
        private System.Windows.Forms.TabPage tP_Log;
        private System.Windows.Forms.Label lb_title;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button bt_SavedeleteList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button bt_restart;
        private System.Windows.Forms.RichTextBox rtb_LogPrint;
        private System.Windows.Forms.OpenFileDialog ofDialog;
        private System.IO.FileSystemWatcher fsWatcher;
        private System.Windows.Forms.NotifyIcon nfIcon;
        private System.Windows.Forms.ContextMenuStrip ctMenuStrp;
        private System.Windows.Forms.ToolStripMenuItem sm_show;
        private System.Windows.Forms.ToolStripMenuItem sm_exit;
        private System.Windows.Forms.GroupBox gb_List;
        private System.Windows.Forms.TreeView tv_superPath;
        private System.Windows.Forms.GroupBox gb_Delete;
        private System.Windows.Forms.ListBox ltb_deletList;
    }
}
