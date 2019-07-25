using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace TessdataIdentify
{
    public class Identify
    {
        //调用tesseract实现OCR识别
        public static string ImageToText(string imgPath)
        {
            using (var engine = new TesseractEngine("tessdata", "chi_sim", EngineMode.Default))
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
