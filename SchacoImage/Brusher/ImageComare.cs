using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brusher
{

    public class ImageComare
    {
        public static string Image1_3Item = @"Image\1_3Item.png";
        public static string Image2_Enter2Item = @"Image\2_Enter2Item.png";
        public static string Image3_Enter2Item = @"Image\3_Enter2Item.png";
        public static string Image4_Enter2Item = @"Image\4_Enter2Item.png";
        public static string Image5_Enter2Item = @"Image\5_Enter2Item.png";
        public static string Image6_Enter3Item = @"Image\6_Enter3Item.png";
        public static string ImageWrongImage = @"Image\WrongImage.png";
        public static string ImageESC = @"Image\esc.png";

        //当前截图
        public static string ImageCurrent = @"Image\Current.png";
        public static string ImageCurrentESC = @"Image\esc.png";


        public static int X = 2301;
        public static int Y = 902;
        public static int W = 426;
        public static int H = 125;

        public void Compare()
        {
            var ImageTarget = CaptureImage.CaptureImage.GetScreenByRegion(X, Y, W, H);
        }

        public static void GetAndSaveCurrentImage()
        {
            var image = CaptureImage.CaptureImage.GetScreenByRegion(X, Y, W, H);
            CaptureImage.CaptureImage.SaveImage(ImageCurrent, image);
        }

        public static void GetAndSaveESCImage()
        {
            var image = CaptureImage.CaptureImage.GetScreenByRegion(2793, 389, 156, 298);
            CaptureImage.CaptureImage.SaveImage(ImageCurrentESC, image);
        }
    }


    
}
