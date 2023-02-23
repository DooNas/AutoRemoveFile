using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoRemoveFile
{
    internal class DeleteController
    {

        public void deleteFolder(RichTextBox richText,string[] folderDir, int DeleteDay, LogController logController)
        {
            LogController logcont = new LogController();
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
                catch (Exception ex) { logcont.LogWrite(richText, ex.Message, 4); }
            }
        }
    }
}
