using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager.View
{
    interface InFcMain
    {
        List<string> DeleteDirList { get; set; }
        List<TreeNode>SuperCheckNodeList { get; set; }
    }
}
