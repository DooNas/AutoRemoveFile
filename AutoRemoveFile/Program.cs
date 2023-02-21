using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoRemoveFile
{
    internal static class Program
    {
        static int IInterval;
        private static System.Threading.Timer CheckTimer;
        static string[] deletepath;
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void DelFile(object state) 
        {

        }
    }
}
