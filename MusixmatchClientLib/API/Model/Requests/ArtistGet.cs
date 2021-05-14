using MusixmatchClientLib.API.Model.Types;
using Newtonsoft.Json;

namespace MusixmatchClientLib.API.Model.Requests
{
    public class ArtistGet : MusixmatchApiResponse
    {
        [JsonProperty("artist")]
        public Artist Artist;
    }
}
