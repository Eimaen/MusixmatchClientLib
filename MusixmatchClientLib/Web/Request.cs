using System.IO;
using System.Net;
using System.Threading.Tasks;
using MusixmatchClientLib.Enum;

namespace MusixmatchClientLib.Web
{
    public class Request
    {
        private readonly RequestData.RequestData _requestData;

        public Request(RequestData.RequestData requestData)
        {
            this._requestData = requestData;
        }

        public Request(string url) : this(new RequestData.RequestData(url, string.Empty)) {}

        public ResponseData.ResponseData GetResponse()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this._requestData.Uri);

            request.Headers = this._requestData.Header;
            request.Method = this._requestData.RequestMethod.ToString();
            request.ContentType += this._requestData.ConvertFromContentType(request.ContentType, this._requestData.ContentType);
            request.ContentType += this._requestData.ConvertFromEncodingTypes(request.ContentType, this._requestData.EncodingTypes);
            request.UserAgent = this._requestData.UserAgent;
            request.Accept = this._requestData.Accept;
            request.CookieContainer = this._requestData.CookieContainer;

            if (this._requestData.RequestMethod == EnumRequestMethod.POST)
            {
                request.ContentLength = this._requestData.Content.Length;

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(this._requestData.Content, 0, this._requestData.Content.Length);
                }
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();

            if (stream == null)
                return null;

            ResponseData.ResponseData responseData = new ResponseData.ResponseData(response, string.Empty, HttpStatusCode.NoContent);

            using (StreamReader reader = new StreamReader(stream, responseData.Encoding))
            {
                responseData = new ResponseData.ResponseData(response, reader.ReadToEnd(), response.StatusCode);
            }

            return responseData;
        }

        public async Task<ResponseData.ResponseData> GetResponseAsync()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this._requestData.Uri);

            request.Headers = this._requestData.Header;
            request.Method = this._requestData.RequestMethod.ToString();
            request.ContentType += this._requestData.ConvertFromContentType(request.ContentType, this._requestData.ContentType);
            request.ContentType += this._requestData.ConvertFromEncodingTypes(request.ContentType, this._requestData.EncodingTypes);
            request.UserAgent = this._requestData.UserAgent;
            request.Accept = this._requestData.Accept;
            request.CookieContainer = this._requestData.CookieContainer;

            if (this._requestData.RequestMethod == EnumRequestMethod.POST)
            {
                request.ContentLength = this._requestData.Content.Length;

                using (Stream requestStream = request.GetRequestStream())
                {
                    await requestStream.WriteAsync(this._requestData.Content, 0, this._requestData.Content.Length);
                }
            }

            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            Stream stream = response.GetResponseStream();

            if (stream == null)
                return null;

            ResponseData.ResponseData responseData = new ResponseData.ResponseData(response, string.Empty, HttpStatusCode.NoContent);

            using (StreamReader reader = new StreamReader(stream, responseData.Encoding))
            {
                responseData = new ResponseData.ResponseData(response, await reader.ReadToEndAsync(), response.StatusCode);
            }

            return responseData;
        }
    }
}
