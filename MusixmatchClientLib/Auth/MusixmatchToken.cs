using MusixmatchClientLib.API;
using MusixmatchClientLib.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusixmatchClientLib.Auth
{
    public class MusixmatchToken
    {
        public string Token { get; private set; }

        /// <summary>
        /// Issues a new Musixmatch token (What a crazy function, 10 second cooldown from one IP)
        /// </summary>
        /// <returns>New Musixmatch token</returns>
        private static string IssueNewToken()
        {
            ApiRequestFactory requestFactory = new ApiRequestFactory("van-darkholme-dungeon-master-performance-artist-deep-dark-fantasies");
            return requestFactory.SendRequest(ApiRequestFactory.ApiMethod.TokenGet, new Dictionary<string, string>()).Cast<TokenGet>().UserToken;
        }

        public MusixmatchToken(string token) => Token = token;
        
        public MusixmatchToken() => Token = IssueNewToken();

        /// <summary>
        /// Creates an url to authorize a token
        /// </summary>
        /// <returns>Auth url</returns>
        public string GetAuthUrl() => $"https://oauth.musixmatch.com/credential/signin?app_id=web-desktop-app-v1.0&usertoken={Token}";
    }
}
