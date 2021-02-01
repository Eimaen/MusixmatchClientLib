using MusixmatchClientLib.API;
using MusixmatchClientLib.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusixmatchClientLib.Auth
{
    public class MusixmatchToken // meme class
    {
        private const string DyscontrolledGalaxy = // Camellia - Dyscontrolled Galaxy (nvm my taste in music has always been so bad)
                          "We are ready to break your reality\n" + //              |\        //                                                    __     ____           __
                          "The reason will turn into insanity\n" + // ---|\--------|-\\----- //    _________  ____________  __     _________  ____/ /__  / __/___ ______/ /_____  _____
            "We blast theese beats to the ears at light speed\n" + // ---|/-------0---\|---- //   / ___/ __ \/ ___/ ___/ / / /    / ___/ __ \/ __  / _ \/ /_/ __ `/ ___/ __/ __ \/ ___/
                                         "There is no gravity\n" + // --/|-------------|---- //  (__  ) /_/ / /  / /  / /_/ /    / /__/ /_/ / /_/ /  __/ __/ /_/ / /__/ /_/ /_/ / /
                                                  "Here we go\n" + // -|-/-\----------0----- // /____/\____/_/  /_/   \__, ( )   \___/\____/\__,_/\___/_/  \__,_/\___/\__/\____/_/
                                          "Dyscontrolled galaxy";  // --\|/----------------- //                      /____/|/  sorry, codefactor

        public string Token { get; private set; }

        /// <summary>
        /// Issues a new Musixmatch token (What a crazy function, 1m cooldown from one IP)
        /// </summary>
        /// <returns>New Musixmatch token</returns>
        private static string IssueNewToken()
        {
            ApiRequestFactory requestFactory = new ApiRequestFactory("van-darkholme-dungeon-master-performance-artist-deep-dark-fantasies" /* TODO: change that stuff and remove dungeonci */);
            return requestFactory.SendRequest(ApiRequestFactory.ApiMethod.TokenGet).Cast<TokenGet>().UserToken;
        }

        public MusixmatchToken(string token) => Token = token;

        public MusixmatchToken() => Token = IssueNewToken();

        /// <summary>
        /// Creates an url to authorize a token
        /// </summary>
        /// <returns>Auth url</returns>
        public string GetAuthUrl() => $"https://oauth.musixmatch.com/credential/signin?app_id=web-desktop-app-v1.0&usertoken={Token}&origin={DyscontrolledGalaxy}"; // origin might be something else, but not null or empty

        /// <summary>
        /// Authenticate using Google's OAuth token
        /// </summary>
        /// <param name="accessToken">Google access token</param>
        public void Authenticate(string accessToken) => ApiRequestFactory.Request($"https://oauth.musixmatch.com/credential/signin?user_type=g2&app_id=web-desktop-app-v1.0&signin=1&origin={DyscontrolledGalaxy}&usertoken={Token}&access_token={accessToken}&code=&refresh_token=&override_host=");

        /// <summary>
        /// Logout from account on this token
        /// </summary>
        public void Deauthenticate() => new ApiRequestFactory(Token).SendRequestLegacy(ApiRequestFactory.ApiMethod.CredentialPost, null, "{\"credential_list\":[]}");

    }
}
