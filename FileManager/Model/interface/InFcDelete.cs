using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Model.@interface
{
    interface InFcDelete
    {
        int interval { get; set; }
        int LastUpHours { get; set; }
        List<string> DeleteDirList { get; }
    }
}
