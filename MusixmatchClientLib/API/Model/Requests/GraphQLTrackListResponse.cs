using MusixmatchClientLib.API.Model.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusixmatchClientLib.API.Model.Requests
{
    public class GraphQLTrackListResponse
    {
        [JsonProperty("items")]
        public List<MissionTrack> Items;
    }
}
