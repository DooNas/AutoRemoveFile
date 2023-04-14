using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeleteFileController
{
    public partial class SettingForm : Form
    {

        private string LogF_logPath;
        public string sLogPath
        {
            get { return this.LogF_logPath; }
            set { this.LogF_logPath = value; }//Main에서 전달 받은 값
        }
        public SettingForm()
        {
            InitializeComponent();
        }
        private void LogForm_Load(object sender, EventArgs e)
        {
            if (sLogPath == string.Empty) Logtb_Path.Text = Environment.CurrentDirectory;
            else Logtb_Path.Text = sLogPath;
        }
        private void Logtb_Path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowDialog();

            Logtb_Path.Text = folderBrowser.SelectedPath;
        }
        private void Logbt_Check_Click(object sender, EventArgs e)
        {
            FileManager.Properties.Settings.Default.LogPath = Logtb_Path.Text;
            MessageBox.Show("Save!!");
        }
    }
}
