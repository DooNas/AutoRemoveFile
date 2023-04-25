﻿using FileManager.Model;
using FileManager.Presenter;
using FileManager.View.@interface;
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
    public partial class SettingForm : Form, InFcSetting
    {
        public string APPLICATION_NAME { get { return "FileManager"; } }
        public string SuperPath
        {
            get => FileManager.Properties.Settings.Default.SuperPath;
            set
            {
                tb_SuperPath.Text = value;
                FileManager.Properties.Settings.Default.SuperPath = value;
            }
        }
        public string LogPath
        {
            get
            {
                if (FileManager.Properties.Settings.Default.LogPath == "") return Environment.CurrentDirectory;
                else return FileManager.Properties.Settings.Default.LogPath;
            }
            set
            {
                tb_LogPath.Text = value;
                FileManager.Properties.Settings.Default.LogPath = value;
            }
        }
        public int interval
        {
            get => FileManager.Properties.Settings.Default.Interval_Hour;
            set => FileManager.Properties.Settings.Default.Interval_Hour = value;
        }
        public int StandardDay
        {
            get => FileManager.Properties.Settings.Default.Standard_Day;
            set => FileManager.Properties.Settings.Default.Standard_Day = value;
        }

        public bool AutoStart
        {
            get => FileManager.Properties.Settings.Default.AutoStart;
            set => FileManager.Properties.Settings.Default.AutoStart = value;
        }

        public SettingForm()
        {
            InitializeComponent();
            SettingEvent();
        }
        FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
        private PreAutoStart preAuto;
        private void SettingEvent()
        {
            Load += (sender, args) =>
            {
                tb_SuperPath.Text = SuperPath;
                tb_LogPath.Text = LogPath;
                tb_IntervalTime.Text = interval.ToString();
                tb_StandardDay.Text = StandardDay.ToString();
            };
            tb_LogPath.TextChanged += (sender, args) => { LogPath = tb_LogPath.Text; };
            tb_SuperPath.TextChanged += (sender, args) => { SuperPath = tb_SuperPath.Text; };
            tb_IntervalTime.TextChanged += (sender, args) => { interval = Convert.ToInt32(tb_IntervalTime.Text); };
            tb_StandardDay.TextChanged += (sender, args) => { StandardDay = Convert.ToInt32(tb_StandardDay.Text); };

            //윈도우 부팅시
            preAuto = new PreAutoStart(this, new MdAutoStart());
            cbAutostart.Checked = preAuto.CheckAuto();
        }

        private void tb_SuperPath_Click(object sender, EventArgs e)
        {

            folderBrowser.SelectedPath = SuperPath;
            folderBrowser.ShowDialog();
            SuperPath = folderBrowser.SelectedPath;
        }
        private void tb_LogPath_Click(object sender, EventArgs e)
        {
            folderBrowser.SelectedPath = LogPath;
            folderBrowser.ShowDialog();
            LogPath = folderBrowser.SelectedPath;
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Save?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes) FileManager.Properties.Settings.Default.Save();
            this.Close();
        }

        private void cbAutostart_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAutostart.Checked) preAuto.Start();
            else preAuto.Stop();
        }
    }
}