using MusixmatchClientLib.API.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MusixmatchClientLib.API
{
    public class ApiRequestFactory
    {
        private const string ApiUrl = @"https://apic-desktop.musixmatch.com/ws/1.1/";
        private const string AppId = @"web-desktop-app-v1.0";
        public string UserToken { get; private set; }

        private string Fetch(string _url)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(_url);
            request.CookieContainer = new CookieContainer();
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        private string GetArgumentString(Dictionary<string, string> arguments)
        {
            string argumentString = "?";
            foreach (var pair in arguments)
                argumentString += $"{pair.Key}={WebUtility.UrlEncode(pair.Value)}&";
            argumentString = argumentString.Remove(argumentString.Length - 1);
            return argumentString;
        }

        public enum ApiMethod
        {
            TrackGet,
            TrackLyricsGet,
            TrackSearch,
            TrackSnippetGet,
            TrackSubtitleGet
        }

        private static Dictionary<ApiMethod, string> Endpoints = new Dictionary<ApiMethod, string>()
        {
            [ApiMethod.TrackSearch] = "track.search",
            [ApiMethod.TrackGet] = "track.get",
            [ApiMethod.TrackSubtitleGet] = "track.subtitle.get",
            [ApiMethod.TrackLyricsGet] = "track.lyrics.get",
            [ApiMethod.TrackSnippetGet] = "track.snippet.get",
        };

        public ApiRequestFactory(string userToken)
        {
            UserToken = userToken;
        }

        public MusixmatchApiResponse SendRequest(ApiMethod method, Dictionary<string, string> additionalArguments)
        {
            string endpoint = Endpoints[method];

            additionalArguments.Add("format", "json");
            additionalArguments.Add("app_id", AppId);
            additionalArguments.Add("usertoken", UserToken);
            // TODO: Signatures, GUIDs and Userblobs. They are not checked, but Musixmatch desktop and mobile clients send them tho

            string arguments = GetArgumentString(additionalArguments);

            string requestUrl = $"{ApiUrl}{endpoint}{arguments}";
            string response = Fetch(requestUrl);

            var responseParsed = JObject.Parse(response);

            MusixmatchApiResponse apiResponse = new MusixmatchApiResponse
            {
                StatusCode = responseParsed.SelectToken("$..status_code", false).Value<int>(),
                TimeElapsed = responseParsed.SelectToken("$..execute_time", false).Value<double>(),
                Body = responseParsed.SelectToken("$..body").ToString()
            };

            return apiResponse;
        }
    }
}
