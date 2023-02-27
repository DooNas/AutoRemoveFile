using AutoRemoveFile.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoRemoveFile
{
    internal class StartController
    {
        //레지스터리에 저장되는 제목
        private const string APPLICATION_NAME = "AutoRemoveFile";

        //저장되는 레지스터리 경로
        private RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(
            "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public RegistryKey GetKey{get{return registryKey;}}

        public void SetAuto()
        {
            registryKey.SetValue(
                APPLICATION_NAME, 
                Environment.CurrentDirectory + "\\" + AppDomain.CurrentDomain.FriendlyName
                );
        }

        public void DeleteAuto()
        {
            registryKey.DeleteValue(APPLICATION_NAME, false);
            MessageBox.Show("AutoStart is UnActive");
        }
    }
}
