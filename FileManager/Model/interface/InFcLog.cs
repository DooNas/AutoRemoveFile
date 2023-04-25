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
        RichTextBox LogBox { get; }

        public void LogRead();
        public string LogWrite(string message, int index);
        public string StrMessage(string Message, int index);
        public string FileWriter(DirectoryInfo di, FileInfo fi, string temp);
    }
}
