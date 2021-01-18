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
    class ApiRequestFactory
    {
        private const string ApiUrl = @"https://apic-desktop.musixmatch.com/ws/1.1/";
        private const string AppId = @"web-desktop-app-v1.0";
        public string UserToken { get; private set; }

        private CookieContainer cookieContainer = new CookieContainer();

        private string Request(string _url, string _method = "GET", string _data = "")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url);
            request.Method = _method;
            request.CookieContainer = cookieContainer;
            if (_method == "POST")
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(_data);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
                using (Stream dataStream = request.GetRequestStream())
                    dataStream.Write(byteArray, 0, byteArray.Length);
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            cookieContainer.Add(response.Cookies);
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
            if (arguments != null)
                foreach (var pair in arguments)
                    if (pair.Value != string.Empty)
                        argumentString += $"{pair.Key}={WebUtility.UrlEncode(pair.Value)}&";
            argumentString = argumentString.Remove(argumentString.Length - 1);
            return argumentString;
        }

        public enum ApiMethod
        {
            TokenGet,
            TrackGet,
            TrackLyricsGet,
            TrackSearch,
            TrackSnippetGet,
            TrackSubtitleGet,
            TrackSubtitlePost,
            RequestJwtToken,
            UserGet,
            SpotifyOauthTokenGet,
            TrackLyricsTranslationGet,
            CrowdUserFeedbackGet
        }

        private static Dictionary<ApiMethod, CustomRequestParameters> CustomRequestParameters = new Dictionary<ApiMethod, CustomRequestParameters>()
        {
            [ApiMethod.TokenGet] = new CustomRequestParameters
            {
                EndpointResource = "token.get"
            },
            [ApiMethod.TrackSearch] = new CustomRequestParameters
            {
                EndpointResource = "track.search",
                RequestMethod = "SEARCH"
            },
            [ApiMethod.TrackGet] = new CustomRequestParameters
            {
                EndpointResource = "track.get"
            },
            [ApiMethod.TrackSubtitleGet] = new CustomRequestParameters
            {
                EndpointResource = "track.subtitle.get"
            },
            [ApiMethod.TrackLyricsGet] = new CustomRequestParameters
            {
                EndpointResource = "track.lyrics.get"
            },
            [ApiMethod.TrackSnippetGet] = new CustomRequestParameters
            {
                EndpointResource = "track.snippet.get"
            },
            [ApiMethod.TrackSubtitlePost] = new CustomRequestParameters
            {
                EndpointResource = "track.subtitle.post",
                RequestMethod = "POST"
            },
            [ApiMethod.RequestJwtToken] = new CustomRequestParameters
            {
                EndpointResource = "jwt.get"
            },
            [ApiMethod.UserGet] = new CustomRequestParameters
            {
                EndpointResource = "user.get"
            },
            [ApiMethod.SpotifyOauthTokenGet] = new CustomRequestParameters
            {
                EndpointResource = "spotify.oauthtoken.get"
            },
            [ApiMethod.TrackLyricsTranslationGet] = new CustomRequestParameters
            {
                EndpointResource = "track.lyrics.translation.get"
            },
            [ApiMethod.CrowdUserFeedbackGet] = new CustomRequestParameters
            {
                EndpointResource = "crowd.user.feedback.get"
            },
        };

        public ApiRequestFactory(string userToken)
        {
            UserToken = userToken;
        }

        public MusixmatchApiResponse SendRequest(ApiMethod method, Dictionary<string, string> additionalArguments = null, Dictionary<string, string> data = null)
        {
            CustomRequestParameters requestParameters;

            if (CustomRequestParameters.ContainsKey(method))
                requestParameters = CustomRequestParameters[method];
            else
                requestParameters = new CustomRequestParameters();

            string endpoint = requestParameters.EndpointResource;
            string requestMethod = requestParameters.RequestMethod;

            if (additionalArguments == null)
                additionalArguments = new Dictionary<string, string>();

            additionalArguments.Add("format", "json");
            additionalArguments.Add("app_id", AppId);
            additionalArguments.Add("usertoken", UserToken);
            // TODO: Signatures, GUIDs and Userblobs. They are not checked, but Musixmatch desktop and mobile clients send them tho

            string arguments = GetArgumentString(additionalArguments);
            string dataEncoded = GetArgumentString(data);

            string requestUrl = $"{ApiUrl}{endpoint}{arguments}";
            string response = Request(requestUrl, requestMethod, dataEncoded.Length > 1 ? dataEncoded.Substring(1) : "");

            var responseParsed = JObject.Parse(response);

            return new MusixmatchApiResponse
            {
                StatusCode = responseParsed.SelectToken("$..status_code", false).Value<int>(),
                TimeElapsed = responseParsed.SelectToken("$..execute_time", false).Value<double>(),
                Body = responseParsed.SelectToken("$..body").ToString(),
                Header = responseParsed.SelectToken("$..header").ToString()
            };
        }
    }
}
