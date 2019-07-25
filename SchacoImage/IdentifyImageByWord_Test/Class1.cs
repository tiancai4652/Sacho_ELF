using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace IdentifyImageByWord_Test
{
    public class Class1
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
