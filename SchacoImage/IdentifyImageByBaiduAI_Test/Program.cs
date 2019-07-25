using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IdentifyImageByBaiduAI_Test
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @"C:\Users\zr644\Desktop\3333.jpg";
           var x= IdentifyImageByBaiduAI.IdentifyImageByBaiduAI.Identify(path);
        }


        /// <summary> 
        /// 图像灰度反转 
        /// </summary> 
        /// <param name="bmp"></param> 
        /// <returns></returns> 
        public static Bitmap GrayReverse(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    //获取该点的像素的RGB的颜色 
                    Color color = bmp.GetPixel(i, j);
                    Color newColor = Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
                    bmp.SetPixel(i, j, newColor);
                }
            }
            return bmp;
        }
    }
}
