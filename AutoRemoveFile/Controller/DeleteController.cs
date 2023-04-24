using AutoRemoveFile.Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AutoRemoveFile
{
    internal class DeleteController
    {
        private static List<string> folderDir;
        private static ushort DeleteHour { get; set; }
        private static ushort InterverHour { get; set; }

        public void Set(List<string> nfolderDir,int nDeleteHour, int nInterverHour)
        {
            folderDir = nfolderDir;
            DeleteHour = (ushort) nDeleteHour;  //0 ~  65,535 (2 byte)
            InterverHour = (ushort) (nInterverHour* 1);  //0 ~ 18 (2 byte)
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
                    LogController.LogWrite("", 3);//Connected logMake
                    
                    KernelDelete fileDelete = new KernelDelete();
                    try { Boolean b = fileDelete.DeleteFolder(path, DeleteHour); }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
            catch (Exception ex) { LogController.LogWrite(ex.Message, 4); }
            LogController.LogWrite(InterverHour.ToString(), 5);
            CheckTimer.Change(
                TimeSpan.FromSeconds(InterverHour), 
                TimeSpan.FromSeconds(InterverHour));
            GC.Collect();

        }
    }
}
