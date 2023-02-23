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
    internal class AutoStart
    {
        private const string APPLICATION_NAME = "AutoRemoveFile";
        RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(
                                 @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

        public void SetAutoStartApplication(string applicationName, string applicationFilePath)
        {
            if (registryKey.GetValue(APPLICATION_NAME) == null)
            {
                registryKey.SetValue(APPLICATION_NAME, applicationFilePath);
            }
        }

        public void SetAutoStartApplication()
        {
            SetAutoStartApplication(APPLICATION_NAME, Application.ExecutablePath);
        }

        public void ResetAutoStartApplication()
        {
            if (registryKey.GetValue(APPLICATION_NAME) != null)
            {
                registryKey.DeleteValue(APPLICATION_NAME, false);
            }
        }

        public bool IsAutoStartApplication()
        {
            return registryKey.GetValue(APPLICATION_NAME) != null;
        }
    }
}
