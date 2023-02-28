using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AutoRemoveFile
{
    public partial class MainForm : Form
    {
        private static List<string> DeleteDirList; //삭제폴더 리스트
        public MainForm()
        {
            InitializeComponent();

            this.Load += Main_Load;
            Application.Idle += Application_Idle;//온로드 오류 대비
            TrayIconAction();//트레이 아이콘
        }

        StartController autoStart = new StartController();//자동실행
        DeleteController dtcontroller = new DeleteController();//폴더삭제

        private void Main_Load(object sender, EventArgs e)
        {
            //트레이 아이콘
            Tray_Icon.ContextMenuStrip = Context_TaryIcon;

            //자동 시작
            if (autoStart.GetKey.GetValue("AutoRemoveFile") == null) cb_AutoStart.Checked = false;
            else cb_AutoStart.Checked = true;

            //setting.setting파일 호출
            tb_lastupdate.Text = Properties.Settings.Default.LastUpdate_h.ToString();
            tb_Time.Text = Properties.Settings.Default.Interval_h.ToString();
            tb_Path.Text = Properties.Settings.Default.DirPath;

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
            Application.ExitThread();   //완전 종료
        }
        #endregion

        #region 원하는 상위 디렉토리 기반으로 TreeView 구현
        private void Tb_Path_Click(object sender, EventArgs e) //Find Main Path
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowDialog();
            tb_Path.Text = folderBrowser.SelectedPath;
            Properties.Settings.Default.DirPath = tb_Path.Text; //로컬 설정화
            GC.Collect();   //가비지 컬렉터
        }
        private void Bt_Check_Click(object sender, EventArgs e) //Move to CheckList<Treeview>
        {
            rtb_log.AppendText(LogController.LogWrite(tb_Path.Text, 2));

            if (!MakeTreeView(tb_Path.Text)) MessageBox.Show("Try again");
            GC.Collect();   //가비지 컬렉터
        }
        private void Tvdir_AfterCheck(object sender, TreeViewEventArgs e) //Check with children Nodes
        {
            var node = e.Node;
            var children = node.Nodes;
            for (int K = 0; K < children.Count; K++) { children[K].Checked = node.Checked; }
        }
        
        ////For Make TreeView////
        private bool MakeTreeView(string path)
        {
            if (path == string.Empty) return false;
            DirectoryInfo di = new DirectoryInfo(path);
            if (di.Exists)
            {
                ListDictionary(Tree_Directory, tb_Path.Text);
                rtb_log.AppendText(LogController.LogWrite("", 3));
                return true;
            }
            else return false;
        }
        private void ListDictionary(System.Windows.Forms.TreeView tree_Directory, string text)
        {
            tree_Directory.Nodes.Clear();//리셋
            try
            {
                var rootDirectoryInfo = new DirectoryInfo(text);    //최상위 디렉토리 값 저장
                tree_Directory.Nodes.Add(CreatedirectoryNode(rootDirectoryInfo));
            }
            catch(Exception ex){ rtb_log.AppendText(LogController.LogWrite(ex.Message, 1)); }
        }
        private TreeNode CreatedirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var dir in directoryInfo.GetDirectories()) {
                try { directoryNode.Nodes.Add(CreatedirectoryNode(dir)); }
                catch (Exception ex) { rtb_log.AppendText(LogController.LogWrite(ex.Message, 1)); }
            }
            return directoryNode;
        }
        ////////////////////////

        #endregion

        #region TreeView에서 선택한 경로를 Delete List로 연결
        private List<TreeNode> checkedNodes = new List<TreeNode>(); //삭제를 담당할 경로
        private void Bt_Path_Click(object sender, EventArgs e)
        {
            checkedNodes.Clear();//초기화
            Properties.Settings.Default.DeleteListPath = string.Empty;
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
            string path = string.Empty;
            foreach (TreeNode node in nodes)
            {
                string[] Node_path = node.FullPath.ToString().Split('\\');
                if(Node_path.Length > 1)
                {
                    for (int index = 1; index < Node_path.Length; index++)
                    {
                        path = tb_Path.Text + "\\" + Node_path[index];
                    }
                }else { path = tb_Path.Text; }
                
                listb_deletePath.Items.Add(path);
            }
            DeleteDirList = listb_deletePath.Items.OfType<string>().ToList();

        }
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
        private void Application_Idle(object sender, EventArgs e)   //실행후 진행
        {
            Application.Idle -= Application_Idle;//delete Event
            if (cb_AutoStart.Checked) this.Hide();

            MakeTreeView(tb_Path.Text);

            if (Properties.Settings.Default.DeleteListPath != string.Empty)
            {
                DeleteDirList = Properties.Settings.Default.DeleteListPath.Split('|').ToList();
                foreach (string path in DeleteDirList) listb_deletePath.Items.Add(path);
            }

            dtcontroller.Set(
                DeleteDirList,
                int.Parse(tb_lastupdate.Text),
                int.Parse(tb_Time.Text));
            dtcontroller.Interval_Delete();

            GC.Collect();   //가비지 컬렉터
        }
        #endregion

        #region log파일 저장경로 변경 
        private void Bt_logPath_Click(object sender, EventArgs e)
        {
            LogForm logForm = new LogForm();
            logForm.sLogPath = Properties.Settings.Default.LogPath;
            logForm.ShowDialog();
        }
        #endregion

        #region setting파일로 로컬피시에 설정 값 저장
        private void BtSave_Click(object sender, EventArgs e)
        {
            //시간
            Properties.Settings.Default.LastUpdate_h = int.Parse(tb_lastupdate.Text);
            Properties.Settings.Default.Interval_h = int.Parse(tb_Time.Text);

            //삭제 리스트
            Properties.Settings.Default.DeleteListPath = string.Empty;//초기화
            foreach (string path in DeleteDirList) Properties.Settings.Default.DeleteListPath += path + "|";
            Properties.Settings.Default.DeleteListPath.TrimEnd('|');


            Properties.Settings.Default.Save();
            MessageBox.Show("Save!!"); 

            //혹시모를 변동사항을 대비하여 업데이트 진행
            dtcontroller.Set(
                DeleteDirList, 
                int.Parse(tb_lastupdate.Text),
                int.Parse(tb_Time.Text)
                );
            dtcontroller.Interval_Delete();
            GC.Collect();   //가비지 컬렉터
        }
        #endregion

        private void Bt_LoadLog_Click(object sender, EventArgs e)
        {
            LogController.LogRead(rtb_log);
        }
    }
}
