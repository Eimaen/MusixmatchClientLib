using MusixmatchClientLib.API.Model.Types;
using Newtonsoft.Json;

namespace MusixmatchClientLib.API.Model.Requests
{
    public class CrowdScoreGet : MusixmatchApiResponse
    {
        [JsonProperty("user")]
        public User User;
    }
}
