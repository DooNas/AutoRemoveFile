using DeleteFileController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void bt_Setting_Click(object sender, EventArgs e)
        {
            SettingForm Settings = new SettingForm();
            Settings.Size = new Size(610, 195);
            Settings.ShowDialog();
        }
    }
}
