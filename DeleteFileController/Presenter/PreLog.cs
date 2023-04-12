using DeleteFileController.Model.inter;
using DeleteFileController.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteFileController.Presenter
{
    internal class PreLog
    {
        readonly interMain view;
        readonly interLog model;

        public PreLog(interMain view, interLog model)
        {
            this.view = view;
            this.model = model;
        }
    }
}
