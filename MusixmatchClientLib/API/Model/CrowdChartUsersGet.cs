using MusixmatchClientLib.API.Model.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusixmatchClientLib.API.Model
{
    public class CrowdChartUsersGet : MusixmatchApiResponse
    {
        [JsonProperty("user_chart_list")]
        public List<TrackList> Results;

        public class TrackList
        {
            [JsonProperty("user")]
            public User User;
        }
    }
}
