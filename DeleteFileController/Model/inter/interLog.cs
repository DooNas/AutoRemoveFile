using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeleteFileController.Model.inter 
{ 
    interface interLog
    {
        string LogDirPath { get; set; }
        string LogFilePath { get; set; }

        RichTextBox logTextBox { get; set; }

        public void LogRead();
    }
}
