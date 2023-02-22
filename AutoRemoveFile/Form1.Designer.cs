namespace AutoRemoveFile
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_log = new System.Windows.Forms.Label();
            this.rtb_log = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bt_Check = new System.Windows.Forms.Button();
            this.lb_Time = new System.Windows.Forms.Label();
            this.tb_Time = new System.Windows.Forms.TextBox();
            this.lb_Interval = new System.Windows.Forms.Label();
            this.lb_Path = new System.Windows.Forms.Label();
            this.tb_Path = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.clb_Delete = new System.Windows.Forms.CheckedListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lb_Delete = new System.Windows.Forms.Label();
            this.lb_Tree_Directory = new System.Windows.Forms.Label();
            this.Tree_Directory = new System.Windows.Forms.TreeView();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lb_log);
            this.panel1.Controls.Add(this.rtb_log);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 456);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 218);
            this.panel1.TabIndex = 0;
            // 
            // lb_log
            // 
            this.lb_log.AutoSize = true;
            this.lb_log.Font = new System.Drawing.Font("굴림", 12F);
            this.lb_log.Location = new System.Drawing.Point(15, 12);
            this.lb_log.Name = "lb_log";
            this.lb_log.Size = new System.Drawing.Size(51, 20);
            this.lb_log.TabIndex = 2;
            this.lb_log.Text = "Logs";
            // 
            // rtb_log
            // 
            this.rtb_log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_log.Location = new System.Drawing.Point(12, 39);
            this.rtb_log.Name = "rtb_log";
            this.rtb_log.Size = new System.Drawing.Size(783, 167);
            this.rtb_log.TabIndex = 0;
            this.rtb_log.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bt_Check);
            this.panel2.Controls.Add(this.lb_Time);
            this.panel2.Controls.Add(this.tb_Time);
            this.panel2.Controls.Add(this.lb_Interval);
            this.panel2.Controls.Add(this.lb_Path);
            this.panel2.Controls.Add(this.tb_Path);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(806, 47);
            this.panel2.TabIndex = 1;
            // 
            // bt_Check
            // 
            this.bt_Check.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Check.Location = new System.Drawing.Point(429, 12);
            this.bt_Check.Name = "bt_Check";
            this.bt_Check.Size = new System.Drawing.Size(97, 25);
            this.bt_Check.TabIndex = 5;
            this.bt_Check.Text = "CHECK";
            this.bt_Check.UseVisualStyleBackColor = true;
            this.bt_Check.Click += new System.EventHandler(this.bt_Check_Click);
            // 
            // lb_Time
            // 
            this.lb_Time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Time.AutoSize = true;
            this.lb_Time.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Time.Location = new System.Drawing.Point(726, 14);
            this.lb_Time.Name = "lb_Time";
            this.lb_Time.Size = new System.Drawing.Size(47, 20);
            this.lb_Time.TabIndex = 4;
            this.lb_Time.Text = "Hour";
            // 
            // tb_Time
            // 
            this.tb_Time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Time.Location = new System.Drawing.Point(655, 12);
            this.tb_Time.Name = "tb_Time";
            this.tb_Time.Size = new System.Drawing.Size(69, 25);
            this.tb_Time.TabIndex = 2;
            this.tb_Time.Text = "3";
            this.tb_Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_Interval
            // 
            this.lb_Interval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Interval.AutoSize = true;
            this.lb_Interval.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Interval.Location = new System.Drawing.Point(542, 15);
            this.lb_Interval.Name = "lb_Interval";
            this.lb_Interval.Size = new System.Drawing.Size(117, 20);
            this.lb_Interval.TabIndex = 3;
            this.lb_Interval.Text = "INTERVAL : ";
            // 
            // lb_Path
            // 
            this.lb_Path.AutoSize = true;
            this.lb_Path.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Path.Location = new System.Drawing.Point(12, 15);
            this.lb_Path.Name = "lb_Path";
            this.lb_Path.Size = new System.Drawing.Size(71, 20);
            this.lb_Path.TabIndex = 1;
            this.lb_Path.Text = "PATH :";
            // 
            // tb_Path
            // 
            this.tb_Path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Path.Location = new System.Drawing.Point(85, 12);
            this.tb_Path.Name = "tb_Path";
            this.tb_Path.Size = new System.Drawing.Size(337, 25);
            this.tb_Path.TabIndex = 0;
            this.tb_Path.Text = "D:\\DAT";
            this.tb_Path.Click += new System.EventHandler(this.tb_Path_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.clb_Delete);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.lb_Delete);
            this.panel3.Controls.Add(this.lb_Tree_Directory);
            this.panel3.Controls.Add(this.Tree_Directory);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 47);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(806, 409);
            this.panel3.TabIndex = 2;
            // 
            // clb_Delete
            // 
            this.clb_Delete.FormattingEnabled = true;
            this.clb_Delete.Location = new System.Drawing.Point(416, 43);
            this.clb_Delete.Name = "clb_Delete";
            this.clb_Delete.Size = new System.Drawing.Size(379, 304);
            this.clb_Delete.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button2.Location = new System.Drawing.Point(416, 353);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(379, 50);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(12, 353);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(379, 50);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb_Delete
            // 
            this.lb_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Delete.AutoSize = true;
            this.lb_Delete.Font = new System.Drawing.Font("굴림", 12F);
            this.lb_Delete.Location = new System.Drawing.Point(419, 15);
            this.lb_Delete.Name = "lb_Delete";
            this.lb_Delete.Size = new System.Drawing.Size(101, 20);
            this.lb_Delete.TabIndex = 3;
            this.lb_Delete.Text = "Delete List";
            // 
            // lb_Tree_Directory
            // 
            this.lb_Tree_Directory.AutoSize = true;
            this.lb_Tree_Directory.Font = new System.Drawing.Font("굴림", 12F);
            this.lb_Tree_Directory.Location = new System.Drawing.Point(13, 15);
            this.lb_Tree_Directory.Name = "lb_Tree_Directory";
            this.lb_Tree_Directory.Size = new System.Drawing.Size(121, 20);
            this.lb_Tree_Directory.TabIndex = 1;
            this.lb_Tree_Directory.Text = "Directory List";
            // 
            // Tree_Directory
            // 
            this.Tree_Directory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tree_Directory.CheckBoxes = true;
            this.Tree_Directory.Location = new System.Drawing.Point(12, 43);
            this.Tree_Directory.Name = "Tree_Directory";
            this.Tree_Directory.Size = new System.Drawing.Size(379, 304);
            this.Tree_Directory.TabIndex = 0;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.EnableRaisingEvents = true;
            this.fileSystemWatcher.SynchronizingObject = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 674);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bt_Check;
        private System.Windows.Forms.CheckedListBox clb_Delete;
    }
}

