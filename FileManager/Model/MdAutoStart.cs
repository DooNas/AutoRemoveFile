using FileManager.Model.@interface;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager.Model
{
    internal class MdAutoStart : InFcAutoStart
    {
        public string APPLICATION_NAME { get; set; }
        public RegistryKey registryKey
        {
            get => Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        }

        public RegistryKey GetKey { get { return registryKey; } }

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

        public bool CheckAuto()
        {
            if (GetKey.GetValue(APPLICATION_NAME) == null) return false;
            else return true;
        }

    }
}
