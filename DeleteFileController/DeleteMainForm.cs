using DeleteFileController.Model;
using DeleteFileController.Presenter;
using DeleteFileController.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeleteFileController
{
    public partial class DeleteMainForm : Form, interMain
    {
        public string APPLICATION_NAME { get { return "DeleteFolderManager"; } }
        public string SuperPath
        {
            get
            {
                try { if (File.Exists(Properties.Settings.Default.SuperPath)) return Properties.Settings.Default.SuperPath; }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Not Directory"); }
                return string.Empty;
            }
            set => Properties.Settings.Default.SuperPath = value;
        }
        public List<string> DeleteDirList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<TreeNode> SuperPathChild { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IntervalHours { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int OldDayDelete { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool AutoStart { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TreeView tree_Directory { get => Tree_Directory; set => Tree_Directory = value; }
        public RichTextBox RichTextBox { get => this.rtb_log; }

        public DeleteMainForm()
        {
            InitializeComponent();
            TrayIconAction();
            this.Load += Main_Load;

        }
        private PreAutoStart autoStart;
        private PreTreeList TreeList;
        private void PresenterList()
        {
            //Auto
            autoStart = new PreAutoStart(this, new AutoStartModel());
            cb_AutoStart.Checked = autoStart.CheckAuto();

            //TreeView
            TreeList = new PreTreeList (this, new TreeListModel ());
            tb_Path.Text = SuperPath;

            //Delete

            //Log
        }
        #region 트레이 아이콘
        private void TrayIconAction() //Events
        {
            this.FormClosing += MainForm_FormClosing;
            Tray_Icon.MouseDoubleClick += Tray_Icon_MouseDoubleClick;
            sm_show.Click += Sm_show_Click;
            sm_exit.Click += Sm_exit_Click;
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)//Dont Close
            {
                this.Hide();
                e.Cancel = true;
            }
        }
        private void Tray_Icon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }
        private void Sm_show_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }
        private void Sm_exit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you Sure?");
            Application.ExitThread();   //완전 종료
        }

        #endregion
        private void Main_Load(object? sender, EventArgs e)
        {
            PresenterList(); //Presenter
            Tray_Icon.ContextMenuStrip = Context_TaryIcon;   //트레이 아이콘
        }

        private void log_Path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowDialog();
            tb_Path.Text = folderBrowser.SelectedPath;
            Properties.Settings.Default.SuperPath = tb_Path.Text; //로컬 설정화
            GC.Collect();   //가비지 컬렉터
        }

        private void bt_logPath_Click(object sender, EventArgs e)
        {
            LogPathForm logForm = new LogPathForm();
            logForm.sLogPath = Properties.Settings.Default.LogPath;
            logForm.ShowDialog();
        }

        private void cb_AutoStart_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_AutoStart.Checked) autoStart.Start();
            else autoStart.Stop();
        }

        private void tb_Path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowDialog();
            tb_Path.Text = folderBrowser.SelectedPath;
            Properties.Settings.Default.SuperPath = tb_Path.Text; //로컬 설정화
            GC.Collect();   //가비지 컬렉터
        }
        private void Bt_Check_Click(object sender, EventArgs e) //Move to CheckList<Treeview>
        {
            rtb_log.AppendText($"[{DateTime.Now}] Get Directory info... PATH:{tb_Path.Text}");

            /*if (!MakeTreeView(tb_Path.Text)) MessageBox.Show("Try again");
            GC.Collect();   //가비지 컬렉터*/
        }
    }
}
