using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AutoRemoveFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
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

        #endregion


        private List<TreeNode> checkedNodes = new List<TreeNode>();

        private void button1_Click(object sender, EventArgs e)
        {
            checkedNodes.Clear();//초기화
            CheckedNodes(Tree_Directory.Nodes);
        }
        private void CheckedNodes(TreeNodeCollection nodes)//재귀를 활용해서 자식까지 진행
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)checkedNodes.Add(node);
                else CheckedNodes(node.Nodes);
            }
        }


    }
}
