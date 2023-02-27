using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace AutoRemoveFile
{
    /// <summary>
    /// 로그 작성기
    /// 
    /// </summary>
    internal class LogController
    {
        private static string LogDirPath { get; set; }
        private static string LogFilePath { get; set; }

        public static void LogRead(RichTextBox rich)
        {
            rich.Clear();
            using (StreamReader r = File.OpenText(LogFilePath))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    rich.AppendText(line+"\n");
                }
            }
            rich.ScrollToCaret();
        }

        public static string LogWrite(string message, int index)
        {

            LogDirPath = Properties.Settings.Default.LogPath + @"\Log"; //절대경로
            LogFilePath = LogDirPath + "\\Log_" + DateTime.Today.ToString("MMdd") + ".log"; //해당 경로의 파일명
            string temp;

            DirectoryInfo di = new DirectoryInfo(LogDirPath);
            FileInfo fi = new FileInfo(LogFilePath);

            try
            {
                temp = StrLogMessage(message, index);
                FileWriter(di, fi, temp);
            }
            catch (Exception ex) {
                temp = StrLogMessage(ex.Message, 1);
                FileWriter(di, fi, temp);
            }
            return temp;
        }

        public static string StrLogMessage(string message, int index) // 출력문
        {
            string[] ChoiceList =
            {
                "[{0}] {1}",                                                                          //[0] 일반
                "[{0}] The deletion failed: {1}",                                                     //[1] 예외처리
                "[{0}] Get Directory info... PATH:{1}",                                               //[2] 경로 접근 시도
                "[{0}] Get Directory OK!",                                                            //[3] 경로 접근 성공
                "[{0}] [DEL] {1}",                                                                    //[4] 삭제 진행
                "[{0}] Finish Delete Directories. Wait for next callback! ({1} seconds interval)",    //[5] 삭제 완료 후 재시작 예정일
                "[{0}] Delete Directories that are out of storage "                                   //[6] 삭제 완료
            };

            return string.Format(ChoiceList[index], DateTime.Now, message);
        }

        public static string FileWriter(DirectoryInfo di, FileInfo fi, string temp) //
        {
            if (!di.Exists) Directory.CreateDirectory(LogDirPath);
            if (!fi.Exists)
            {
                using (StreamWriter sw = new StreamWriter(LogFilePath))//Make File
                {
                    sw.WriteLine(temp);
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(LogFilePath))//File add
                {
                    sw.WriteLine(temp);
                    sw.Close();
                }
            }
            return temp+ "\n";
        }
    }
}
