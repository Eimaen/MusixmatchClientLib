using MusixmatchClientLib.API.Model.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusixmatchClientLib.API.Model.Requests
{
    public class GraphQLAvailableMissionsListResponse
    {
        [JsonProperty("items")]
        public List<Mission> Items;
    }
}
