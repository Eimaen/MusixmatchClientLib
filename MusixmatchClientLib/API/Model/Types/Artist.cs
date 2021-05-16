using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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

        [JsonProperty("artist_country")]
        public string ArtistCountry;

        [JsonProperty("artist_alias_list")]
        public List<ArtistAliasList> ArtistAliasList;

        [JsonProperty("artist_rating")]
        public int ArtistRating;

        [JsonProperty("artist_twitter_url")]
        public string ArtistTwitterUrl;

        [JsonProperty("updated_time")]
        public DateTime UpdatedTime;
    }

    public class ArtistAliasList
    {
        [JsonProperty("artist_alias")]
        public string ArtistAlias;
    }
}
