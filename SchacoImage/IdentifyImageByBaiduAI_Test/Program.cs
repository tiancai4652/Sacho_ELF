using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IdentifyImageByBaiduAI_Test
{
    class Program
    {
        static void Main(string[] args)
        {
        


            string path = @"C:\Users\Administrator\Desktop\新建文件夹\333.png";
            //string path1 = @"C: \Users\Administrator\Desktop\新建文件夹\1_3Item_1.png";
            //ConvertorColor(path, path1);
           var x= IdentifyImageByBaiduAI.IdentifyImageByBaiduAI2.Identify(path);
        }


        /// <summary> 
        /// 图像灰度反转 
        /// </summary> 
        /// <param name="bmp"></param> 
        /// <returns></returns> 
        static Bitmap GrayReverse(string path)
        {
            Bitmap bmp = ReadImageFile(path);
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

        /// <summary>
        /// 通过FileStream 来打开文件，这样就可以实现不锁定Image文件，到时可以让多用户同时访问Image文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static Bitmap ReadImageFile(string path)
        {
            FileStream fs = File.OpenRead(path); //OpenRead
            int filelength = 0;
            filelength = (int)fs.Length; //获得文件长度 
            Byte[] image = new Byte[filelength]; //建立一个字节数组 
            fs.Read(image, 0, filelength); //按字节流读取 
            System.Drawing.Image result = System.Drawing.Image.FromStream(fs);
            fs.Close();
            Bitmap bit = new Bitmap(result);
            return bit;
        }

        static void SaveBitmap(Bitmap bitmap, string path)
        {
            bitmap.Save(path);
        }

        public static void ConvertorColor(string imagePath,string path1)
        {
            SaveBitmap(GrayReverse(imagePath), path1);
        }
    }
}
