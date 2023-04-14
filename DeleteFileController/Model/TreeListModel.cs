using DeleteFileController.Model.inter;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DeleteFileController.Model
{
    internal class TreeListModel : interTreeList
    {
        [DisallowNull]  
        public string path { get; set; }
        public TreeView tree_Directory { get; set; }
        public DirectoryInfo directoryInfo { get; set; }
        public RichTextBox rtb_log { get; set; }

        public TreeNode CreatedirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var dir in directoryInfo.GetDirectories())
            {
                try { directoryNode.Nodes.Add(CreatedirectoryNode(dir)); }
                catch (Exception ex) { rtb_log.AppendText($"[{DateTime.Now}] The deletion failed: {ex.Message}"); }
            }
            return directoryNode;
        }

        public void ListDictionary()
        {
            tree_Directory.Nodes.Clear();//리셋
            try
            {
                directoryInfo = new DirectoryInfo(path);    //최상위 디렉토리 값 저장
                tree_Directory.Nodes.Add(CreatedirectoryNode(directoryInfo));
            }
            catch (Exception ex) { rtb_log.AppendText($"[{DateTime.Now}] The deletion failed: {ex.Message}"); }
        }

        public bool MakeTreeView()
        {
            if (path == string.Empty) return false;
            DirectoryInfo di = new DirectoryInfo(path);
            if (di.Exists)
            {
                ListDictionary();
                rtb_log.AppendText($"[{DateTime.Now}] Get Directory OK!");
                return true;
            }
            else return false;
        }
    }
}
