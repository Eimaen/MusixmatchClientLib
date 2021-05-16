using MusixmatchClientLib.API.Model.Types;
using Newtonsoft.Json;

namespace MusixmatchClientLib.API.Model.Requests
{
    public class TrackGet : MusixmatchApiResponse
    {
        [JsonProperty("track")]
        public Track Track;
    }
}
