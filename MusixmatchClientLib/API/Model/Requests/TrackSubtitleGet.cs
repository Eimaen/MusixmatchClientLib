using MusixmatchClientLib.API.Model.Types;
using Newtonsoft.Json;

namespace MusixmatchClientLib.API.Model.Requests
{
    public class TrackSubtitleGet : MusixmatchApiResponse
    {
        [JsonProperty("subtitle")]
        public Subtitle Subtitle;
    }
}
