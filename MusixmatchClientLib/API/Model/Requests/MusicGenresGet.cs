using MusixmatchClientLib.API.Model.Types;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MusixmatchClientLib.API.Model.Requests
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
