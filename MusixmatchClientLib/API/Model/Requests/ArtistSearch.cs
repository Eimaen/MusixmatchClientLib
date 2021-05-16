using MusixmatchClientLib.API.Model.Types;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MusixmatchClientLib.API.Model.Requests
{
    public class ArtistSearch : MusixmatchApiResponse
    {
        [JsonProperty("artist_list")]
        public List<ArtistList> Results;

        public class ArtistList
        {
            [JsonProperty("artist")]
            public Artist Artist;
        }
    }
}
