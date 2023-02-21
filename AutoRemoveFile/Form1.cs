using System;
using System.IO;
using System.Windows.Forms;

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
            else MessageBox.Show("없는 경로입니다.");
        }
        private void ListDictionary(TreeView treeview, string path)
        {
            treeview.Nodes.Clear();
            try
            {
                var rootDirectoryInfo = new DirectoryInfo(path);    //최상위 디렉토리 값 저장
                treeview.Nodes.Add(CreatedirectoryNode(rootDirectoryInfo));
            }
            catch(ArgumentException ex)
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


    }
}
