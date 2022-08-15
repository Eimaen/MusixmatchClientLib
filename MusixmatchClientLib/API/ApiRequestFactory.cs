using MusixmatchClientLib.API.Contexts;
using MusixmatchClientLib.API.Model;
using MusixmatchClientLib.API.Model.Exceptions;
using MusixmatchClientLib.API.Processors;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MusixmatchClientLib.API
{
    internal class ApiRequestFactory
    {
        public MusixmatchApiContext Context { get; private set; } = MusixmatchApiContext.Get(ApiContext.Desktop);

        public string UserToken { get; private set; }

        public bool AssertOnError { get; set; } = true;

        /// <summary>
        /// Class to be used to process requests (useful when debugging your application or using proxy).
        /// </summary>
        public RequestProcessor RequestProcessor = new DefaultRequestProcessor();

        private static string GetArgumentString(Dictionary<string, string> arguments)
        {
            string argumentString = "?";
            if (arguments != null)
                foreach (var pair in arguments)
                    if (pair.Value != string.Empty)
                        argumentString += $"{pair.Key}={Uri.EscapeUriString(pair.Value)}&"; // WARN: Untested
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
            TrackLyricsTranslationPost,
            CrowdUserFeedbackGet,
            CrowdFeedbackGet,
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
            ArtistSearch,
            CrowdUserProfilePost
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
                RequestMethod = RequestMethod.POST
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
            [ApiMethod.TrackLyricsTranslationPost] = new CustomRequestParameters
            {
                EndpointResource = "track.lyrics.translation.post",
                RequestMethod = RequestMethod.POST
            },
            [ApiMethod.CrowdUserFeedbackGet] = new CustomRequestParameters
            {
                EndpointResource = "crowd.user.feedback.get"
            },
            [ApiMethod.CrowdFeedbackGet] = new CustomRequestParameters
            {
                EndpointResource = "crowd.feedback.get"
            },
            [ApiMethod.TrackLyricsPost] = new CustomRequestParameters
            {
                EndpointResource = "track.lyrics.post",
                RequestMethod = RequestMethod.POST
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
                RequestMethod = RequestMethod.POST
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
                RequestMethod = RequestMethod.POST
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
                RequestMethod = RequestMethod.POST
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
            },
            [ApiMethod.CrowdUserProfilePost] = new CustomRequestParameters
            {
                EndpointResource = "crowd.user.profile.post",
                RequestMethod = RequestMethod.POST
            }
        };

        private Guid UserGuid;

        public ApiRequestFactory(string userToken, ApiContext context = ApiContext.Desktop)
        {
            UserToken = userToken;
            UserGuid = Guid.NewGuid();
            Context = MusixmatchApiContext.Get(context);
        }

        public MusixmatchApiResponse SendRequest(ApiMethod method, Dictionary<string, string> additionalArguments = null, Dictionary<string, string> data = null)
        {
            string dataEncoded = GetArgumentString(data);
            return SendRequestLegacy(method, additionalArguments, dataEncoded.Length > 1 ? dataEncoded.Substring(1) : "");
        }

        public async Task<MusixmatchApiResponse> SendRequestAsync(ApiMethod method, Dictionary<string, string> additionalArguments = null, Dictionary<string, string> data = null)
        {
            string dataEncoded = GetArgumentString(data);
            return await SendRequestLegacyAsync(method, additionalArguments, dataEncoded.Length > 1 ? dataEncoded.Substring(1) : "");
        }

        private static string HmacSignature(string input, string key) => Convert.ToBase64String(new HMACSHA1(Encoding.ASCII.GetBytes(key)).ComputeHash(Encoding.ASCII.GetBytes(input)));

        public static string SignRequestUrl(string url)
        {
            const string key = "8d2899b2aebb97a69a4a85cc991c0b6713a1d9e2";
            string signature = Uri.EscapeDataString(HmacSignature(url + DateTime.Now.ToString("yyyyMMdd"), key));
            string algo = "sha1";
            return $"{url}&signature={signature}&signature_protocol={algo}";
        }

        public MusixmatchApiResponse SendRequestLegacy(ApiMethod method, Dictionary<string, string> additionalArguments = null, string data = null)
        {
            CustomRequestParameters requestParameters;

            if (CustomRequestParameters.ContainsKey(method))
                requestParameters = CustomRequestParameters[method];
            else
                requestParameters = new CustomRequestParameters();

            string endpoint = requestParameters.EndpointResource;

            if (additionalArguments == null)
                additionalArguments = new Dictionary<string, string>();

            additionalArguments.Add("format", "json");
            additionalArguments.Add("app_id", Context.AppId);
            additionalArguments.Add("usertoken", UserToken);

            additionalArguments.Add("guid", UserGuid.ToString());

            string arguments = GetArgumentString(additionalArguments);

            string requestUrl = SignRequestUrl($"{Context.ApiUrl}{endpoint}{arguments}");
            Console.WriteLine(requestUrl);

            string response = string.Empty;
            switch (requestParameters.RequestMethod)
            {
                case RequestMethod.GET:
                    response = RequestProcessor.Get(requestUrl);
                    break;
                case RequestMethod.POST:
                    response = RequestProcessor.Post(requestUrl, data);
                    break;
            }

            var responseParsed = JObject.Parse(response);
            var statusCode = responseParsed.SelectToken("$..status_code", false).Value<int>(); // I guess, that value always exists

            if (statusCode != 200 && AssertOnError)
                throw new MusixmatchRequestException((Model.Types.StatusCode)statusCode);

            return new MusixmatchApiResponse
            {
                StatusCode = statusCode,
                TimeElapsed = responseParsed.SelectToken("$..execute_time", false).Value<double>(),
                Body = responseParsed.SelectToken("$..body").ToString(),
                Header = responseParsed.SelectToken("$..header").ToString()
            };
        }

        public async Task<MusixmatchApiResponse> SendRequestLegacyAsync(ApiMethod method, Dictionary<string, string> additionalArguments = null, string data = null)
        {
            CustomRequestParameters requestParameters;

            if (CustomRequestParameters.ContainsKey(method))
                requestParameters = CustomRequestParameters[method];
            else
                requestParameters = new CustomRequestParameters();

            string endpoint = requestParameters.EndpointResource;

            if (additionalArguments == null)
                additionalArguments = new Dictionary<string, string>();

            additionalArguments.Add("format", "json");
            additionalArguments.Add("app_id", Context.AppId);
            additionalArguments.Add("usertoken", UserToken);

            additionalArguments.Add("guid", UserGuid.ToString());

            string arguments = GetArgumentString(additionalArguments);

            string requestUrl = SignRequestUrl($"{Context.ApiUrl}{endpoint}{arguments}");

            string response = string.Empty;
            switch (requestParameters.RequestMethod)
            {
                case RequestMethod.GET:
                    response = await RequestProcessor.GetAsync(requestUrl);
                    break;
                case RequestMethod.POST:
                    response = await RequestProcessor.PostAsync(requestUrl, data);
                    break;
            }

            var responseParsed = JObject.Parse(response);
            var statusCode = responseParsed.SelectToken("$..status_code", false).Value<int>(); // I guess, that value always exists

            if (statusCode != 200 && AssertOnError)
                throw new MusixmatchRequestException((Model.Types.StatusCode)statusCode);

            return new MusixmatchApiResponse
            {
                StatusCode = statusCode,
                TimeElapsed = responseParsed.SelectToken("$..execute_time", false).Value<double>(),
                Body = responseParsed.SelectToken("$..body").ToString(),
                Header = responseParsed.SelectToken("$..header").ToString()
            };
        }
    }
}