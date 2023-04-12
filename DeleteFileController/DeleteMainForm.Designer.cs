namespace DeleteFileController
{
    partial class DeleteMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteMainForm));
            panel1 = new System.Windows.Forms.Panel();
            bt_LoadLog = new System.Windows.Forms.Button();
            bt_SaveSetting = new System.Windows.Forms.Button();
            bt_logPath = new System.Windows.Forms.Button();
            lb_hour = new System.Windows.Forms.Label();
            cb_AutoStart = new System.Windows.Forms.CheckBox();
            tb_lastupdate = new System.Windows.Forms.TextBox();
            lb_log = new System.Windows.Forms.Label();
            rtb_log = new System.Windows.Forms.RichTextBox();
            lb_lastupdate = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            bt_Check = new System.Windows.Forms.Button();
            lb_Time = new System.Windows.Forms.Label();
            tb_Time = new System.Windows.Forms.TextBox();
            lb_Interval = new System.Windows.Forms.Label();
            lb_Path = new System.Windows.Forms.Label();
            tb_Path = new System.Windows.Forms.TextBox();
            panel3 = new System.Windows.Forms.Panel();
            listb_deletePath = new System.Windows.Forms.ListBox();
            bt_setpath = new System.Windows.Forms.Button();
            lb_Delete = new System.Windows.Forms.Label();
            lb_Tree_Directory = new System.Windows.Forms.Label();
            Tree_Directory = new System.Windows.Forms.TreeView();
            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            fileSystemWatcher = new System.IO.FileSystemWatcher();
            Tray_Icon = new System.Windows.Forms.NotifyIcon(components);
            Context_TaryIcon = new System.Windows.Forms.ContextMenuStrip(components);
            sm_show = new System.Windows.Forms.ToolStripMenuItem();
            sm_exit = new System.Windows.Forms.ToolStripMenuItem();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher).BeginInit();
            Context_TaryIcon.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(bt_LoadLog);
            panel1.Controls.Add(bt_SaveSetting);
            panel1.Controls.Add(bt_logPath);
            panel1.Controls.Add(lb_hour);
            panel1.Controls.Add(cb_AutoStart);
            panel1.Controls.Add(tb_lastupdate);
            panel1.Controls.Add(lb_log);
            panel1.Controls.Add(rtb_log);
            panel1.Controls.Add(lb_lastupdate);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(0, 325);
            panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(742, 327);
            panel1.TabIndex = 0;
            // 
            // bt_LoadLog
            // 
            bt_LoadLog.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            bt_LoadLog.Location = new System.Drawing.Point(14, 284);
            bt_LoadLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            bt_LoadLog.Name = "bt_LoadLog";
            bt_LoadLog.Size = new System.Drawing.Size(597, 33);
            bt_LoadLog.TabIndex = 9;
            bt_LoadLog.Text = "Load";
            bt_LoadLog.UseVisualStyleBackColor = true;
            // 
            // bt_SaveSetting
            // 
            bt_SaveSetting.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            bt_SaveSetting.Location = new System.Drawing.Point(609, 4);
            bt_SaveSetting.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            bt_SaveSetting.Name = "bt_SaveSetting";
            bt_SaveSetting.Size = new System.Drawing.Size(119, 33);
            bt_SaveSetting.TabIndex = 8;
            bt_SaveSetting.Text = "SAVE";
            bt_SaveSetting.UseVisualStyleBackColor = true;
            // 
            // bt_logPath
            // 
            bt_logPath.Image = (System.Drawing.Image)resources.GetObject("bt_logPath.Image");
            bt_logPath.Location = new System.Drawing.Point(71, 5);
            bt_logPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            bt_logPath.Name = "bt_logPath";
            bt_logPath.Size = new System.Drawing.Size(32, 32);
            bt_logPath.TabIndex = 6;
            bt_logPath.UseVisualStyleBackColor = true;
            // 
            // lb_hour
            // 
            lb_hour.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lb_hour.AutoSize = true;
            lb_hour.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lb_hour.Location = new System.Drawing.Point(549, 12);
            lb_hour.Name = "lb_hour";
            lb_hour.Size = new System.Drawing.Size(59, 20);
            lb_hour.TabIndex = 6;
            lb_hour.Text = "DAYS";
            // 
            // cb_AutoStart
            // 
            cb_AutoStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            cb_AutoStart.AutoSize = true;
            cb_AutoStart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            cb_AutoStart.Location = new System.Drawing.Point(626, 291);
            cb_AutoStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cb_AutoStart.Name = "cb_AutoStart";
            cb_AutoStart.Size = new System.Drawing.Size(103, 24);
            cb_AutoStart.TabIndex = 3;
            cb_AutoStart.Text = "AutoStart :";
            cb_AutoStart.UseVisualStyleBackColor = true;
            cb_AutoStart.CheckedChanged += cb_AutoStart_CheckedChanged;
            // 
            // tb_lastupdate
            // 
            tb_lastupdate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            tb_lastupdate.Location = new System.Drawing.Point(506, 8);
            tb_lastupdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tb_lastupdate.Name = "tb_lastupdate";
            tb_lastupdate.Size = new System.Drawing.Size(40, 27);
            tb_lastupdate.TabIndex = 6;
            tb_lastupdate.Text = "48";
            tb_lastupdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_log
            // 
            lb_log.AutoSize = true;
            lb_log.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lb_log.Location = new System.Drawing.Point(15, 11);
            lb_log.Name = "lb_log";
            lb_log.Size = new System.Drawing.Size(49, 20);
            lb_log.TabIndex = 2;
            lb_log.Text = "LOG";
            // 
            // rtb_log
            // 
            rtb_log.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            rtb_log.Location = new System.Drawing.Point(12, 40);
            rtb_log.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            rtb_log.Name = "rtb_log";
            rtb_log.Size = new System.Drawing.Size(716, 234);
            rtb_log.TabIndex = 0;
            rtb_log.Text = "";
            // 
            // lb_lastupdate
            // 
            lb_lastupdate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lb_lastupdate.AutoSize = true;
            lb_lastupdate.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lb_lastupdate.Location = new System.Drawing.Point(337, 12);
            lb_lastupdate.Name = "lb_lastupdate";
            lb_lastupdate.Size = new System.Drawing.Size(159, 20);
            lb_lastupdate.TabIndex = 6;
            lb_lastupdate.Text = "LAST UPDATE : ";
            // 
            // panel2
            // 
            panel2.Controls.Add(bt_Check);
            panel2.Controls.Add(lb_Time);
            panel2.Controls.Add(tb_Time);
            panel2.Controls.Add(lb_Interval);
            panel2.Controls.Add(lb_Path);
            panel2.Controls.Add(tb_Path);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(742, 40);
            panel2.TabIndex = 1;
            // 
            // bt_Check
            // 
            bt_Check.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            bt_Check.Location = new System.Drawing.Point(416, 4);
            bt_Check.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            bt_Check.Name = "bt_Check";
            bt_Check.Size = new System.Drawing.Size(91, 29);
            bt_Check.TabIndex = 5;
            bt_Check.Text = "OK";
            bt_Check.UseVisualStyleBackColor = true;
            // 
            // lb_Time
            // 
            lb_Time.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lb_Time.AutoSize = true;
            lb_Time.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lb_Time.Location = new System.Drawing.Point(683, 9);
            lb_Time.Name = "lb_Time";
            lb_Time.Size = new System.Drawing.Size(47, 20);
            lb_Time.TabIndex = 4;
            lb_Time.Text = "Hour";
            // 
            // tb_Time
            // 
            tb_Time.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            tb_Time.Location = new System.Drawing.Point(638, 6);
            tb_Time.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tb_Time.Name = "tb_Time";
            tb_Time.Size = new System.Drawing.Size(42, 27);
            tb_Time.TabIndex = 2;
            tb_Time.Text = "3";
            tb_Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_Interval
            // 
            lb_Interval.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lb_Interval.AutoSize = true;
            lb_Interval.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lb_Interval.Location = new System.Drawing.Point(513, 10);
            lb_Interval.Name = "lb_Interval";
            lb_Interval.Size = new System.Drawing.Size(117, 20);
            lb_Interval.TabIndex = 3;
            lb_Interval.Text = "INTERVAL : ";
            // 
            // lb_Path
            // 
            lb_Path.AutoSize = true;
            lb_Path.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lb_Path.Location = new System.Drawing.Point(12, 9);
            lb_Path.Name = "lb_Path";
            lb_Path.Size = new System.Drawing.Size(71, 20);
            lb_Path.TabIndex = 1;
            lb_Path.Text = "PATH :";
            // 
            // tb_Path
            // 
            tb_Path.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_Path.Location = new System.Drawing.Point(83, 5);
            tb_Path.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tb_Path.Name = "tb_Path";
            tb_Path.Size = new System.Drawing.Size(327, 27);
            tb_Path.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(listb_deletePath);
            panel3.Controls.Add(bt_setpath);
            panel3.Controls.Add(lb_Delete);
            panel3.Controls.Add(lb_Tree_Directory);
            panel3.Controls.Add(Tree_Directory);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(0, 40);
            panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(742, 285);
            panel3.TabIndex = 2;
            // 
            // listb_deletePath
            // 
            listb_deletePath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            listb_deletePath.FormattingEnabled = true;
            listb_deletePath.ItemHeight = 20;
            listb_deletePath.Location = new System.Drawing.Point(342, 28);
            listb_deletePath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            listb_deletePath.Name = "listb_deletePath";
            listb_deletePath.Size = new System.Drawing.Size(387, 244);
            listb_deletePath.TabIndex = 7;
            // 
            // bt_setpath
            // 
            bt_setpath.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            bt_setpath.Location = new System.Drawing.Point(14, 234);
            bt_setpath.Margin = new System.Windows.Forms.Padding(0);
            bt_setpath.Name = "bt_setpath";
            bt_setpath.Size = new System.Drawing.Size(301, 38);
            bt_setpath.TabIndex = 3;
            bt_setpath.Text = "SETTING";
            bt_setpath.UseVisualStyleBackColor = true;
            // 
            // lb_Delete
            // 
            lb_Delete.AutoSize = true;
            lb_Delete.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lb_Delete.Location = new System.Drawing.Point(342, 4);
            lb_Delete.Name = "lb_Delete";
            lb_Delete.Size = new System.Drawing.Size(101, 20);
            lb_Delete.TabIndex = 3;
            lb_Delete.Text = "Delete List";
            // 
            // lb_Tree_Directory
            // 
            lb_Tree_Directory.AutoSize = true;
            lb_Tree_Directory.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lb_Tree_Directory.Location = new System.Drawing.Point(14, 4);
            lb_Tree_Directory.Name = "lb_Tree_Directory";
            lb_Tree_Directory.Size = new System.Drawing.Size(121, 20);
            lb_Tree_Directory.TabIndex = 1;
            lb_Tree_Directory.Text = "Directory List";
            // 
            // Tree_Directory
            // 
            Tree_Directory.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            Tree_Directory.CheckBoxes = true;
            Tree_Directory.Location = new System.Drawing.Point(14, 28);
            Tree_Directory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Tree_Directory.Name = "Tree_Directory";
            Tree_Directory.Size = new System.Drawing.Size(301, 202);
            Tree_Directory.TabIndex = 0;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // fileSystemWatcher
            // 
            fileSystemWatcher.EnableRaisingEvents = true;
            fileSystemWatcher.SynchronizingObject = this;
            // 
            // Tray_Icon
            // 
            Tray_Icon.ContextMenuStrip = Context_TaryIcon;
            Tray_Icon.Icon = (System.Drawing.Icon)resources.GetObject("Tray_Icon.Icon");
            Tray_Icon.Text = "파일정리";
            Tray_Icon.Visible = true;
            // 
            // Context_TaryIcon
            // 
            Context_TaryIcon.ImageScalingSize = new System.Drawing.Size(20, 20);
            Context_TaryIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { sm_show, sm_exit });
            Context_TaryIcon.Name = "Context_TaryIcon";
            Context_TaryIcon.Size = new System.Drawing.Size(116, 52);
            // 
            // sm_show
            // 
            sm_show.Name = "sm_show";
            sm_show.Size = new System.Drawing.Size(115, 24);
            sm_show.Text = "Show";
            // 
            // sm_exit
            // 
            sm_exit.Name = "sm_exit";
            sm_exit.Size = new System.Drawing.Size(115, 24);
            sm_exit.Text = "Exit";
            // 
            // DeleteMainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(742, 652);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MinimumSize = new System.Drawing.Size(760, 699);
            Name = "DeleteMainForm";
            Text = "Delete";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher).EndInit();
            Context_TaryIcon.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox rtb_log;
        private System.Windows.Forms.Label lb_Path;
        private System.Windows.Forms.TextBox tb_Path;
        private System.Windows.Forms.Label lb_Interval;
        private System.Windows.Forms.TextBox tb_Time;
        private System.Windows.Forms.TreeView Tree_Directory;
        private System.Windows.Forms.Label lb_Time;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.IO.FileSystemWatcher fileSystemWatcher;
        private System.Windows.Forms.Label lb_log;
        private System.Windows.Forms.Label lb_Tree_Directory;
        private System.Windows.Forms.Label lb_Delete;
        private System.Windows.Forms.Button bt_Check;
        private System.Windows.Forms.Label lb_lastupdate;
        private System.Windows.Forms.Label lb_hour;
        private System.Windows.Forms.TextBox tb_lastupdate;
        private System.Windows.Forms.CheckBox cb_AutoStart;
        private System.Windows.Forms.NotifyIcon Tray_Icon;
        private System.Windows.Forms.ContextMenuStrip Context_TaryIcon;
        private System.Windows.Forms.ToolStripMenuItem sm_show;
        private System.Windows.Forms.ToolStripMenuItem sm_exit;
        private System.Windows.Forms.Button bt_logPath;
        private System.Windows.Forms.ListBox listb_deletePath;
        private System.Windows.Forms.Button bt_SaveSetting;
        private System.Windows.Forms.Button bt_setpath;
        private System.Windows.Forms.Button bt_LoadLog;
    }
}
