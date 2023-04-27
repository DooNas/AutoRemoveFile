using DeleteFileController;
using FileManager.Model;
using FileManager.Presenter;
using FileManager.View.@interface;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public partial class MainForm : Form, InFcMain
    {
        public RichTextBox LogBox => rtb_LogPrint;
        public ListBox DeleteListBox => ltb_deletList;
        public TreeView treeview => tv_superPath;

        public MainForm()
        {
            InitializeComponent();
            TrayIconAction();
            Shown += (sender, args) => Presenters();
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
        #region 설정창
        private void bt_Setting_Click(object sender, EventArgs e)
        /* 설정창 호출 */
        {
            SettingForm Settings = new SettingForm();
            Settings.FormClosing += Settings_FormClosing;
            Settings.ShowDialog();
        }
        private void Settings_FormClosing(object? sender, FormClosingEventArgs e)
        {
            CheckingTvLt.SuperPathToTreeView();
        }
        #endregion

        PreCheckList CheckingTvLt;
        PreDelete DeletingTarget;

        public void Presenters()
        {
            /* 삭제경로 지정 */
            CheckingTvLt = new PreCheckList(this, new MdCheckList(), new MdLog());
            CheckingTvLt.SuperPathToTreeView();

        }

        private void bt_restart_Click(object sender, EventArgs e)
        /* 수동 재시작 */
        {

        }
        private void bt_SavedeleteList_Click(object sender, EventArgs e)
        /* [삭제목록 저장] TreeView to ListBox */
        { CheckingTvLt.TreViewtoDeleteList(); }

        private void tv_superPath_AfterCheck(object sender, TreeViewEventArgs e)
        { CheckingTvLt.ControllerChildrenNode(e); }
    }
}
