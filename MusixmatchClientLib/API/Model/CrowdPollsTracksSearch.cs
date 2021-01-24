using MusixmatchClientLib.API.Model.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusixmatchClientLib.API.Model
{
    public class CrowdPollsTrackSearch : MusixmatchApiResponse
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
