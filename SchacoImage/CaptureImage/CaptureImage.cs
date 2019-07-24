using ShareX.ScreenCaptureLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptureImage
{
    public class CaptureImage
    {
        public static Image GetFullScreen()
        {
            Screenshot screenshot = new Screenshot()
            {
                CaptureCursor = false,
                CaptureClientArea = false,
                RemoveOutsideScreenArea = true,
                CaptureShadow = false,
                ShadowOffset = 0,
                AutoHideTaskbar = true
            };
            Image img = screenshot.CaptureFullscreen();
            return img;
        }

        public static void SaveImage(string filename,Image image)
        {
            Bitmap bmp = new Bitmap(image);
            //保存到磁盘文件
            bmp.Save(filename, image.RawFormat);
            bmp.Dispose();
        }
    }
}
