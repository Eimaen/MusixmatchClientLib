using MusixmatchClientLib.Utils;
using MusixmatchClientLib.Web.Cookie;
using MusixmatchClientLib.Web.RequestData;
using MusixmatchClientLib.Web;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using MusixmatchClientLib.Enum;
using MusixmatchClientLib.Web.ResponseData;
using System.Threading.Tasks;
using System;

namespace MusixmatchClientLib.API.Processors
{
    public class DefaultRequestProcessor : RequestProcessor
    {
        public override string Get(string url)
        {
            RequestData requestData = new RequestData(url);

            requestData.UserAgent = RequestData.GetRandomUseragent();
            requestData.CookieContainer = GlobalCookieContainer.INSTANCE.GetCookieContainer(this);

            Request r = new Request(requestData);
            return r.GetResponse().GetContentAsString();
        }

        public override string Post(string url, string data)
        {
            RequestData requestData = new RequestData(
                new Uri(url),
                EnumRequestMethod.POST,
                new EnumContentType[]
                {
                    EnumContentType.FORM
                }, new EnumEncodingType[] { EnumEncodingType.UTF8 },
                data,
                RequestData.GetRandomUseragent());

            requestData.CookieContainer = GlobalCookieContainer.INSTANCE.GetCookieContainer(this);

            Request r = new Request(requestData);

            ResponseData response = r.GetResponse();
            return response.GetContentAsString();
        }

        public override async Task<string> PostAsync(string url, string data)
        {
            RequestData requestData = new RequestData(
                new Uri(url),
                EnumRequestMethod.POST,
                new EnumContentType[]
                {
                    EnumContentType.FORM
                }, new EnumEncodingType[] { EnumEncodingType.UTF8 },
                data,
                RequestData.GetRandomUseragent());

            requestData.CookieContainer = GlobalCookieContainer.INSTANCE.GetCookieContainer(this);

            Request r = new Request(requestData);

            ResponseData response = await r.GetResponseAsync();
            return response.GetContentAsString();
        }

        public override async Task<string> GetAsync(string url)
        {
            RequestData requestData = new RequestData(url);

            requestData.UserAgent = RequestData.GetRandomUseragent();
            requestData.CookieContainer = GlobalCookieContainer.INSTANCE.GetCookieContainer(this);

            Request r = new Request(requestData);
            ResponseData responseData = await r.GetResponseAsync();

            return responseData.GetContentAsString();
        }
    }
}
