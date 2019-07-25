using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace IdentifyImageByWord
{
    /// <summary>
    /// 使用开源库Tesseract进行图片中的文字识别
    /// 未测试，因为训练库未下载完
    /// https://www.cnblogs.com/tuyile006/p/10772584.html
    /// </summary>
    public class IdentifyImageByWord
    {
        //调用tesseract实现OCR识别
        public string ImageToText(string imgPath)
        {
            using (var engine = new TesseractEngine("tessdata", "eng", EngineMode.Default))
            {
                using (var img = Pix.LoadFromFile(imgPath))
                {
                    using (var page = engine.Process(img))
                    {
                        return page.GetText();
                    }
                }
            }
        }
    }
}
