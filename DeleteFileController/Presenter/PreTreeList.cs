using DeleteFileController.Model.inter;
using DeleteFileController.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeleteFileController.Presenter
{
    internal class PreTreeList
    {
        readonly interMain view;
        readonly interTreeList model;

        public PreTreeList(interMain view, interTreeList model)
        {
            this.view = view;
            this.model = model;
        }

        public void MakeTreeList()
        {
            model.rtb_log = view.RichTextBox;
            model.path = view.SuperPath;

            model.rtb_log.AppendText($"[{DateTime.Now}] Get Directory info... PATH:{model.path}");
            if (!model.MakeTreeView()) MessageBox.Show("Try again");
            GC.Collect();   //가비지 컬렉터
        }
    }
}
