using FileManager.Model.@interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Model
{
    internal class MdDelete : InFcDelete
    {
        public int interval 
        {
            get => Properties.Settings.Default.Interval_Hour;
            set => Properties.Settings.Default.Interval_Hour = value;
        }
        public int LastUpHours 
        {
            get => Properties.Settings.Default.Standard_Day;
            set => Properties.Settings.Default.Standard_Day = value; 
        }
        public List<string> DeleteDirList
        /* 주기적으로 삭제할 경로 리스트 */
        {
            get
            {
                if (Properties.Settings.Default.DeletePath != "")
                    return Properties.Settings.Default.DeletePath.Split('|').ToList<string>();
                else return new List<string>();
            }
        }
    }
}
