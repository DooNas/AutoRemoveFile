using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoRemoveFile
{
    internal class LogController
    {
        public string LogWrite(string message, int index)
        {
            string[] ChoiceList =
            {
                "[{0}] {1}",                                                                    //[0] 일반
                "[{0}] The deletion failed: {1}",                                               //[1] 예외처리
                "[{0}] Get Directory info... PATH:{1}",                                         //[2] 경로 접근 시도
                "[{0}] Get Directory OK!",                                                      //[3] 경로 접근 성공
                "[{0}] [DEL] {1}",                                                              //[4] 삭제 진행
                "Finish Delete Directories. Wait for next callback! ({0} seconds interval)",    //[5] 삭제 완료 후 재시작 예정일
                "[{0}] Delete Directories that are out of storage "                             //[6] 삭제 완료
            };

            string logPath = Properties.Settings.Default.LogPath + @"\Log";
            string FilePath = logPath + "\\Log_" + DateTime.Today.ToString("MMdd") + ".log";
            string temp;

            DirectoryInfo di = new DirectoryInfo(logPath);
            FileInfo fi = new FileInfo(FilePath);

            temp = string.Format(ChoiceList[index], DateTime.Now, message);
            if(index == 5) temp = string.Format(ChoiceList[index], message); //5번 한정 예외처리
            try
            {
                if (!di.Exists) Directory.CreateDirectory(logPath);
                if (!fi.Exists)
                {
                    using (StreamWriter sw = new StreamWriter(FilePath))//file is no here
                    {
                        sw.WriteLine(temp);
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(FilePath))//file is here
                    {
                        sw.WriteLine(temp);
                        sw.Close();
                    }
                }
                return temp + "\n";
            }
            catch (Exception ex) { return string.Format(ChoiceList[1], DateTime.Now, ex.Message) + "\n"; }
            
        }
    }
}
