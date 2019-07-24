using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVCsharp_Test
{
    class Program
    {

        public static string Image1_3Item = @"Image\1_3Item.png";
        public static string Image2_Enter2Item = @"Image\2_Enter2Item.png";
        public static string Image3_Enter2Item = @"Image\3_Enter2Item.png";
        public static string Image4_Enter2Item = @"Image\4_Enter2Item.png";
        public static string Image5_Enter2Item = @"Image\5_Enter2Item.png";
        public static string Image6_Enter3Item = @"Image\6_Enter3Item.png";
        public static string ImageWrongImage = @"Image\WrongImage.png";
        public static string OtherImage = @"Image\A.png";


        static void Main(string[] args)
        {
            //HistogarmToComparison(Image1_3Item, Image2_Enter2Item, Image3_Enter2Item);

            //Console.WriteLine(Identify_OpenCV.Identify.CompareImageByHistogram
            //    (Image1_3Item, Image2_Enter2Item, 
            //    HistCompMethods.Intersect
            //    ));
            //Console.ReadKey();

            //Compare(Image1_3Item, Image2_Enter2Item, HistCompMethods.Bhattacharyya);
            TEST1();
            Console.ReadKey();



            //double mix;
            //double max;
            //Identify_OpenCV.Identify.CompareImageByMatchTemplate
            //    (Image1_3Item, Image2_Enter2Item, TemplateMatchModes.SqDiffNormed,out mix,out max);
            //Console.WriteLine("mix:"+mix);
            //Console.WriteLine("max:" + max);
            //Console.ReadKey();
        }


        static void TEST1()
        {
            // Mat mat1 = new Mat(@"timg.jpg", ImreadModes.Grayscale);
            // Mat mat2 = new Mat(@"文件名.jpg", ImreadModes.Grayscale);
            Mat mat1 = new Mat(Image1_3Item, ImreadModes.AnyColor);
            Mat mat2 = new Mat(Image2_Enter2Item, ImreadModes.AnyColor);
            Mat mat3 = new Mat();
            //创建result的模板，就是MatchTemplate里的第三个参数
            mat3.Create(mat1.Rows - mat2.Rows + 1, mat1.Cols - mat2.Cols + 1, MatType.CV_32FC1);
            //进行匹配(1母图,2模版子图,3返回的result，4匹配模式_这里的算法比opencv少，具体可以看opencv的相关资料说明)
            Cv2.MatchTemplate(mat1, mat2, mat3, TemplateMatchModes.SqDiffNormed);

            //Cv2.Compare();

            //对结果进行归一化(这里我测试的时候没有发现有什么用,但在opencv的书里有这个操作，应该有什么神秘加成，这里也加上)
            Cv2.Normalize(mat3, mat3, 1, 0, NormTypes.MinMax, -1);
            double minValue, maxValue;
            Point minLocation, maxLocation;
            /// 通过函数 minMaxLoc 定位最匹配的位置
            /// (这个方法在opencv里有5个参数，这里我写的时候发现在有3个重载，看了下可以直接写成拿到起始坐标就不取最大值和最小值了)
            /// minLocation和maxLocation根据匹配调用的模式取不同的点
            /// 

            Cv2.MinMaxLoc(mat3, out minValue, out maxValue, out minLocation, out maxLocation);
            //画出匹配的矩，
            //  Cv2.Rectangle(mat1, maxLocation, new Point (maxLocation.X+mat2.Cols, maxLocation.Y+mat2.Rows), Scalar.Red, 2);
            Cv2.Rectangle(mat1, minLocation, new Point(minLocation.X + mat2.Cols, minLocation.Y + mat2.Rows), Scalar.Red, 2);
            Cv2.ImShow("mat1", mat1);
            Cv2.ImShow("mat2", mat2);

            //Console.WriteLine(minValue);
            //Console.WriteLine(maxValue);
            Console.WriteLine(minLocation);
            Console.WriteLine(maxLocation);
            Cv2.WaitKey();
        }

        private static void HistogarmToComparison(string path1, string path2, string path3)
        {
            using (Mat baseMat = new Mat(path1, ImreadModes.AnyColor | ImreadModes.AnyDepth))
            using (Mat src1 = new Mat(path2, ImreadModes.AnyColor | ImreadModes.AnyDepth))
            using (Mat src2 = new Mat(path3, ImreadModes.AnyColor | ImreadModes.AnyDepth))
            {
                //1:从BGR空间转换到HSV色彩空间


                Mat baseHSV = new Mat();
                Mat src1HSV = new Mat();
                Mat src2HSV = new Mat();


                Cv2.CvtColor(baseMat, baseHSV, ColorConversionCodes.BGR2HSV);
                Cv2.CvtColor(src1, src1HSV, ColorConversionCodes.BGR2HSV);
                Cv2.CvtColor(src2, src2HSV, ColorConversionCodes.BGR2HSV);
                //Mat[] mats = new Mat[] { baseHSV, src1HSV, src2HSV };
                Mat[] mats1 = Cv2.Split(baseHSV);
                Mat[] mats2 = Cv2.Split(src1HSV);
                Mat[] mats3 = Cv2.Split(src2HSV);

                //计算直方图并归一化数据

                int bin1 = 50; //灰度等级
                int bin2 = 60;//灰度等级
                int[] histSiz = { bin1, bin2 };

                int[] channels = { 0, 1 };//图像通道数
                Rangef[] rangefs = new Rangef[] //梯度值范围
               {
                    new Rangef(0, 180),
                    new Rangef(0,256)
               };

                Mat Img1 = new Mat(baseMat.Size(), MatType.CV_32FC2);
                Mat Img2 = new Mat(src1.Size(), MatType.CV_32FC2);
                Mat Img3 = new Mat(src2.Size(), MatType.CV_32FC2);
                HistCompMethods method = HistCompMethods.KLDiv;


                Cv2.CalcHist(mats1, channels, new Mat(), Img1, 2, histSiz, rangefs, true, false);
                Cv2.Normalize(Img1, Img1, 0, 1, NormTypes.MinMax, -1, null);

                Cv2.CalcHist(mats2, channels, new Mat(), Img2, 2, histSiz, rangefs, true, false);
                Cv2.Normalize(Img2, Img2, 0, 1, NormTypes.MinMax, -1, null);

                Cv2.CalcHist(mats3, channels, new Mat(), Img3, 2, histSiz, rangefs, true, false);
                Cv2.Normalize(Img3, Img3, 0, 1, NormTypes.MinMax, -1, null);

                //比较直方图
                double bcomb = Cv2.CompareHist(Img1, Img1, method);
                double s1coms2 = Cv2.CompareHist(Img2, Img3, method);
                double bcoms1 = Cv2.CompareHist(Img1, Img2, method);
                double bcoms2 = Cv2.CompareHist(Img1, Img3, method);

                Mat mats1Ands2 = new Mat();
                src2.CopyTo(mats1Ands2);

                Cv2.PutText(baseMat, bcomb.ToString(), new Point(30, 30), HersheyFonts.HersheyComplex, 1, new Scalar(0, 255, 0), 2, LineTypes.AntiAlias);

                Cv2.PutText(src1, bcoms1.ToString(), new Point(30, 30), HersheyFonts.HersheyComplex, 1, new Scalar(0, 255, 0), 2, LineTypes.AntiAlias);

                Cv2.PutText(src2, bcoms2.ToString(), new Point(30, 30), HersheyFonts.HersheyComplex, 1, new Scalar(0, 255, 0), 2, LineTypes.AntiAlias);

                Cv2.PutText(mats1Ands2, s1coms2.ToString(), new Point(30, 30), HersheyFonts.HersheyComplex, 1, new Scalar(0, 255, 0), 2, LineTypes.AntiAlias);

                using (new Window("Img1 :Img1", WindowMode.Normal, baseMat))
                using (new Window("Img1 :Img2", WindowMode.Normal, src1))
                using (new Window("Img1 :Img3", WindowMode.Normal, src2))
                {
                    Cv2.WaitKey(0);
                }

            }
        }

        static double Compare(string str1,string str2, HistCompMethods method)
        {
            Mat mat1 = new Mat(str1, ImreadModes.AnyColor);
            Mat mat2 = new Mat(@str1, ImreadModes.AnyColor);
            Mat mat3 = new Mat();
            var value= Cv2.CompareHist(mat1, mat2, method);
            Console.WriteLine(new FileInfo(str1).Name + "-" + new FileInfo(str2).Name + ":" + value);
            return value;
        }
    }
}
