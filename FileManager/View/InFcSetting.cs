using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.View
{
    interface InFcSetting
    {
        string SuperPath { get; set; }
        string LogPath { get; set; }
        int interval { get; set; }
        int StandardDay { get; set; }
        bool AutoStart { get; set; }
    }
}
