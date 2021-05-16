using MusixmatchClientLib.API.Model.Types;
using Newtonsoft.Json;

namespace MusixmatchClientLib.API.Model.Requests
{
    public class TrackRichsyncGet : MusixmatchApiResponse
    {
        [JsonProperty("richsync")]
        public RichsyncRawResponse Richsync;
    }
}
