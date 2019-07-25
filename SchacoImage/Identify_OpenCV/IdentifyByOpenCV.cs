using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageIdentify
{
    public class IdentifyByOpenCV
    {
        /// <summary>
        ///  CV_TM_SQDIFF 平方差匹配法：该方法采用平方差来进行匹配；最好的匹配值为0；匹配越差，匹配值越大。
        ///  CV_TM_CCORR 相关匹配法：该方法采用乘法操作；数值越大表明匹配程度越好。
　　　　///　CV_TM_CCOEFF 相关系数匹配法：1表示完美的匹配；-1表示最差的匹配。
　　　　///　CV_TM_SQDIFF_NORMED 归一化平方差匹配法
        ///  CV_TM_CCORR_NORMED 归一化相关匹配法
        //  /CV_TM_CCOEFF_NORMED 归一化相关系数匹配法
        /// </summary>
        /// <param name="sourceImahe"></param>
        /// <param name="targetImage"></param>
        /// <param name="templateMatchMode"></param>
        /// <param name="minx"></param>
        /// <param name="max"></param>
        public static void CompareImageByMatchTemplate(string sourceImage, string targetImage, TemplateMatchModes templateMatchMode, out double minx,out double max)
        {
            Mat mat1 = new Mat(sourceImage, ImreadModes.AnyColor);
            Mat mat2 = new Mat(targetImage, ImreadModes.AnyColor);
            Mat mat3 = new Mat();
            mat3.Create(mat1.Rows - mat2.Rows + 1, mat1.Cols - mat2.Cols + 1, MatType.CV_32FC1);
            Cv2.MatchTemplate(mat1, mat2, mat3, templateMatchMode);
            Cv2.Normalize(mat3, mat3, 1, 0, NormTypes.MinMax, -1);
            Point minLocation, maxLocation;
            Cv2.MinMaxLoc(mat3, out minx, out max, out minLocation, out maxLocation);
        }


        public static double CompareImageByHistogram(string sourceImage, string targetImage, HistCompMethods method= HistCompMethods.KLDiv)
        {
           
            using (Mat source = new Mat(sourceImage, ImreadModes.AnyColor | ImreadModes.AnyDepth))
            using (Mat target = new Mat(targetImage, ImreadModes.AnyColor | ImreadModes.AnyDepth))
            {
                //1:从BGR空间转换到HSV色彩空间
                Mat src1HSV = new Mat();
                Mat src2HSV = new Mat();

                Cv2.CvtColor(source, src1HSV, ColorConversionCodes.BGR2HSV);
                Cv2.CvtColor(target, src2HSV, ColorConversionCodes.BGR2HSV);
                //Mat[] mats = new Mat[] { baseHSV, src1HSV, src2HSV };

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

                Mat Img2 = new Mat(source.Size(), MatType.CV_32FC2);
                Mat Img3 = new Mat(target.Size(), MatType.CV_32FC2);

                Cv2.CalcHist(mats2, channels, new Mat(), Img2, 2, histSiz, rangefs, true, false);
                Cv2.Normalize(Img2, Img2, 0, 1, NormTypes.MinMax, -1, null);

                Cv2.CalcHist(mats3, channels, new Mat(), Img3, 2, histSiz, rangefs, true, false);
                Cv2.Normalize(Img3, Img3, 0, 1, NormTypes.MinMax, -1, null);

                //比较直方图
                double s1coms2 = Cv2.CompareHist(Img2, Img3, method);

                return s1coms2;


            }
        }

    }
}
