using Newtonsoft.Json;
using System;

namespace MusixmatchClientLib.API.Model
{
    public class OauthTokenGet : MusixmatchApiResponse
    {
        [JsonProperty("oauthtoken")]
        public Oauthtoken Token;

        public class OauthRefreshtokenReply
        {
            [JsonProperty("access_token")]
            public string AccessToken;

            [JsonProperty("token_type")]
            public string TokenType;

            [JsonProperty("expires_in")]
            public int ExpiresIn;

            [JsonProperty("scope")]
            public string Scope;

            [JsonProperty("refresh_token")]
            public string RefreshToken;

            [JsonProperty("refresh_date")]
            public DateTime RefreshDate;

            [JsonProperty("encrypted_refresh_token")]
            public string EncryptedRefreshToken;
        }

        public class PlaylistsMap
        {
            [JsonProperty("lyrics_music_id")]
            public string LyricsMusicId;
        }

        public class Oauthtoken
        {
            [JsonProperty("oauth_refreshtoken_reply")]
            public OauthRefreshtokenReply OauthRefreshtokenReply;

            [JsonProperty("last_updated")]
            public DateTime LastUpdated;

            [JsonProperty("callback")]
            public string Callback;

            [JsonProperty("service")]
            public string Service;

            [JsonProperty("service_user_prefix")]
            public string ServiceUserPrefix;

            [JsonProperty("playlists_map")]
            public PlaylistsMap PlaylistsMap;
        }
    }
}
