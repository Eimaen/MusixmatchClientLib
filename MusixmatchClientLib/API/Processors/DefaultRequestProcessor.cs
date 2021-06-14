using System.IO;
using System.Net;
using System.Text;

namespace MusixmatchClientLib.API.Processors
{
    public class DefaultRequestProcessor : RequestProcessor
    {
        private CookieContainer DefaultCookieContainer = new CookieContainer();

        public override string Get(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.CookieContainer = DefaultCookieContainer;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            DefaultCookieContainer.Add(response.Cookies);
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
                return reader.ReadToEnd();
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
