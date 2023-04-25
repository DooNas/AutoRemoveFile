using FileManager.Model.@interface;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace FileManager.Model
{
    internal class MdCheckList : InFcCheckList
    {
        private List<TreeNode> checkedNodes = new List<TreeNode>(); //선택된 경로들 임시 저장
        public string SuperPath
        /* 최상위 경로 */
        { 
            get => Properties.Settings.Default.SuperPath; 
            set => Properties.Settings.Default.SuperPath = value;
        }

        public List<string> DeleteDirList
        /* 주기적으로 삭제할 경로 리스트 */
        { 
            get 
            {
                if(Properties.Settings.Default.DeletePath != "")
                    return Properties.Settings.Default.DeletePath.Split('|').ToList<string>();
                else return new List<string>();
            } 
            set 
            {
                Properties.Settings.Default.DeletePath = string.Empty;
                foreach (string path in value) Properties.Settings.Default.DeletePath += $"{path}|";
                Properties.Settings.Default.DeletePath.TrimEnd('|');
                Properties.Settings.Default.Save();
            } 
        }
        public List<TreeNode> CheckedNodesList => checkedNodes;
        /* TreeView을 통해 체크된 삭제할 경로들 */
        public TreeView treeview { get; set; }
        /* MainForm의 TreeViewBox */
        public ListBox DeleteListBox { get; set; }
        /* DeleteDirList의 목록을 띄어놓기 위한 ListBox */


        #region TreeView to ListBox
        public void ListRefresh()
        /* 삭제할 경로들 최신화 */
        {
            checkedNodes.Clear();//초기화
            NodeChangeCheck(treeview.Nodes);  //하위노드들 체크상태 반전
            AddDeleteList(CheckedNodesList);//
        }

        public void AddDeleteList(List<TreeNode> nodes)
        /* 삭제할 경로 DeleteDirList에 추가 */
        {
            DeleteListBox.Items.Clear();
            string path = string.Empty;
            foreach (TreeNode node in nodes)
            {
                string[] Node_path = node.FullPath.ToString().Split('\\');
                if (Node_path.Length > 1)
                {
                    for (int index = 1; index < Node_path.Length; index++) 
                        path = SuperPath + "\\" + Node_path[index];
                }
                else { path = SuperPath; }
                DeleteListBox.Items.Add(path);
            }
            DeleteDirList = DeleteListBox.Items.OfType<string>().ToList();
        }

        public void NodeChangeCheck(TreeNodeCollection nodes)
        /* 상위 Node를 체크할 경우 하위 Node들도 자동 체크 */
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked) checkedNodes.Add(node);
                else NodeChangeCheck(node.Nodes);
            }
        }
        #endregion


        #region SuperPath to TreeView
        public bool MakeTreeView()
        {
            if (SuperPath == string.Empty) return false;
            foreach(string DeletePath in DeleteDirList) DeleteListBox.Items.Add(DeletePath);
            DirectoryInfo di = new DirectoryInfo(SuperPath); //최상위 디렉토리 값 저장
            if (di.Exists)
            {
                treeview.Nodes.Clear(); //리셋
                try { treeview.Nodes.Add(CreatedirectoryNode(di)); }
                catch (Exception) { }
                return true;
            }
            else return false;
        }
        public TreeNode CreatedirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var dir in directoryInfo.GetDirectories())
            {
                try { directoryNode.Nodes.Add(CreatedirectoryNode(dir)); }
                catch (Exception) { }
            }
            return directoryNode;
        }
        #endregion
    }
}
