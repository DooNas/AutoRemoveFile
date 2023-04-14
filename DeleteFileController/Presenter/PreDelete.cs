using DeleteFileController.Model.inter;
using DeleteFileController.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeleteFileController.Presenter
{
    internal class PreDelete
    {
        readonly interMain view;
        readonly interDelete model;

        public PreDelete(in interMain view, interDelete model)
        {
            this.view = view;
            this.model = model;
            model.logtextbox = view.RichTextBox;
        }

        public async Task CheckFileToDelete(CancellationToken IsWorking)
        {
            while (!IsWorking.IsCancellationRequested)
            {
                Delete();
                try { await Task.Delay(view.IntervalHours * 1000 * 60 * 60, IsWorking); }
                catch (TaskCanceledException) { break; }
            }
        }


        void Delete()
        {
            model.daysOld = view.OldDayDelete;  //기준
            foreach(string path in view.DeleteDirList)
            {
                model.folder = path;
                model.DeleteFolder();
            }
        }
    }
}
