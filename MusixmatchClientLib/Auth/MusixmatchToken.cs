using System.Threading.Tasks;
using MusixmatchClientLib.API;
using MusixmatchClientLib.API.Contexts;
using MusixmatchClientLib.API.Model;
using MusixmatchClientLib.API.Model.Requests;

namespace MusixmatchClientLib.Auth
{
    public class MusixmatchToken // Lambda meme class
    {
        public string Token { get; private set; }
        public ApiContext Context { get; private set; }

        /// <summary>
        /// Issues a new Musixmatch token (with a cooldown of 1 minute from one IP).
        /// </summary>
        /// <returns>New Musixmatch token</returns>
        public string IssueNewToken() => new ApiRequestFactory("gochecktokenshuh", Context).SendRequest(ApiRequestFactory.ApiMethod.TokenGet).Cast<TokenGet>().UserToken;

        /// <summary>
        /// Issues a new Musixmatch token (with a cooldown of 1 minute from one IP).
        /// </summary>
        /// <returns>New Musixmatch token</returns>
        public async Task<string> IssueNewTokenAsync()
        {
            MusixmatchApiResponse response = await new ApiRequestFactory("gochecktokenshuh", Context).SendRequestAsync(ApiRequestFactory.ApiMethod.TokenGet);
            return response.Cast<TokenGet>().UserToken;
        }

        public MusixmatchToken(string token, ApiContext context = ApiContext.Desktop)
        {
            Context = context;
            Token = token;
        }

        public MusixmatchToken(ApiContext context = ApiContext.Desktop)
        {
            Context = context;
            Token = IssueNewToken();
        }

        /// <summary>
        /// Authenticate using Google's OAuth token.
        /// </summary>
        /// <param name="accessToken">Google access token</param>
        public void AuthenticateGoogle(string accessToken) => new ApiRequestFactory(Token, Context).SendRequestLegacy(ApiRequestFactory.ApiMethod.CredentialPost, null, $"{{\"credential_list\":[{{\"credential\":{{\"type\":\"g2\",\"auth_token\":\"{accessToken}\"}}}}]}}"); // TODO: Try

        /// <summary>
        /// Authenticate using Google's OAuth token.
        /// </summary>
        /// <param name="accessToken">Google access token</param>
        public async Task AuthenticateGoogleAsync(string accessToken)
        {
            await new ApiRequestFactory(Token, Context).SendRequestLegacyAsync(ApiRequestFactory.ApiMethod.CredentialPost,
                null,
                $"{{\"credential_list\":[{{\"credential\":{{\"type\":\"g2\",\"auth_token\":\"{accessToken}\"}}}}]}}");
        } 

        // TODO: AppleID authentication, sniffing failed

        // TODO: Facebook authentication, account disabled

        /// <summary>
        /// Authenticate using Musixmatch account credentials.
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="password">Password</param>
        public void AuthenticateMusixmatch(string email, string password) => new ApiRequestFactory(Token, Context).SendRequestLegacy(ApiRequestFactory.ApiMethod.CredentialPost, null, $"{{\"credential_list\":[{{\"credential\":{{\"type\":\"mxm\",\"email\":\"{email}\",\"password\":\"{password}\",\"action\":\"login\"}}}}]}}"); // TODO: Try

        /// <summary>
        /// Authenticate using Musixmatch account credentials.
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="password">Password</param>
        public async Task AuthenticateMusixmatchAsync(string email, string password)
        {
            await new ApiRequestFactory(Token, Context).SendRequestLegacyAsync(ApiRequestFactory.ApiMethod.CredentialPost, null, $"{{\"credential_list\":[{{\"credential\":{{\"type\":\"mxm\",\"email\":\"{email}\",\"password\":\"{password}\",\"action\":\"login\"}}}}]}}"); // TODO: Try
        }

        /// <summary>
        /// Logout from account on this token.
        /// </summary>
        public void Deauthenticate() => new ApiRequestFactory(Token, Context).SendRequestLegacy(ApiRequestFactory.ApiMethod.CredentialPost, null, "{\"credential_list\":[]}");

        /// <summary>
        /// Logout from account on this token.
        /// </summary>
        public async Task DeauthenticateAsync()
        {
            await new ApiRequestFactory(Token, Context).SendRequestLegacyAsync(ApiRequestFactory.ApiMethod.CredentialPost, null, "{\"credential_list\":[]}");
        }


        /// <summary>
        /// Get web auth url.
        /// </summary>
        /// <returns>Auth url.</returns>
        public string GetAuthUrl() => $"https://oauth.musixmatch.com/credential/signin?app_id={MusixmatchApiContext.Get(Context).AppId}&usertoken={Token}&origin=none";

        public override string ToString() => Token;
    }
}
