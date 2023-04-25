using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager.Model.@interface
{
    interface InFcCheckList
    {
        string SuperPath { get; }
        List<string> DeleteDirList { get; set; }
        List<TreeNode> CheckedNodesList { get; }
        TreeView treeview { get; set; }
        ListBox DeleteListBox { get; set; }
        void ListRefresh();
        void NodeChangeCheck(TreeNodeCollection nodeList);
        void AddDeleteList(List<TreeNode> nodeList);

        bool MakeTreeView();
        TreeNode CreatedirectoryNode(DirectoryInfo directoryInfo);
    }
}
