using DeleteFileController;
using FileManager.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public partial class MainForm : Form, InFcMain
    {
        public List<string> DeleteDirList {  get; set; }
        public List<TreeNode> SuperCheckNodeList { get; set; }


        public MainForm()
        {
            InitializeComponent();
            TrayIconAction();
        }

        #region 트레이 아이콘
        private void TrayIconAction() //Events
        {
            this.FormClosing += MainForm_FormClosing;
            nfIcon.MouseDoubleClick += Tray_Icon_MouseDoubleClick;
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

        private void bt_Setting_Click(object sender, EventArgs e)/* 설정창 호출 */
        {
            SettingForm Settings = new SettingForm();
            Settings.ShowDialog();
        }

        private void bt_restart_Click(object sender, EventArgs e)/* 수동 재시작 */
        {

        }
        private void bt_SavedeleteList_Click(object sender, EventArgs e)/* [삭제목록 저장] TreeView to ListBox */
        {

        }
    }
}
