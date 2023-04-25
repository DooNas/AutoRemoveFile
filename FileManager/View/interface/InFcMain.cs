using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager.View.@interface
{
    interface InFcMain
    {
        TreeView treeview { get; }
        ListBox DeleteListBox { get; }
        RichTextBox LogBox { get; }
    }
}
