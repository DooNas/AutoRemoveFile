using DeleteFileController.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeleteFileController
{
    public partial class DeleteMainForm : Form, interMain
    {
        public string SuperPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<TreeNode> SuperPathChild { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<string> DeleteDirList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IntervalHours { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int OldDayDelete { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool AutoStart { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public DeleteMainForm()
        {
            InitializeComponent();
            TrayIconAction();

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
    }
}
