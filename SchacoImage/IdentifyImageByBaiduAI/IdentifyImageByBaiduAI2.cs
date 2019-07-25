using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentifyImageByBaiduAI
{
    public class IdentifyImageByBaiduAI2
    {
        public static JObject GetWordInImage(string imagePath)
        {
            try
            {
                string Json;
                //var APP_ID = "123456";
                var API_KEY = "wekdnFOhKEfK3hAdE3thjKrz";
                var SECRET_KEY = "7bITH3Xumw0ST29uepqB2fz3Nn3ZD1x5";
                var client = new Baidu.Aip.Ocr.Ocr(API_KEY, SECRET_KEY);
                client.Timeout = 60000;
                var image = File.ReadAllBytes(imagePath);
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
                //var words = result["words_result"];
                //var list = words.Select(t => t.Last).Select(x => x["words"]);

                ////Console.WriteLine(result);
                ////richTextBox1.Text = result.ToString();
                //Json = result.ToString();
                return result;
            }
            catch (Exception ex)
            {

                return null;
            }


        }

        /// <summary>
        /// 识别图片中的文字，是否满足要求
        /// </summary>
        /// <param name="imagePath">图片路径</param>
        /// <param name="wordsCount">判断条件：文字行数</param>
        /// <param name="container">判断条件：文字中可能包含的字符串</param>
        /// <returns></returns>
        public static bool Identify(string imagePath, int wordsCount, string[] container)
        {
            try
            {
                var jobject = GetWordInImage(imagePath);
                if (jobject != null)
                {
                    if ((int)jobject["words_result_num"] == wordsCount)
                    {
                        if (container == null)
                        {
                            return true;
                        }
                        else
                        {
                            var Json = jobject.ToString();
                            foreach (var item in container)
                            {
                                if (Json.Contains(item))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// 识别图片中的文字，判断条件大于给定的行数
        /// </summary>
        /// <param name="imagePath">图片路径</param>
        /// <param name="wordsCount">判断条件：文字行数</param>
        /// <returns></returns>
        public static bool IdentifyByOverRowCount(string imagePath, int wordsCount)
        {
            try
            {
                var jobject = GetWordInImage(imagePath);
                if (jobject != null)
                {
                    if ((int)jobject["words_result_num"] > wordsCount)
                    {
                        return true; ;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
