using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeleteFileController.Model.inter
{
    interface interDelete
    {
        string folder { get; set; }
        int daysOld {get; set; }
        RichTextBox logtextbox { get; set; }

        public Boolean IsEmptyFolder(string folder);
        public Boolean DeleteFolder();
    }
}
