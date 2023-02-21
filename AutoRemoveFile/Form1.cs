using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoRemoveFile
{
    public partial class Form1 : Form
    {
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
                var log = new Form1();
                log.rtb_log.AppendText(ex.ToString());
            }
        }
        private static TreeNode CreatedirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);

            foreach (var dir in directoryInfo.GetDirectories())
                try
                {
                    directoryNode.Nodes.Add(CreatedirectoryNode(dir));
                }
                catch (UnauthorizedAccessException ex)
                {
                    var log = new Form1();
                    log.rtb_log.AppendText(ex.ToString());
                }
            return directoryNode;
        }

        #endregion
    }
}
