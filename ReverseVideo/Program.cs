using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.UI;
using Emgu.CV.Structure;

namespace ReverseVideo
{
    class Program
    {
        static void Main(string[] args)
        {
            Capture file;
            Image<Bgr, Byte> frame;         //Frame from video
            Image<Bgr, Byte> frame2;        //Clone of frame - addresses null frame.Data
            Stack<Image<Bgr, Byte>> frames = new Stack<Image<Bgr, Byte>>(); //Contains frames
            file = new Capture("competition_1_1_xvid.avi");
            VideoWriter videoOutput = new VideoWriter("output.avi", 0, 30, 720, 480, true);

            while (1 == 1)
            {
                frame = file.QueryFrame();
                if (frame == null) break;       //Break after last frame
                frame2 = frame.Clone();
                frames.Push(frame2);         
            }
            Console.WriteLine("Number of frames: {0}", frames.Count);

            while (frames.Count > 0)
            {
                videoOutput.WriteFrame(frames.Pop());
            }
           
            videoOutput.Dispose();
        }
    }
}
