using FileManager.Model.@interface;
using System;
using System.Windows.Forms;
using Serilog;
using Serilog.Sinks.File;
using System.IO;

namespace FileManager.Model
{
    internal class MdLog : InFcLog
    {
        public string LogDirPath
        {
            get
            {
                if (Properties.Settings.Default.LogPath == null) return Environment.CurrentDirectory;
                return Properties.Settings.Default.LogPath;
            }
            set => Properties.Settings.Default.LogPath = value;
        }
        public RichTextBox? LogBox { get; set; }

        private string LogFilePath = string.Empty;
        public void LogPrint(string message, int index)
        {
            LogFilePath = $"{LogDirPath}\\.log"; //해당 경로의 파일명
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(LogFilePath, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information(StrLogMessage(message, index));
            LogBox.AppendText($"[{DateTime.Now}]"+StrLogMessage(message, index) + "\n");

            Log.CloseAndFlush();
            DeleteOldLogs();//LogBox 메모리 제한
        }
        public string StrLogMessage(string message, int index) // 출력문
        {
            string[] ChoiceList =
            {
                "{0}",                                                                          //[0] 일반
                "The deletion failed: {0}",                                                     //[1] 예외처리
                "Get Directory info... PATH:{0}",                                               //[2] 경로 접근 시도
                "Get Directory OK!",                                                            //[3] 경로 접근 성공
                "[DEL] {0}",                                                                    //[4] 삭제 진행
                "Finish Delete Directories. Wait for next callback! ({0} seconds interval)",    //[5] 삭제 완료 후 재시작 예정일
                "Delete Directories that are out of storage ",                                  //[6] 삭제 완료
                "Get Delete Directory List OK!"                                                 //[7] 삭제 리스트 접근 성공
            };
            return string.Format(ChoiceList[index], message);
        }
        private void DeleteOldLogs()
        {
            int maxLogLength = 5000;
            if (LogBox.InvokeRequired)
            {
                LogBox.Invoke(new Action(() => DeleteOldLogs()));
            }
            else
            {
                if (LogBox.TextLength > maxLogLength)
                {
                    int excessChars = LogBox.TextLength - maxLogLength;
                    LogBox.Select(0, excessChars);
                    LogBox.SelectedText = "";
                }
            }
        }
    }
}
