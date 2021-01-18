using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusixmatchClientLib.API.Model
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
