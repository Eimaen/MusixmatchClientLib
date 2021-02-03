using MusixmatchClientLib.API.Model.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusixmatchClientLib.API.Model
{
    public class AlbumTracksGet : MusixmatchApiResponse
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
