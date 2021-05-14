﻿using Newtonsoft.Json;

namespace MusixmatchClientLib.API.Model.Types
{
    public class MusicGenre
    {
        [JsonProperty("music_genre_id")]
        public int MusicGenreId;

        [JsonProperty("music_genre_parent_id")]
        public int MusicGenreParentId;

        [JsonProperty("music_genre_name")]
        public string MusicGenreName;

        [JsonProperty("music_genre_name_extended")]
        public string MusicGenreNameExtended;

        [JsonProperty("music_genre_vanity")]
        public string MusicGenreVanity;
    }
}
