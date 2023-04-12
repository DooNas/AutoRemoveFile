using DeleteFileController.Model.inter;
using DeleteFileController.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeleteFileController.Presenter
{
    internal class PreTreeList
    {
        readonly interMain view;
        readonly interTreeList model;

        public PreTreeList(interMain view, interTreeList model)
        {
            this.view = view;
            this.model = model;
        }

        private DirectoryInfo rootDirectoryInfo { get; set; }

        public bool MakeTreeView(RichTextBox rtb_log)
        {
            string path = view.SuperPath;
            if (path == string.Empty) return false;
            DirectoryInfo di = new DirectoryInfo(path);
            if (di.Exists)
            {
                ListDictionary(rtb_log);
                rtb_log.AppendText($"[{DateTime.Now}] Get Directory OK!");//LOG
                return true;
            }
            else return false;
        }
        private void ListDictionary(RichTextBox rtb_log)
        {
            view.tree_Directory.Nodes.Clear();//리셋
            try
            {
                rootDirectoryInfo = new DirectoryInfo(view.SuperPath);    //최상위 디렉토리 값 저장
                view.tree_Directory.Nodes.Add(CreatedirectoryNode(rootDirectoryInfo, rtb_log));
            }
            catch (Exception ex) { rtb_log.AppendText($"[{DateTime.Now}] {ex.Message}"); }//LOG
        }
        private TreeNode CreatedirectoryNode(DirectoryInfo directoryInfo, RichTextBox rtb_log)
        {
            var directoryNode = new TreeNode(rootDirectoryInfo.Name);
            foreach (var dir in rootDirectoryInfo.GetDirectories())
            {
                try { directoryNode.Nodes.Add(CreatedirectoryNode(dir, rtb_log)); }
                catch (Exception ex) { rtb_log.AppendText($"[{DateTime.Now}] {ex.Message}"); }//LOG
            }
            return directoryNode;
        }
    }
}
