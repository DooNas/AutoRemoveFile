using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace AutoRemoveFile
{
    internal class DeleteController
    {
        private static string[] folderDir { get; set; }
        private static int DeleteHour { get; set; }
        private static int InterverHour { get; set; }

        public void Set(string[] nfolderDir,int nDeleteHour, int nInterverHour)
        {
            folderDir = nfolderDir;
            DeleteHour = nDeleteHour;
            InterverHour = nInterverHour;
        }

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
            LogController.LogWrite("", 0);

            try
            {
                string[] deletePath = folderDir;
                foreach (string path in deletePath)
                {
                    LogController.LogWrite(path, 2); //Connecting..logMake
                    DirectoryInfo di = new DirectoryInfo(path);
                    LogController.LogWrite("", 3);//Connected logMake
                    if (di.Exists)
                    {
                        DirectoryInfo[] dirInfo = di.GetDirectories();
                        string lData = DateTime.Now.AddHours(-DeleteHour).ToString("yyyy-MM-dd hh:mm:ss");

                        if (dirInfo.Length > 0)//하위 디렉토리 밑에도 추가적으로 있는 경우
                        {
                            foreach (DirectoryInfo dir in dirInfo.Reverse())
                            {
                                if (lData.CompareTo(dir.LastWriteTime.ToString("yyyy-MM-dd hh:mm:ss")) > 0)
                                {
                                    try
                                    {
                                        LogController.LogWrite(dir.FullName, 4);
                                        dir.Delete(true);

                                    }
                                    catch (Exception ex) { LogController.LogWrite(ex.Message, 4); }
                                    GC.Collect();
                                    Thread.Sleep(20);
                                }
                            }
                        }
                        else//하위 디렉토리 밑에도 추가적으로 없는 경우
                        {
                            if (lData.CompareTo(di.LastWriteTime.ToString("yyyy-MM-dd hh:mm:ss")) > 0)
                            {
                                try
                                {
                                    LogController.LogWrite(di.FullName, 4);
                                    di.Delete(true);

                                }
                                catch (Exception ex) { LogController.LogWrite(ex.Message, 4); }
                                GC.Collect();
                                Thread.Sleep(20);
                            }
                        }
                        
                    }
                    else { LogController.LogWrite("Specified file doesn't exist", 0); }
                    GC.Collect();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            GC.Collect();
            CheckTimer.Change(TimeSpan.FromSeconds(InterverHour * 3600), TimeSpan.FromSeconds(InterverHour * 3600));
            LogController.LogWrite((InterverHour * 3600).ToString(), 5);
        }
    }
}
