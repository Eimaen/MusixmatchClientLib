using MusixmatchClientLib.API.Model.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusixmatchClientLib.API.Model
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
