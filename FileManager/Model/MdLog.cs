using FileManager.Model.@interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager.Model
{
    internal class MdLog : InFcLog
    {
        public string LogDirPath
        {
            get
            {
                if (Properties.Settings.Default.LogPath == null) return Environment.CurrentDirectory + @"\Log";
                return Properties.Settings.Default.LogPath;
            }
            set => Properties.Settings.Default.LogPath = value;
        }
        public static string LogFilePath { get; set; }

        public RichTextBox LogBox => throw new NotImplementedException();

        public string LogWrite(string message, int index)
        {
            LogFilePath = $"{LogDirPath}\\Log_{DateTime.Today.ToString("MMdd")}.log"; //해당 경로의 파일명

            DirectoryInfo di = new DirectoryInfo(LogDirPath);
            FileInfo fi = new FileInfo(LogFilePath);
            string temp;
            try
            {
                temp = StrMessage(message, index);
                FileWriter(di, fi, temp);
            }
            catch (Exception ex)
            {
                temp = StrMessage(ex.Message, 1);
                FileWriter(di, fi, temp);
            }
            return temp;
        }
        public string StrMessage(string Message, int index)
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
            return string.Format(ChoiceList[index], DateTime.Now, Message);
        }
        public void LogRead()
        {
            LogBox.Clear();
            using (StreamReader r = File.OpenText(LogFilePath))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    LogBox.AppendText(line + "\n");
                }
            }
            LogBox.ScrollToCaret();
        }
        public string FileWriter(DirectoryInfo di, FileInfo fi, string temp)
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
            return temp + "\n";
        }
    }
}
