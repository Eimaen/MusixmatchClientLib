using MusixmatchClientLib.API.Contexts;
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
        private static MusixmatchApiContext context = MusixmatchApiContext.Get(ApiContext.Windows);
        public string UserToken { get; private set; }

        private static CookieContainer defaultCookieContainer = new CookieContainer();

        /// <summary>
        /// Function to be used to process requests (useful when debugging your application or using proxy).
        /// </summary>
        public Func<string, string, string, string> RequestProcessor = new Func<string, string, string, string>((string _url, string _method, string _data) =>
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url);
            request.Method = _method;
            request.CookieContainer = defaultCookieContainer;
            if (_method == "POST")
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(_data);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
                using (Stream dataStream = request.GetRequestStream())
                    dataStream.Write(byteArray, 0, byteArray.Length);
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            defaultCookieContainer.Add(response.Cookies);
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        });

        public string RequestFilter(string _url, string _method = "GET", string _data = "") => RequestProcessor(_url, _method, _data);

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
            None,
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
            CrowdUserFeedbackGet,
            TrackLyricsPost,
            ChartTracksGet,
            CrowdPollsTracksSearch,
            CrowdChartUsersGet,
            CrowdUserSuggestionTranslationsGet,
            CrowdUserSuggestionLyricsGet,
            CrowdUserSuggestionSubtitlesGet,
            CrowdUserSuggestionVotesGet,
            AiQuestionPost,
            CredentialPost,
            TrackRichsyncGet,
            TrackRichsyncPost,
            CrowdScoreGet,
            ChartArtistsGet,
            MusicGenresGet,
            AlbumGet,
            AlbumTracksGet,
            ArtistAlbumsGet,
            ArtistGet,
            ArtistSearch
        }

        private static Dictionary<ApiMethod, CustomRequestParameters> CustomRequestParameters = new Dictionary<ApiMethod, CustomRequestParameters>()
        {
            [ApiMethod.TokenGet] = new CustomRequestParameters
            {
                EndpointResource = "token.get"
            },
            [ApiMethod.TrackSearch] = new CustomRequestParameters
            {
                EndpointResource = "track.search"
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
            [ApiMethod.TrackLyricsPost] = new CustomRequestParameters
            {
                EndpointResource = "track.lyrics.post",
                RequestMethod = "POST"
            },
            [ApiMethod.ChartTracksGet] = new CustomRequestParameters
            {
                EndpointResource = "chart.tracks.get"
            },
            [ApiMethod.CrowdPollsTracksSearch] = new CustomRequestParameters
            {
                EndpointResource = "crowd.polls.tracks.search"
            },
            [ApiMethod.AiQuestionPost] = new CustomRequestParameters
            {
                EndpointResource = "crowd.ai.question.post",
                RequestMethod = "POST"
            },
            [ApiMethod.CrowdUserSuggestionLyricsGet] = new CustomRequestParameters
            {
                EndpointResource = "crowd.user.suggestion.lyrics.get"
            },
            [ApiMethod.CrowdUserSuggestionSubtitlesGet] = new CustomRequestParameters
            {
                EndpointResource = "crowd.user.suggestion.subtitles.get"
            },
            [ApiMethod.CrowdUserSuggestionTranslationsGet] = new CustomRequestParameters
            {
                EndpointResource = "crowd.user.suggestion.translations.get"
            },
            [ApiMethod.CrowdUserSuggestionVotesGet] = new CustomRequestParameters
            {
                EndpointResource = "crowd.user.suggestion.votes.get"
            },
            [ApiMethod.CredentialPost] = new CustomRequestParameters
            {
                EndpointResource = "credential.post",
                RequestMethod = "POST"
            },
            [ApiMethod.CrowdChartUsersGet] = new CustomRequestParameters
            {
                EndpointResource = "crowd.chart.users.get"
            },
            [ApiMethod.TrackRichsyncGet] = new CustomRequestParameters
            {
                EndpointResource = "track.richsync.get"
            },
            [ApiMethod.TrackRichsyncPost] = new CustomRequestParameters
            {
                EndpointResource = "track.richsync.post",
                RequestMethod = "POST"
            },
            [ApiMethod.CrowdScoreGet] = new CustomRequestParameters
            {
                EndpointResource = "crowd.score.get"
            },
            [ApiMethod.ChartArtistsGet] = new CustomRequestParameters
            {
                EndpointResource = "chart.artsts.get"
            },
            [ApiMethod.MusicGenresGet] = new CustomRequestParameters
            {
                EndpointResource = "music.genres.get"
            },
            [ApiMethod.AlbumGet] = new CustomRequestParameters
            {
                EndpointResource = "album.get"
            },
            [ApiMethod.AlbumTracksGet] = new CustomRequestParameters
            {
                EndpointResource = "album.tracks.get"
            },
            [ApiMethod.ArtistAlbumsGet] = new CustomRequestParameters
            {
                EndpointResource = "artist.albums.get"
            },
            [ApiMethod.ArtistGet] = new CustomRequestParameters
            {
                EndpointResource = "artist.get"
            },
            [ApiMethod.ArtistSearch] = new CustomRequestParameters
            {
                EndpointResource = "artist.search"
            }
        };

        public ApiRequestFactory(string userToken)
        {
            UserToken = userToken;
        }

        public MusixmatchApiResponse SendRequest(ApiMethod method, Dictionary<string, string> additionalArguments = null, Dictionary<string, string> data = null)
        {
            string dataEncoded = GetArgumentString(data);
            return SendRequestLegacy(method, additionalArguments, dataEncoded.Length > 1 ? dataEncoded.Substring(1) : "");
        }

        public MusixmatchApiResponse SendRequestLegacy(ApiMethod method, Dictionary<string, string> additionalArguments = null, string data = null)
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
            additionalArguments.Add("app_id", context.AppId);
            additionalArguments.Add("usertoken", UserToken);
            // TODO: Signatures, GUIDs and Userblobs. They are not checked, but Musixmatch desktop and mobile clients send them tho

            string arguments = GetArgumentString(additionalArguments);

            string requestUrl = $"{context.ApiUrl}{endpoint}{arguments}";
            string response = RequestFilter(requestUrl, requestMethod, data);

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
