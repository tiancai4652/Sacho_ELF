using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identify_OpenCV
{
    public class Identify
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
        public static void CompareImage(string sourceImahe, string targetImage, TemplateMatchModes templateMatchMode, out double minx, double max)
        {
            Mat mat1 = new Mat(sourceImahe, ImreadModes.AnyColor);
            Mat mat2 = new Mat(targetImage, ImreadModes.AnyColor);
            Mat mat3 = new Mat();
            mat3.Create(mat1.Cols - mat2.Cols + 1, mat1.Rows - mat2.Cols + 1, MatType.CV_32FC1);
            Cv2.MatchTemplate(mat1, mat2, mat3, templateMatchMode);
            Cv2.Normalize(mat3, mat3, 1, 0, NormTypes.MinMax, -1);
            Point minLocation, maxLocation;
            Cv2.MinMaxLoc(mat3, out minx, out max, out minLocation, out maxLocation);
        }
    }
}
