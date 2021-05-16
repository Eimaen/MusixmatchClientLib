using MusixmatchClientLib.API.Model.Types;
using Newtonsoft.Json;

namespace MusixmatchClientLib.API.Model.Requests
{
    public class TrackLyricsGet : MusixmatchApiResponse
    {
        [JsonProperty("lyrics")]
        public Lyrics Lyrics;
    }
}
