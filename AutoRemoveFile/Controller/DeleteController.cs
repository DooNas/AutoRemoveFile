using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AutoRemoveFile
{
    internal class DeleteController
    {
        static string[] folderDir { get; set; }
        static int DeleteHour { get; set; }
        static int InterverHour { get; set; }

        public void Setting(string[] nfolderDir,int nDeleteHour, int nInterverHour)
        {
            folderDir = nfolderDir;
            DeleteHour = nDeleteHour; //24시간 몫만 출력
            InterverHour = nInterverHour;
        }
        static LogController logcont = new LogController(); //로그 저장.

        private static System.Threading.Timer CheckTimer;
        public void Interval_Delete()
        {
            CheckTimer = new System.Threading.Timer(
                DelFile,
                null,
                TimeSpan.FromSeconds(0),
                TimeSpan.FromSeconds(InterverHour * 3600)
                );
        }
        private static void DelFile(object state)
        {
            CheckTimer.Change(Timeout.Infinite, Timeout.Infinite); 
            logcont.LogWrite("", 0);

            try
            {
                string[] deletePath = folderDir;
                foreach (string path in deletePath)
                {
                    DirectoryInfo di = new DirectoryInfo(path);
                    if (di.Exists)
                    {
                        logcont.LogWrite( path, 2);
                        DirectoryInfo[] dirInfo = di.GetDirectories("*", SearchOption.AllDirectories);
                        logcont.LogWrite("", 3);
                        string lData = DateTime.Now.AddHours(-DeleteHour).ToString("yyyy-MM-dd hh:mm:ss");
                        foreach (DirectoryInfo dir in dirInfo.Reverse())
                        {
                            if (lData.CompareTo(dir.LastWriteTime.ToString("yyyy-MM-dd hh:mm:ss")) > 0)
                            {
                                try
                                {
                                    logcont.LogWrite(dir.FullName, 4);
                                    dir.Delete(true);

                                }
                                catch (Exception ex) { logcont.LogWrite(ex.Message, 4); }
                                GC.Collect();
                                Thread.Sleep(20);
                            }
                        }
                    }
                    else { logcont.LogWrite("Specified file doesn't exist", 0); }
                    GC.Collect();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            GC.Collect();
            CheckTimer.Change(TimeSpan.FromSeconds(InterverHour * 3600), TimeSpan.FromSeconds(InterverHour * 3600));
            logcont.LogWrite((InterverHour * 3600).ToString(), 5);
        }
    }
}
