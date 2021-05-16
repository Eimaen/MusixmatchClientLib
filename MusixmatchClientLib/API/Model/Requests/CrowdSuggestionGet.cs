using MusixmatchClientLib.API.Model.Types;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MusixmatchClientLib.API.Model.Requests
{
    class CrowdSuggestionGet : MusixmatchApiResponse
    {
        [JsonProperty("track_list")]
        public List<TrackList> Results;

        public class TrackList
        {
            [JsonProperty("track")]
            public Track Track;
        }
    }
}
