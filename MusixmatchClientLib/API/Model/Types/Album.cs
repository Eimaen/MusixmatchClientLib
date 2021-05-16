using Newtonsoft.Json;
using System;

namespace MusixmatchClientLib.API.Model.Types
{
    public class Album
    {
        [JsonProperty("album_id")]
        public int AlbumId;

        [JsonProperty("album_mbid")]
        public string AlbumMbid;

        [JsonProperty("album_name")]
        public string AlbumName;

        [JsonProperty("album_rating")]
        public int AlbumRating;

        [JsonProperty("album_track_count")]
        public int AlbumTrackCount;

        [JsonProperty("album_release_date")]
        public string AlbumReleaseDate;

        [JsonProperty("album_release_type")]
        public string AlbumReleaseType;

        [JsonProperty("artist_id")]
        public int ArtistId;

        [JsonProperty("artist_name")]
        public string ArtistName;

        [JsonProperty("primary_genres")]
        public MusicGenreLayout PrimaryGenres;

        [JsonProperty("secondary_genres")]
        public MusicGenreLayout SecondaryGenres;

        [JsonProperty("album_pline")]
        public string AlbumPline;

        [JsonProperty("album_copyright")]
        public string AlbumCopyright;

        [JsonProperty("album_label")]
        public string AlbumLabel;

        [JsonProperty("updated_time")]
        public DateTime UpdatedTime;

        [JsonProperty("album_coverart_100x100")]
        public string AlbumCoverart100x100;
    }
}
