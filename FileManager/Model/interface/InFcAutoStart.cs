using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Model.@interface
{
    interface InFcAutoStart
    {
        [DisallowNull]
        string APPLICATION_NAME { get; set; }
        RegistryKey registryKey { get; }
        RegistryKey GetKey { get; }

        void SetAuto();
        void DeleteAuto();
        bool CheckAuto();
    }
}
