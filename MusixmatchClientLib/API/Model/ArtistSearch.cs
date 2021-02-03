using MusixmatchClientLib.API.Model.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusixmatchClientLib.API.Model
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
