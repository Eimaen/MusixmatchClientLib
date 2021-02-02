using MusixmatchClientLib.API;
using MusixmatchClientLib.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusixmatchClientLib.Auth
{
    public class MusixmatchToken // Lambda meme class
    {
        public string Token { get; private set; }

        /// <summary>
        /// Issues a new Musixmatch token (What a crazy function, 1m cooldown from one IP).
        /// </summary>
        /// <returns>New Musixmatch token</returns>
        private static string IssueNewToken() => new ApiRequestFactory("gochecktokenshuh").SendRequest(ApiRequestFactory.ApiMethod.TokenGet).Cast<TokenGet>().UserToken;

        public MusixmatchToken(string token) => Token = token;

        public MusixmatchToken() => Token = IssueNewToken();

        /// <summary>
        /// Authenticate using Google's OAuth token.
        /// </summary>
        /// <param name="accessToken">Google access token</param>
        public void AuthenticateGoogle(string accessToken) => new ApiRequestFactory(Token).SendRequestLegacy(ApiRequestFactory.ApiMethod.CredentialPost, null, $"{{\"credential_list\":[{{\"credential\":{{\"type\":\"g2\",\"auth_token\":\"{accessToken}\"}}}}]}}"); // TODO: Try

        // TODO: AppleID authentication, sniffing failed

        // TODO: Facebook authentication, account disabled

        /// <summary>
        /// Authenticate using Musixmatch account credentials.
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="password">Password</param>
        public void AuthenticateMusixmatch(string email, string password) => new ApiRequestFactory(Token).SendRequestLegacy(ApiRequestFactory.ApiMethod.CredentialPost, null, $"{{\"credential_list\":[{{\"credential\":{{\"type\":\"mxm\",\"email\":\"{email}\",\"password\":\"{password}\",\"action\":\"login\"}}}}]}}"); // TODO: Try

        /// <summary>
        /// Logout from account on this token.
        /// </summary>
        public void Deauthenticate() => new ApiRequestFactory(Token).SendRequestLegacy(ApiRequestFactory.ApiMethod.CredentialPost, null, "{\"credential_list\":[]}");

    }
}
