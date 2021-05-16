using Newtonsoft.Json;
using System.Collections.Generic;

namespace MusixmatchClientLib.API.Model.Requests
{
    public class ChartTracksGet : MusixmatchApiResponse
    {
        [JsonProperty("track_list")]
        public List<TrackListItem> TrackList;

        public class TrackListItem
        {
            [JsonProperty("track")]
            public string Track;
        }
    }
}
