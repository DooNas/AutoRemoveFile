using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml.Linq;

namespace AutoRemoveFile
{
    internal class DeleteController
    {
        private static ushort Interver = 3600;
        private static List<string> folderDir;
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
                    DirectoryInfo di = new DirectoryInfo(path); //절대경로
                    if (di.Exists)  //절대 경로 유무 확인
                    {
                        LogController.LogWrite(path, 2); //Connecting..logMake
                        LogController.LogWrite("", 3);//Connected logMake

                        DirectoryInfo[] dirInfo = di.GetDirectories();  //절대경로의 하위 디렉토리들
                        string lData = DateTime.Now.AddHours(-DeleteHour).ToString("yyyy-MM-dd hh:mm:ss");

                        if (dirInfo.Length > 0)//하위 디렉토리 O
                        {
                            foreach (DirectoryInfo dir in dirInfo.Reverse())//하위 디렉토리들(내림차순)
                            {
                                if (isFiles(dir.FullName)) WhenDeleteFile(dir, lData);
                                else WhenDeleteDir(dir, lData);
                                Thread.Sleep(20);
                            }
                            if (isFiles(di.FullName))WhenDeleteFile(di, lData);
                        }
                        else if(isFiles(di.FullName))/*하위 디렉토리 X*/WhenDeleteFile(di, lData);
                        
                    }
                    else { LogController.LogWrite("Specified file doesn't exist", 0); }
                    GC.Collect();
                }
            }
            catch (Exception ex) { LogController.LogWrite(ex.Message, 4); }
            LogController.LogWrite(InterverHour.ToString(), 5);
            CheckTimer.Change(
                TimeSpan.FromSeconds(InterverHour), 
                TimeSpan.FromSeconds(InterverHour));
            GC.Collect();

        }
        /// <summary>
        /// 디렉토리내 파일 유무 확인
        /// </summary>
        /// <param name="dir">상위경로</param>
        /// <returns></returns>
        private static bool isFiles(string dir)
        {
            string[] Directories = Directory.GetDirectories(dir);
            {
                string[] Files = Directory.GetFiles(dir);
                if (Files.Length != 0) return true;

                //재귀
                foreach (string DirNode in Directories) isFiles(DirNode);
            }
            return false;
        }
        /// <summary>
        /// 경과 시간에 따라 상위디렉토리 기준 하위 파일 삭제
        /// </summary>
        /// <param name="dir">절대경로</param>
        /// <param name="lData">삭제 기준 날짜</param>
        private static void WhenDeleteFile(DirectoryInfo dir, string lData)
        {
            foreach (FileInfo file in dir.GetFiles())
            {
                if (lData.CompareTo(file.CreationTime.ToString("yyyy-MM-dd hh:mm:ss")) > 0)
                {
                    try
                    {
                        LogController.LogWrite(file.FullName, 4);
                        File.Delete(file.FullName);//해당 파일 삭제

                    }
                    catch (Exception ex) { LogController.LogWrite(ex.Message, 4); }
                }
            }
        }
        /// <summary>
        /// 경과 시간에 따라 상위디렉토리 기준 하위 디렉토리 삭제
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="lData"></param>
        private static void WhenDeleteDir(DirectoryInfo dir, string lData)
        {
            if (lData.CompareTo(dir.LastWriteTime.ToString("yyyy-MM-dd hh:mm:ss")) > 0)
            {
                try
                {
                    LogController.LogWrite(dir.FullName, 4);
                    Directory.Delete(dir.FullName);//해당 경로 삭제

                }
                catch (Exception ex) { LogController.LogWrite(ex.Message, 4); }
            }
        }
    }
}
