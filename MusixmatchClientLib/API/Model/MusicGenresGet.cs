using MusixmatchClientLib.API.Model.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusixmatchClientLib.API.Model
{
    public class MusicGenresGet : MusixmatchApiResponse
    {
        [JsonProperty("music_genre_list")]
        public List<MusicGenreList> Results;

        public class MusicGenreList
        {
            [JsonProperty("music_genre")]
            public MusicGenre MusicGenre;
        }
    }
}
