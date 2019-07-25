using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            xx();
        }


        static void xx()
        {
            try
            {
                string Json;
                var APP_ID = "123456";
                var API_KEY = "wekdnFOhKEfK3hAdE3thjKrz";
                var SECRET_KEY = "7bITH3Xumw0ST29uepqB2fz3Nn3ZD1x5";
                var client = new Baidu.Aip.Ocr.Ocr(API_KEY, SECRET_KEY);
                client.Timeout = 60000;
                var image = File.ReadAllBytes(@"C:\Users\Administrator\Desktop\新建文件夹\esc.png");
                var result = client.GeneralBasic(image);
                Console.WriteLine(result);
                // 如果有可选参数
                var options = new Dictionary<string, object>
                {
                    {"language_type", "CHN_ENG"},
                    //{"detect_direction", "true"},
                    //{"detect_language", "true"},
                    //{"probability", "true"}
                };

                result = client.GeneralBasic(image, options);

                var words = result["words_result"];
                var list = words.Select(t => t.Last).Select(x=>x["words"]);

                //Console.WriteLine(result);
                //richTextBox1.Text = result.ToString();
                Json = result.ToString();

            }
            catch (Exception ex)
            {
                
               
            }


        }
    }
}
