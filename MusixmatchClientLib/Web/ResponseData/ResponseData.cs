using System;
using System.Net;
using System.Text;

namespace MusixmatchClientLib.Web.ResponseData
{
    [Serializable]
    public class ResponseData
    {
        private byte[] _content;
        private HttpStatusCode _httpStatusCode;
        private HttpWebResponse _response;
        private Encoding _encoding;

        public ResponseData(HttpWebResponse response, byte[] content, Encoding encoding , HttpStatusCode httpStatusCode)
        {
            this._response = response;
            this._content = content;
            this._encoding = encoding;
            this._httpStatusCode = httpStatusCode;
        }

        public ResponseData(HttpWebResponse response, string content, HttpStatusCode httpStatusCode) : 
            this(response, 
                string.IsNullOrEmpty(response.CharacterSet) ?
                Encoding.Default.GetBytes(content) :
                Encoding.GetEncoding(response.CharacterSet).GetBytes(content), 
                string.IsNullOrEmpty(response.CharacterSet) ?
                Encoding.Default :
                Encoding.GetEncoding(response.CharacterSet), httpStatusCode) { }

        public HttpWebResponse Response
        {
            get { return this._response; }
            set { this._response = value; }
        }

        public string GetContentAsString()
        {
            Encoding encoding = Encoding.Default;

            if (!string.IsNullOrEmpty(this._response.CharacterSet))
            {
                encoding = Encoding.GetEncoding(this._response.CharacterSet);
            }

            return encoding.GetString(this._content);
        }

        public byte[] Content
        {
            get { return this._content; }
        }

        public HttpStatusCode StatusCode
        {
            get { return this._httpStatusCode; }
        }

        public Encoding Encoding
        {
            get => this._encoding;
        }
    }
}
