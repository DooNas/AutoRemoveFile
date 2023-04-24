using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager.Model.@interface
{
    interface InFcCheckList
    {
        string SuperPath { get; set; }
        List<string> DeleteDirList { get; set; }
        List<TreeNode> CheckedNodes { get; set; }
        TreeView treeview { get; set; }
        ListBox DeleteListBox { get; set; }
        void ListRefresh();
        void NodeChecking(TreeNodeCollection nodeList);
        void AddDeleteList(List<TreeNode> nodeList);
    }
}
