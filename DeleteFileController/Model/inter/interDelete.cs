using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteFileController.Model.inter
{
    interface interDelete
    {
        public  Boolean IsEmptyFolder(String folder);
        public Boolean DeleteFolder(string folder, int daysOld);
    }
}
