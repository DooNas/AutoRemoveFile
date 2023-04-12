using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeleteFileController.View
{
    interface interMain
    {
        [DisallowNull]
        string SuperPath { get; set; }

        [DisallowNull]
        List<TreeNode> SuperPathChild { get; set; }

        [DisallowNull]
        List<string> DeleteDirList { get; set; }

        int IntervalHours { get; set; }
        int OldDayDelete { get; set; }
        bool AutoStart { get; set; }
    }
}
