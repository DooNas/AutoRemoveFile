using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AutoRemoveFile
{
    internal class DeleteController
    {
        static RichTextBox rtextBox { get; set; }
        static string[] folderDir { get; set; }
        static int DeleteDay { get; set; }

        static int InterverHour { get; set; }

        public void Setting(string[] nfolderDir, RichTextBox nrtextBox, int nDeleteHour, int nInterverHour)
        {
            folderDir = nfolderDir;
            rtextBox = nrtextBox;
            DeleteDay = nDeleteHour / 24; //24시간 몫만 출력
            InterverHour = nInterverHour;
        }


        private static System.Threading.Timer CheckTimer;
        public void Interval_Delete(TimeSpan start, TimeSpan end)
        {
            CheckTimer = new System.Threading.Timer(
                deleteFolder,
                null,
                start,
                end
                );
        }


        public static void deleteFolder(object state)
        {
            LogController logcont = new LogController(); //로그 저장.
            for (int index = 0; index < folderDir.Length; index++)
            {
                try 
                { 
                    DirectoryInfo di = new DirectoryInfo(folderDir[index]);
                    if (di.Exists)
                    {
                        DirectoryInfo[] dirInfo = di.GetDirectories();
                        string IDate = DateTime.Today.AddDays(-DeleteDay).ToString("yyyyMMDD");

                        foreach(DirectoryInfo dir in dirInfo)
                        {
                            if(IDate.CompareTo(dir.LastWriteTime.ToString("yyyyMMdd")) > 0)
                            {
                                dir.Attributes = FileAttributes.Normal;
                                dir.Delete(true);
                            }
                        }
                    }
                }
                catch (Exception ex) { logcont.LogWrite(rtextBox, ex.Message, 4); }
            }
            GC.Collect();
            CheckTimer.Change(TimeSpan.FromSeconds(InterverHour), TimeSpan.FromSeconds(InterverHour));
            logcont.LogWrite(rtextBox, InterverHour.ToString(), 5);
        }
    }
}
