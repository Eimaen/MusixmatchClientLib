using MusixmatchClientLib.API.Model.Types;
using Newtonsoft.Json;

namespace MusixmatchClientLib.API.Model.Requests
{
    public class TrackSnippetGet : MusixmatchApiResponse
    {
        [JsonProperty("snippet")]
        public Snippet Snippet;
    }
}
