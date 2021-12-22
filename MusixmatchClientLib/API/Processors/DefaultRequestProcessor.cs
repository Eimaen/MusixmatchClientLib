using MusixmatchClientLib.Utils;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace MusixmatchClientLib.API.Processors
{
    public class DefaultRequestProcessor : RequestProcessor
    {
        private CookieContainer DefaultCookieContainer = new CookieContainer();

        private string Get(string url, string userAgent)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.CookieContainer = DefaultCookieContainer;
            if (userAgent.Length > 0)
                request.UserAgent = userAgent;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            DefaultCookieContainer.Add(response.Cookies);
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
                return reader.ReadToEnd();
        }

        private const string userAgentsUrl = "https://gist.githubusercontent.com/Eimaen/13515cf326bdfae260bdc065322829f4/raw/f1a84b57904b080832569ace4fc53f3a98a7e24e/common-useragents.txt";

        private string userAgent = string.Empty;

        public override string Get(string url)
        {
            if (userAgent == string.Empty)
            {
                List<string> userAgents = Get(userAgentsUrl, "").Split('\n').ToList(); // ahahahaha ahahhahah ahhahahahahahahahhaha
                userAgent = userAgents.Random();
            }
            return Get(url, userAgent);
        }

        public override string Post(string url, string data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.CookieContainer = DefaultCookieContainer;
            byte[] byteArray = Encoding.UTF8.GetBytes(data);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            using (Stream dataStream = request.GetRequestStream())
                dataStream.Write(byteArray, 0, byteArray.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            DefaultCookieContainer.Add(response.Cookies);
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
                return reader.ReadToEnd();
        }
    }
}
