using System.Security.Cryptography;
using System.Net.Http;
using System;
using System.Web;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Text;

namespace ami.Helper
{
    public class TranslationHelper
    {
        string appID ="20180707000183643";
        string secret = "fg_PisB2ZVvN9Ir9pNM_";
        Uri baseUri = new Uri("https://fanyi-api.baidu.com");

        public TranslationHelper()
        {
            
        }

        public async Task<string> Translate(string content, string from, string to)
        {
            var client = new HttpClient();
            client.BaseAddress = baseUri;
            var salt = new Random().Next(32768, 65536);
            var sign = GetMd5Hash( appID + content + salt + secret);
            content = HttpUtility.UrlEncode(content);
            var response = await client.GetAsync("/api/trans/vip/translate?appid=" + appID + "&q=" + content + "&from=" +
                            from + "&to=" + to + "&salt=" + salt + "&sign=" + sign);
            dynamic responseString = await response.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(responseString);
            return (string)jsonObject["trans_result"][0]["dst"];
        }

        string GetMd5Hash( string input)
        {
            var md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString().ToLower();
        }

    }
}
