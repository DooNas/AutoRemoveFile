using FileManager.Model.@interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FileManager.Model
{
    internal class MdCheckList : InFcCheckList
    {
        public string SuperPath /* 최상위 경로 */
        { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<string> DeleteDirList /* 주기적으로 삭제할 경로 리스트 */
        { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ListBox DeleteListBox /* DeleteDirList의 목록을 띄어놓기 위한 ListBox */
        { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<TreeNode> CheckedNodes /* TreeView을 통해 체크된 삭제할 경로들 */
        { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TreeView treeview/* MainForm의 TreeView */
        { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ListRefresh()/* 삭제할 경로들 최신화 */
        {
            CheckedNodes.Clear();//초기화
            Properties.Settings.Default.DeletePath = string.Empty;
            NodeChecking(treeview.Nodes);
            AddDeleteList(CheckedNodes);
        }

        public void AddDeleteList(List<TreeNode> nodes)/* 삭제할 경로 DeleteDirList에 추가 */
        {
            DeleteListBox.Items.Clear();
            string path = string.Empty;
            foreach (TreeNode node in nodes)
            {
                string[] Node_path = node.FullPath.ToString().Split('\\');
                if (Node_path.Length > 1)
                {
                    for (int index = 1; index < Node_path.Length; index++) path = SuperPath + "\\" + Node_path[index];
                }
                else { path = SuperPath; }
                DeleteListBox.Items.Add(path);
            }
            DeleteDirList = DeleteListBox.Items.OfType<string>().ToList();
        }

        public void NodeChecking(TreeNodeCollection nodes)/* 상위 Node를 체크할 경우 하위 Node들도 자동 체크 */
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked) CheckedNodes.Add(node);
                else NodeChecking(node.Nodes);
            }
        }
    }
}
