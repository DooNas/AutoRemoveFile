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
        static RichTextBox rtextBox { get; set; }
        static string[] folderDir { get; set; }
        static int DeleteHour { get; set; }
        static int InterverHour { get; set; }

        public void Setting(string[] nfolderDir, RichTextBox nrtextBox, int nDeleteHour, int nInterverHour)
        {
            folderDir = nfolderDir;
            rtextBox = nrtextBox;
            DeleteHour = nDeleteHour; //24시간 몫만 출력
            InterverHour = nInterverHour;
        }


        private static System.Threading.Timer CheckTimer;
        public void Interval_Delete()
        {
            CheckTimer = new System.Threading.Timer(
                deleteFolder,
                null,
                TimeSpan.FromSeconds(0),
                TimeSpan.FromSeconds(InterverHour * 3600)
                );
            //deleteFolder(null);
        }

        public static void deleteFolder(object state)
        {
            CheckTimer.Change(Timeout.Infinite, Timeout.Infinite);
            LogController logcont = new LogController(); //로그 저장.
            try
            {
                for (int index = 0; index < folderDir.Length; index++)
                {
                
                    DirectoryInfo di = new DirectoryInfo(folderDir[index]);
                    if (di.Exists)
                    {
                        DirectoryInfo[] dirInfo = di.GetDirectories();
                        string IDate = DateTime.Today.AddHours(-DeleteHour).ToString("yyyy-MM-dd hh:mm:ss");

                        foreach(DirectoryInfo dir in dirInfo)
                        {
                            if(IDate.CompareTo(dir.LastWriteTime.ToString("yyyy-MM-dd hh:mm:ss")) > 0)
                            {
                                try
                                {
                                    dir.Attributes = FileAttributes.Normal;
                                    dir.Delete(true);
                                }
                                catch (Exception ex) { logcont.LogWrite(rtextBox, ex.Message, 4); }
                                GC.Collect();
                                Thread.Sleep(20);
                            }
                        }
                    }
                    else
                    {
                        logcont.LogWrite(rtextBox, "Specified file doesn't exist", 0);
                    }
                    GC.Collect();
                }
            } catch (Exception ex) { logcont.LogWrite(rtextBox, ex.Message, 4); }
            GC.Collect();
            CheckTimer.Change(TimeSpan.FromSeconds(InterverHour), TimeSpan.FromSeconds(InterverHour));
            logcont.LogWrite(rtextBox, InterverHour.ToString(), 5);
        }
    }
}
