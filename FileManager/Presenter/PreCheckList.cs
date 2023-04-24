using FileManager.Model.@interface;
using FileManager.View.@interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Presenter
{
    internal class PreCheckList
    {
        readonly InFcMain view;
        readonly InFcCheckList model;
        readonly InFcLog log;
        public PreCheckList(InFcMain view, InFcCheckList model, InFcLog log)
        {
            this.view = view;
            this.model = model;
            model.SuperPath = Properties.Settings.Default.SuperPath;
            model.treeview = view.treeview;
        }
    }
}
