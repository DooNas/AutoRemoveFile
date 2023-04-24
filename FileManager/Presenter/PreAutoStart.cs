using FileManager.Model.@interface;
using FileManager.View.@interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Presenter
{
    internal class PreAutoStart
    {
        readonly InFcSetting view;
        readonly InFcAutoStart model;

        public PreAutoStart(InFcSetting view, InFcAutoStart model)
        {
            this.view = view;
            this.model = model;
            this.model.APPLICATION_NAME = this.view.APPLICATION_NAME;
        }

        public void Start()
        {
            model.SetAuto();
        }

        public void Stop()
        {
            model.DeleteAuto();
        }

        internal bool CheckAuto()
        {
            return model.CheckAuto();
        }
    }
}
