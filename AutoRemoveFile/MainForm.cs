using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AutoRemoveFile
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            TrayIconAction();
        }
        LogController logController = new LogController();
        private string LogPath_set = Environment.CurrentDirectory;  //ㅣog저장 위치

        #region 트레이 아이콘
        private void TrayIconAction()
        {
            this.FormClosing += MainForm_FormClosing;
            this.Load += Tray_Icon_Load;
            Tray_Icon.MouseDoubleClick += Tray_Icon_MouseDoubleClick;
            sm_show.Click += Sm_show_Click;
            sm_exit.Click += Sm_exit_Click;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)//트레이아이콘으로
            {
                this.Hide();
                e.Cancel = true;
            }
        }
        private void Tray_Icon_Load(object sender, EventArgs e)
        {
            Tray_Icon.ContextMenuStrip = Context_TaryIcon;
        }
        private void Tray_Icon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar= true;
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
            Application.ExitThread();
        }

        #endregion

        #region 원하는 상위 디렉토리 기반으로 TreeView 구현
        private void tb_Path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowDialog();
            tb_Path.Text = folderBrowser.SelectedPath;
        }
        private void bt_Check_Click(object sender, EventArgs e)
        {
            logController.LogWrite(rtb_log, tb_Path.Text, 2, LogPath_set);
            DirectoryInfo di = new DirectoryInfo(tb_Path.Text);
            if (di.Exists)
            {
                ListDictionary(Tree_Directory, tb_Path.Text);
                logController.LogWrite(rtb_log, "", 3, LogPath_set);
            }
            else MessageBox.Show("Try again");
        }

        private void ListDictionary(System.Windows.Forms.TreeView tree_Directory, string text)
        {
            tree_Directory.Nodes.Clear();
            try
            {
                var rootDirectoryInfo = new DirectoryInfo(text);    //최상위 디렉토리 값 저장
                tree_Directory.Nodes.Add(CreatedirectoryNode(rootDirectoryInfo));
            }
            catch(Exception ex){logController.LogWrite(rtb_log, ex.Message, 1, LogPath_set); }
        }
        private TreeNode CreatedirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var dir in directoryInfo.GetDirectories()) {
                try{directoryNode.Nodes.Add(CreatedirectoryNode(dir)); }
                catch(Exception ex){logController.LogWrite(rtb_log, ex.Message, 1, LogPath_set); }
            }
            return directoryNode;
        }
        private void tvdir_AfterCheck(object sender, TreeViewEventArgs e)
        {
            var node = e.Node;
            var children = node.Nodes;
            for (int K = 0; K < children.Count; K++) { children[K].Checked = node.Checked; }
        }
        #endregion

        #region TreeView에서 선택한 경로를 Delete List로 연결
        private List<TreeNode> checkedNodes = new List<TreeNode>(); //삭제를 담당할 경로
        private void bt_Path_Click(object sender, EventArgs e)
        {
            checkedNodes.Clear();//초기화
            CheckedNodes(Tree_Directory.Nodes);
            AddListBox_DeletePath(checkedNodes);
        }
        private void CheckedNodes(TreeNodeCollection nodes)//재귀를 활용해서 자식까지 진행
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)checkedNodes.Add(node);
                else CheckedNodes(node.Nodes);
            }
        }
        private void AddListBox_DeletePath(List<TreeNode> nodes)
        {
            listb_deletePath.Items.Clear();
            foreach(TreeNode node in nodes)
            {
                string path = node.FullPath;
                listb_deletePath.Items.Add(path);
            }
        }
        #endregion

        #region DeleteList를 기준으로 ㅁ시간마다 ㅁ시간 경과된 폴더 제거
        #endregion

        #region 윈도우 부팅시 자동시작
        private void AutoStart(object sender, EventArgs e)
        {

        }

        #endregion
        #region log파일 저장경로 변경
        private void bt_logPath_Click(object sender, EventArgs e)
        {
            LogForm logForm = new LogForm();
            logForm.LogPath = LogPath_set;
            logForm.ShowDialog();
            LogPath_set = logForm.LogPath;
        }
        #endregion
    }
}
