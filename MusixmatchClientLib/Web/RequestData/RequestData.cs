using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using MusixmatchClientLib.Enum;
using MusixmatchClientLib.Web.RequestData.Data;

namespace MusixmatchClientLib.Web.RequestData
{
    [Serializable]
    public class RequestData
    {
        private EnumRequestMethod _requestMethod;
        private EnumContentType[] _contentType;
        private EnumEncodingType[] _encodingType;
        private byte[] _content;
        private Uri _uri;
        private string _userAgent;
        private string _accept;
        private WebHeaderCollection _header;
        private CookieContainer _cookieContainer;

        public RequestData(Uri uri, EnumRequestMethod requestMethod, EnumContentType[] contentType, EnumEncodingType[] encodingType, byte[] content, string userAgent)
        {
            this._uri = uri;
            this._content = content;
            this._requestMethod = requestMethod;
            this._contentType = contentType;
            this._encodingType = encodingType;
            this._userAgent = userAgent;
            this._cookieContainer = new CookieContainer();
            this._header = new WebHeaderCollection();
        }

        public RequestData(Uri uri, EnumRequestMethod requestMethod, EnumContentType[] contentType, EnumEncodingType[] encodingType, string content, string userAgent) :
            this(
                uri,
                requestMethod,
                contentType,
                encodingType,
                encodingType.Contains(EnumEncodingType.UTF8) ? Encoding.UTF8.GetBytes(content) : Encoding.Default.GetBytes(content),
                userAgent
                ) { }

        public RequestData(Uri uri, EnumRequestMethod requestMethod, EnumContentType[] contentType, EnumEncodingType[] encodingType, string content) : 
            this(
                uri, 
                requestMethod, 
                contentType, 
                encodingType,
                encodingType.Contains(EnumEncodingType.UTF8) ? Encoding.UTF8.GetBytes(content) : Encoding.Default.GetBytes(content), 
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36"
                ) { }

        public RequestData(Uri uri, EnumRequestMethod requestMethod, EnumContentType[] contentType, EnumEncodingType[] encodingType, List<FormKeypair> formData) :
            this(
                uri,
                requestMethod,
                contentType,
                encodingType,
                encodingType.Contains(EnumEncodingType.UTF8) ? Encoding.UTF8.GetBytes(ClampKeypairsToString(formData)) : Encoding.Default.GetBytes(ClampKeypairsToString(formData)),
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36"
            )
        { }

        public RequestData(string uri, string content) : 
            this(
                new Uri(uri), 
                EnumRequestMethod.GET, 
                new EnumContentType[] { EnumContentType.HTML }, 
                new EnumEncodingType[] { EnumEncodingType.UTF8 },
                Encoding.Default.GetBytes(content), 
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36"
                ) { }

        public RequestData(string uri) :
           this(
               new Uri(uri), 
               EnumRequestMethod.GET,
               new EnumContentType[] { EnumContentType.HTML },
               new EnumEncodingType[] { EnumEncodingType.UTF8 },
               Encoding.Default.GetBytes(string.Empty), 
               "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36"
               ) { }

        public static string GetRandomUseragent()
        {
            List<string> userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (iPad; CPU OS 7_2_1 like Mac OS X; en-US) AppleWebKit/531.43.4 (KHTML, like Gecko) Version/3.0.5 Mobile/8B112 Safari/6531.43.4");
            userAgents.Add("Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10_8_7) AppleWebKit/5351 (KHTML, like Gecko) Chrome/37.0.881.0 Mobile Safari/5351");
            userAgents.Add("Mozilla/5.0 (Windows CE) AppleWebKit/5330 (KHTML, like Gecko) Chrome/37.0.896.0 Mobile Safari/5330");
            userAgents.Add("Mozilla/5.0 (compatible; MSIE 6.0; Windows NT 4.0; Trident/4.0)");
            userAgents.Add("Opera/8.57 (X11; Linux x86_64; en-US) Presto/2.10.234 Version/11.00");
            userAgents.Add("Mozilla/5.0 (X11; Linux i686) AppleWebKit/5331 (KHTML, like Gecko) Chrome/40.0.842.0 Mobile Safari/5331");
            userAgents.Add("Mozilla/5.0 (iPad; CPU OS 8_1_2 like Mac OS X; sl-SI) AppleWebKit/533.27.6 (KHTML, like Gecko) Version/3.0.5 Mobile/8B114 Safari/6533.27.6");
            userAgents.Add("Opera/9.63 (X11; Linux i686; sl-SI) Presto/2.12.215 Version/11.00");
            userAgents.Add("Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10_8_9) AppleWebKit/5340 (KHTML, like Gecko) Chrome/40.0.816.0 Mobile Safari/5340");
            userAgents.Add("Mozilla/5.0 (iPhone; CPU iPhone OS 8_2_1 like Mac OS X; en-US) AppleWebKit/535.45.2 (KHTML, like Gecko) Version/3.0.5 Mobile/8B111 Safari/6535.45.2");
            userAgents.Add("Mozilla/5.0 (Windows NT 5.2) AppleWebKit/5362 (KHTML, like Gecko) Chrome/39.0.880.0 Mobile Safari/5362");
            userAgents.Add("Mozilla/5.0 (iPad; CPU OS 7_2_1 like Mac OS X; en-US) AppleWebKit/532.5.1 (KHTML, like Gecko) Version/3.0.5 Mobile/8B119 Safari/6532.5.1");
            userAgents.Add("Opera/8.23 (Windows NT 5.01; en-US) Presto/2.12.266 Version/12.00");
            userAgents.Add("Mozilla/5.0 (compatible; MSIE 9.0; Windows 98; Trident/5.1)");
            userAgents.Add("Opera/8.87 (Windows NT 6.1; sl-SI) Presto/2.11.204 Version/10.00");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 6.1) AppleWebKit/534.9.5 (KHTML, like Gecko) Version/4.0.1 Safari/534.9.5");
            userAgents.Add("Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 5.2; Trident/4.1)");
            userAgents.Add("Mozilla/5.0 (Windows NT 5.01; en-US; rv:1.9.1.20) Gecko/20140618 Firefox/35.0");
            userAgents.Add("Opera/9.64 (Windows 98; Win 9x 4.90; en-US) Presto/2.10.219 Version/12.00");
            userAgents.Add("Mozilla/5.0 (iPhone; CPU iPhone OS 7_0_2 like Mac OS X; en-US) AppleWebKit/535.7.5 (KHTML, like Gecko) Version/4.0.5 Mobile/8B113 Safari/6535.7.5");
            userAgents.Add("Mozilla/5.0 (Windows NT 6.1) AppleWebKit/5330 (KHTML, like Gecko) Chrome/37.0.885.0 Mobile Safari/5330");
            userAgents.Add("Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10_8_2 rv:3.0; sl-SI) AppleWebKit/534.17.2 (KHTML, like Gecko) Version/5.1 Safari/534.17.2");
            userAgents.Add("Mozilla/5.0 (Macintosh; PPC Mac OS X 10_6_0 rv:3.0) Gecko/20120102 Firefox/37.0");

