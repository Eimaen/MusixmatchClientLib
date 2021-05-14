using MusixmatchClientLib.API.Model.Types;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MusixmatchClientLib.API.Model.Requests
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
