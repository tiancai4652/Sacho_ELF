using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace IdentifyImageByBaiduAI
{
    public class IdentifyImageByBaiduAI
    {
        // 通用文字识别
        public static string Identify(string fileName)
        {

            string token = BaiduAIInfo.AccessTakenStr;
            string strbaser64 = ConvertBase64(fileName); // 图片的base64编码
            string host = "https://aip.baidubce.com/rest/2.0/ocr/v1/handwriting?access_token=" + token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.ContentType = "application/x-www-form-urlencoded";
            request.KeepAlive = true;
            String str = "image=" + HttpUtility.UrlEncode(strbaser64);
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string result = reader.ReadToEnd();
            Console.WriteLine("通用文字识别:");
            Console.WriteLine(result);
            return result;
        }


        static string ConvertBase64(string fileName)
        {
            //将图片转换成base64 数据
            FileStream fs = File.OpenRead(fileName); //OpenRead
            int filelength = 0;
            filelength = (int)fs.Length; //获得文件长度 
            Byte[] image = new Byte[filelength]; //建立一个字节数组 
            fs.Read(image, 0, filelength); //按字节流读取 
            //System.Drawing.Image result = System.Drawing.Image.FromStream(fs);
            fs.Close();
            string imgData64 = Convert.ToBase64String(image);
            return imgData64;
        }

    }
}
