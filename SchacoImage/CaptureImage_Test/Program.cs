﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptureImage_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //var image = CaptureImage.CaptureImage.GetFullScreen();
            //CaptureImage.CaptureImage.SaveImage(@"C:\Users\zr644\Desktop\A", image);

            var imageFull = CaptureImage.CaptureImage.GetFullScreen();
            var image = CaptureImage.CaptureImage.GetScreenByPoint(2301,902,426,125);
            CaptureImage.CaptureImage.SaveImage(@"C:\Users\Administrator\Desktop\A.png", image);
        }
    }
}
