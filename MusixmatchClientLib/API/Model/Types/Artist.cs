using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusixmatchClientLib.API.Model.Types
{
    public class Artist
    {
        [JsonProperty("artist_id")]
        public int ArtistId;

        [JsonProperty("artist_mbid")]
        public string ArtistMbid;

        [JsonProperty("artist_name")]
        public string ArtistName;

        [JsonProperty("artist_alias_list")]
        public List<object> ArtistAliasList;

        [JsonProperty("artist_rating")]
        public int ArtistRating;

        [JsonProperty("updated_time")]
        public DateTime UpdatedTime;
    }
}
