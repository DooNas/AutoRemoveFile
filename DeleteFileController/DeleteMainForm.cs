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
        public List<TreeNode> SuperPathChild { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<string> DeleteDirList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IntervalHours { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int OldDayDelete { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool AutoStart { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TreeView tree_Directory { get => this.Tree_Directory; set => throw new NotImplementedException(); }

        public DeleteMainForm()
        {
            InitializeComponent();
            TrayIconAction();
            this.Load += Main_Load;

        }
        private PreAutoStart autoStart;
        private void PresenterList()
        {
            //윈도우 부팅시
            autoStart = new PreAutoStart(this, new AutoStartModel());
            cb_AutoStart.Checked = autoStart.CheckAuto();

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

        private void cb_AutoStart_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_AutoStart.Checked) autoStart.Start();
            else autoStart.Stop();
        }
    }
}
