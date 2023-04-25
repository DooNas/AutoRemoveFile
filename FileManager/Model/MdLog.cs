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
                if (Properties.Settings.Default.LogPath == null) return Path.Combine(Environment.CurrentDirectory, @"\Log");
                return Properties.Settings.Default.LogPath;
            }
            set => Properties.Settings.Default.LogPath = value;
        }
        public static string LogFilePath { get; set; }

        public RichTextBox LogBox { get; }

        public MdLog(RichTextBox logBox)
        {
            LogBox = logBox;

            // Configure Serilog to write to a file in the LogDirPath directory.
            LogFilePath = Path.Combine(LogDirPath, "log.txt");
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(LogFilePath)
                .CreateLogger();

            // Set the Serilog logger's output to the custom TextWriter instance.
            Log.Logger = new LoggerConfiguration()
                .WriteTo.TextWriter(new RichTextBoxWriter(LogBox))
                .CreateLogger();
        }
    }
}
