using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager.Model.@interface
{
    interface InFcLog
    {
        string LogDirPath { get; set; }
        RichTextBox LogBox { get; set; }

        public void LogPrint(string message, int index);
        public string StrLogMessage(string message, int index);
    }
}
