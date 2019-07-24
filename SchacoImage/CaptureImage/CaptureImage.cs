using ShareX.HelpersLib;
using ShareX.ScreenCaptureLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            bmp.Save(filename);
            bmp.Dispose();
        }

        public static Image GetScreenByPoint(int x, int y, int width, int height)
        {
            GraphicsPath regionFillPath = new GraphicsPath { FillMode = FillMode.Winding };
            Rectangle rectangle = new Rectangle(x, y, width, height);
            regionFillPath.AddRectangle(rectangle);
            Rectangle screenRectangle = ScreenToClient(SystemInformation.VirtualScreen);
            Rectangle resultArea = Rectangle.Intersect(rectangle, screenRectangle);

            if (resultArea.IsValid())
            {
                Image img = GetFullScreen();
                using (Bitmap bmp = img.CreateEmptyBitmap())
                using (Graphics g = Graphics.FromImage(bmp))
                using (TextureBrush brush = new TextureBrush(img))
                {
                    g.PixelOffsetMode = PixelOffsetMode.Half;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.FillPath(brush, regionFillPath);
                    return ImageHelpers.CropBitmap(bmp, resultArea);
                }
            }
            return null;
        }

        static Rectangle ScreenToClient(Rectangle r)
        {
            return new Rectangle(ScreenToClient(r.Location), r.Size);
        }

        public static Point ScreenToClient(Point p)
        {
            int screenX = NativeMethods.GetSystemMetrics(SystemMetric.SM_XVIRTUALSCREEN);
            int screenY = NativeMethods.GetSystemMetrics(SystemMetric.SM_YVIRTUALSCREEN);
            return new Point(p.X - screenX, p.Y - screenY);
        }
    }
}
