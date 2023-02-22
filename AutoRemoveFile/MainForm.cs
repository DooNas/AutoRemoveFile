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
            this.Load += Tray_Icon_Load;
            Tray_Icon.MouseDoubleClick += Tray_Icon_MouseDoubleClick;
        }
        #region 트레이 아이콘
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
            DirectoryInfo di = new DirectoryInfo(tb_Path.Text);
            if(di.Exists)  ListDictionary(Tree_Directory, tb_Path.Text);
            else MessageBox.Show("try again");
        }

        private void ListDictionary(System.Windows.Forms.TreeView tree_Directory, string text)
        {
            tree_Directory.Nodes.Clear();
            try
            {
                var rootDirectoryInfo = new DirectoryInfo(text);    //최상위 디렉토리 값 저장
                tree_Directory.Nodes.Add(CreatedirectoryNode(rootDirectoryInfo));
            }
            catch (ArgumentException ex)
            {
                rtb_log.AppendText(ex.ToString());
            }
        }
        private TreeNode CreatedirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);

            foreach (var dir in directoryInfo.GetDirectories()) {
                try
                {
                    directoryNode.Nodes.Add(CreatedirectoryNode(dir));
                }
                catch (UnauthorizedAccessException ex)
                {
                    rtb_log.AppendText(ex.ToString());
                }
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
        private List<TreeNode> checkedNodes = new List<TreeNode>();
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

        #region 윈도우 부팅시 자동시작
        private void AutoStart(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
