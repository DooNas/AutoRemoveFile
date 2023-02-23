using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoRemoveFile
{
    internal class TimeController
    {
        public System.Threading.Timer myTimer;

        public void T_start(TimerCallback callback, int starttime, int endtime)
        {
            myTimer = new System.Threading.Timer(callback, null, starttime*1000, endtime*1000);
        }

        public void T_stop()
        {
            myTimer.Dispose();
        }
    }
}
