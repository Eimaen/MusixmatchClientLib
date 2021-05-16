using Newtonsoft.Json;
using System;

namespace MusixmatchClientLib.API.Model.Requests
{
    class JwtGet : MusixmatchApiResponse
    {
        [JsonProperty("jwt")]
        public string JwtToken;

        [JsonProperty("expire")]
        public DateTime Expire;
    }
}
