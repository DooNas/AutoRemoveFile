using System;
using System.IO;
using System.Windows.Forms;

namespace AutoRemoveFile
{
    public partial class Form1 : Form
    {
        string log = "";
        public Form1()
        {
            InitializeComponent();
        }
        
        private void tb_Path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowDialog();
            tb_Path.Text = folderBrowser.SelectedPath;
            ListDictionary(Tree_Directory, folderBrowser.SelectedPath);
            rtb_log.AppendText(log);
        }
        #region TreeView를 활용한 디렉토리 확인
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
                log += ex.ToString() + "\n";
            }
        }
        private TreeNode CreatedirectoryNode(DirectoryInfo directoryInfo)
        {
            Form1 form = new Form1();
            var directoryNode = new TreeNode(directoryInfo.Name);

            foreach (var dir in directoryInfo.GetDirectories())
                try
                {
                    directoryNode.Nodes.Add(CreatedirectoryNode(dir));
                }
                catch (UnauthorizedAccessException ex)
                {
                    log += ex.ToString() + "\n";
                } 
            return directoryNode;
        }
        #endregion
    }
}
