using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AutoRemoveFile
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Load += Main_Load;
            Application.Idle += Application_Idle;
            TrayIconAction();
        }


        LogController logController = new LogController();
        StartController autoStart = new StartController();//자동실행
        String[] DeleteDirList;

        private void Main_Load(object sender, EventArgs e)
        {
            tb_Path.Text = Properties.Settings.Default.DirPath;
            Tray_Icon.ContextMenuStrip = Context_TaryIcon;

            if (autoStart.GetKey.GetValue("AutoRemoveFile") == null) cb_AutoStart.Checked = false;
            else cb_AutoStart.Checked = true;

            if(Properties.Settings.Default.DeleteListPath != string.Empty)
            {
                DeleteDirList = Properties.Settings.Default.DeleteListPath.Split('|');
                foreach(string path in DeleteDirList) listb_deletePath.Items.Add(path);
            }
            GC.Collect();   //가비지 컬렉터
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
        private void tb_Path_Click(object sender, EventArgs e) //Find Main Path
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowDialog();
            tb_Path.Text = folderBrowser.SelectedPath;
            Properties.Settings.Default.DirPath = tb_Path.Text; //로컬 설정화
            GC.Collect();   //가비지 컬렉터
        }
        private void bt_Check_Click(object sender, EventArgs e) //Move to CheckList<Treeview>
        {
            logController.LogWrite(rtb_log, tb_Path.Text, 2);
            DirectoryInfo di = new DirectoryInfo(tb_Path.Text);
            if (di.Exists)
            {
                ListDictionary(Tree_Directory, tb_Path.Text);
                logController.LogWrite(rtb_log, "", 3);
            }
            else MessageBox.Show("Try again");
            GC.Collect();   //가비지 컬렉터
        }
        private void tvdir_AfterCheck(object sender, TreeViewEventArgs e) //Check with children Nodes
        {
            var node = e.Node;
            var children = node.Nodes;
            for (int K = 0; K < children.Count; K++) { children[K].Checked = node.Checked; }
        }
        
        ////For Make TreeView////
        private void ListDictionary(System.Windows.Forms.TreeView tree_Directory, string text)
        {
            tree_Directory.Nodes.Clear();
            try
            {
                var rootDirectoryInfo = new DirectoryInfo(text);    //최상위 디렉토리 값 저장
                tree_Directory.Nodes.Add(CreatedirectoryNode(rootDirectoryInfo));
            }
            catch(Exception ex){logController.LogWrite(rtb_log, ex.Message, 1); }
        }
        private TreeNode CreatedirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var dir in directoryInfo.GetDirectories()) {
                try{directoryNode.Nodes.Add(CreatedirectoryNode(dir)); }
                catch(Exception ex){logController.LogWrite(rtb_log, ex.Message, 1); }
            }
            return directoryNode;
        }
        ////////////////////////

        #endregion

        #region TreeView에서 선택한 경로를 Delete List로 연결
        private List<TreeNode> checkedNodes = new List<TreeNode>(); //삭제를 담당할 경로
        private void bt_Path_Click(object sender, EventArgs e)
        {
            checkedNodes.Clear();//초기화
            CheckedNodes(Tree_Directory.Nodes);
            AddListBox_DeletePath(checkedNodes);
            GC.Collect();   //가비지 컬렉터
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
            Properties.Settings.Default.DeleteListPath = string.Empty;
            foreach (TreeNode node in nodes)
            {
                string path = node.FullPath;
                Properties.Settings.Default.DeleteListPath += path + "|";
                listb_deletePath.Items.Add(path);
            }
        }
        #endregion

        #region DeleteList를 기준으로 ㅁ시간마다 ㅁ시간 경과된 폴더 제거

        #endregion

        #region 윈도우 부팅시 자동시작
        private void AutoStart(object sender, EventArgs e)
        {
            if (cb_AutoStart.Checked)
            {
                autoStart.SetAuto();
                Properties.Settings.Default.MainForm = true;
            }
            else {
                autoStart.DeleteAuto();
                Properties.Settings.Default.MainForm = false;
            }
        }
        private void Application_Idle(object sender, EventArgs e)
        {
            Application.Idle -= Application_Idle;
            if (cb_AutoStart.Checked) this.Hide();
        }
        #endregion

        #region log파일 저장경로 변경
        private void bt_logPath_Click(object sender, EventArgs e)
        {
            LogForm logForm = new LogForm();
            logForm.LogPath = Properties.Settings.Default.LogPath;
            logForm.ShowDialog();
            Properties.Settings.Default.LogPath = logForm.LogPath;
        }
        #endregion

        #region setting파일로 로컬피시에 설정 값 저장        
        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            MessageBox.Show("Save!!");
        }
    #endregion


    }
}
