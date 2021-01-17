using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusixmatchClientLib.API.Model
{
    class JwtGet : MusixmatchApiResponse
    {
        [JsonProperty("jwt")]
        public string JwtToken;

        [JsonProperty("expire")]
        public DateTime Expire;
    }
}
