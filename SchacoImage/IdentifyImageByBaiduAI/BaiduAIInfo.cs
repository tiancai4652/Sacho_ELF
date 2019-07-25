using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IdentifyImageByBaiduAI
{
   public class BaiduAIInfo
    {
        static string _AccessTakenStr;
        public static string AccessTakenStr
        {
            get
            {
                if (string.IsNullOrEmpty(_AccessTakenStr))
                {
                    _AccessTakenStr = getAccessToken();
                }
                return _AccessTakenStr;
            }
        }


        // 百度云中开通对应服务应用的 API Key 建议开通应用的时候多选服务
        private static String clientId = "wekdnFOhKEfK3hAdE3thjKrz";
        // 百度云中开通对应服务应用的 Secret Key
        private static String clientSecret = "7bITH3Xumw0ST29uepqB2fz3Nn3ZD1x5";

        static String getAccessToken()
        {
            String authHost = "https://aip.baidubce.com/oauth/2.0/token"; 
            HttpClient client = new HttpClient();
            List<KeyValuePair<String, String>> paraList = new List<KeyValuePair<string, string>>();
            paraList.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            paraList.Add(new KeyValuePair<string, string>("client_id", clientId));
            paraList.Add(new KeyValuePair<string, string>("client_secret", clientSecret));

            HttpResponseMessage response = client.PostAsync(authHost, new FormUrlEncodedContent(paraList)).Result;
            String result = response.Content.ReadAsStringAsync().Result;
/*            Console.WriteLine(result)*/;

            JObject items = JsonConvert.DeserializeObject<JObject>(result);
            return (string)items["access_token"];
        }
    }
}
