using DeleteFileController.Model.inter;
using DeleteFileController.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteFileController.Presenter
{
    internal class PreAutoStart
    {
        readonly interMain view;
        readonly interAutoStart model;

        public PreAutoStart(interMain view, interAutoStart model)
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
