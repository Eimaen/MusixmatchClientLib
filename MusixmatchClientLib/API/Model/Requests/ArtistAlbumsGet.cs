using MusixmatchClientLib.API.Model.Types;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MusixmatchClientLib.API.Model.Requests
{
    public class ArtistAlbumsGet : MusixmatchApiResponse
    {
        [JsonProperty("album_list")]
        public List<AlbumList> Results;

        public class AlbumList
        {
            [JsonProperty("album")]
            public Album Album;
        }
    }
}
