using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeleteFileController.Model.inter
{
    interface interTreeList
    {
        string path { get; set; }
        TreeView tree_Directory { get; set; }
        DirectoryInfo directoryInfo { get; set; }
        RichTextBox rtb_log { get; set; }

        bool MakeTreeView();
        void ListDictionary();
        TreeNode CreatedirectoryNode(DirectoryInfo directoryInfo);
    }
}
