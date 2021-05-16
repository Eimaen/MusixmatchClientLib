using MusixmatchClientLib.API.Model.Types;
using Newtonsoft.Json;

namespace MusixmatchClientLib.API.Model.Requests
{
    public class AlbumGet : MusixmatchApiResponse
    {
        [JsonProperty("album")]
        public Album Album;
    }
}