            return userAgents[new Random().Next(0, userAgents.Count)];
        }

        public static string ClampKeypairsToString(List<FormKeypair> keypairs)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < keypairs.Count; i++)
            {
                FormKeypair keypair = keypairs[i];

                if (i == 0)
                {
                    sb.Append(keypair.Key + "=" + keypair.Value);
                }
                else
                {
                    sb.Append("&" + keypair.Key + "=" + keypair.Value);
                }
            }

            return sb.ToString();
        }

        public string ConvertFromContentType(string existingContentType, EnumContentType[] requestType)
        {
            for (int i = 0; i < requestType.Length; i++)
            {
                string content = ContentTypeToString(requestType[i]);

                if (!content.Equals(string.Empty))
                {
                    existingContentType += content + (i == requestType.Length ? string.Empty : "; ");
                }
            }

            return existingContentType;
        }

        public string ConvertFromEncodingTypes(string existingContentType, EnumEncodingType[] encodingType)
        {
            existingContentType += "charset=";
            for (int i = 0; i < encodingType.Length; i++)
            {
                string content = ContentEncodingType(encodingType[i]);

                if (!content.Equals(string.Empty))
                {
                    existingContentType += content + (i == encodingType.Length ? ", " : "");
                }
            }

            return existingContentType;
        }

        private string ContentTypeToString(EnumContentType contentType)
        {
            switch (contentType)
            {
                case EnumContentType.JSON:
                    return "application/json";
                case EnumContentType.FORM:
                    return "application/x-www-form-urlencoded";
            }

            return string.Empty;
        }

        private string ContentEncodingType(EnumEncodingType contentType)
        {
            switch (contentType)
            {
                case EnumEncodingType.UTF8:
                    return "utf-8";
            }

            return string.Empty;
        }

        private string ConvertToEnumString(EnumAuthType e)
        {
            if (e == EnumAuthType.BASIC)
                return "Basic";

            if (e == EnumAuthType.OAUTH2)
                return "Bearer";

            return string.Empty;
        }

        public void AddAuthMethod(Data.Auth auth)
        {
            string enumString = ConvertToEnumString(auth.AuthType);
            this.Header.Add("Authorization", enumString + " " + auth.Token);
        }

        public CookieContainer CookieContainer
        {
            get { return this._cookieContainer; }
            set { this._cookieContainer = value; }
        }

        public EnumRequestMethod RequestMethod
        {
            get { return this._requestMethod; }
            set { this._requestMethod = value; }
        }

        public byte[] Content
        {
            get { return _content; }
            set { this._content = value; }
        }

        public Uri Uri
        {
            get { return this._uri; }
            set { this._uri = value; }
        }

        public string UserAgent
        {
            get { return this._userAgent; }
            set { this._userAgent = value; }
        }

        public string Accept
        {
            get { return this._accept; }
            set { this._accept = value; }
        }

        public WebHeaderCollection Header
        {
            get { return this._header; }
            set { this._header = value; }
        }

        public EnumContentType[] ContentType
        {
            get { return this._contentType; }
            set { this._contentType = value; }
        }

        public EnumEncodingType[] EncodingTypes
        {
            get { return this._encodingType; }
            set { this._encodingType = value; }
        }
    }
}
