using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace AutoRemoveFile
{
    internal class DeleteController
    {
        private static List<string> folderDir;

        private static ushort Interver = 3600;
        private static ushort DeleteHour { get; set; }
        private static ushort InterverHour { get; set; }

        public void Set(List<string> nfolderDir,int nDeleteHour, int nInterverHour)
        {
            folderDir = nfolderDir;
            DeleteHour = (ushort) nDeleteHour;  //0 ~  65,535 (2 byte)
            InterverHour = (ushort) (nInterverHour* Interver);  //0 ~ 18 (2 byte)
        }

        private static System.Threading.Timer CheckTimer;
        public void Interval_Delete()
        {
            CheckTimer = new System.Threading.Timer(
                DelFile,
                null,
                TimeSpan.FromSeconds(0),
                TimeSpan.FromSeconds(InterverHour)
                );
        }
        private static void DelFile(object state)
        {
            CheckTimer.Change(Timeout.Infinite, Timeout.Infinite);  //기존 쓰레드 종료
            LogController.LogWrite("", 0);

            try
            {
                foreach (string path in folderDir)
                {
                    LogController.LogWrite(path, 2); //Connecting..logMake
                    DirectoryInfo di = new DirectoryInfo(path);
                    LogController.LogWrite("", 3);//Connected logMake

                    if (di.Exists)
                    {
                        DirectoryInfo[] dirInfo = di.GetDirectories();
                        string lData = DateTime.Now.AddHours(-DeleteHour).ToString("yyyy-MM-dd hh:mm:ss");

                        if (dirInfo.Length > 0)//하위 디렉토리 O
                        {
                            foreach (DirectoryInfo dir in dirInfo.Reverse())
                            {
                                if (lData.CompareTo(di.LastWriteTime.ToString("yyyy-MM-dd hh:mm:ss")) > 0)
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
                        else//하위 디렉토리 X
                        {
                            if (lData.CompareTo(di.LastWriteTime.ToString("yyyy-MM-dd hh:mm:ss")) > 0)
                            {
                                foreach(FileInfo file in di.GetFiles())
                                {
                                    try
                                    {
                                        if(lData.CompareTo(file.LastWriteTime.ToString("yyyy-MM-dd hh:mm:ss")) > 0)
                                        {
                                            LogController.LogWrite(file.FullName, 4);
                                            File.Delete(file.FullName);
                                        }

                                    }
                                    catch (Exception ex) { LogController.LogWrite(ex.Message, 4); }
                                }
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
            CheckTimer.Change(
                TimeSpan.FromSeconds(InterverHour), 
                TimeSpan.FromSeconds(InterverHour));
            LogController.LogWrite(InterverHour.ToString(), 5);
        }
    }
}
