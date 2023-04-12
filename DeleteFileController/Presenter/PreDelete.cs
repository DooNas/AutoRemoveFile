﻿using DeleteFileController.Model.inter;
using DeleteFileController.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }

        void Delete()
        {
            foreach(string path in view.DeleteDirList)
            {
                model.DeleteFolder(path, view.OldDayDelete);
            }
        }
    }
}
