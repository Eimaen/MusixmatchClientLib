using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusixmatchClientLib.API.Model.Types
{
    public class MusicGenreList
    {
        [JsonProperty("music_genre")]
        public MusicGenre MusicGenre;
    }

    public class PrimaryGenres
    {
        [JsonProperty("music_genre_list")]
        public List<MusicGenreList> MusicGenreList;
    }

    public class SecondaryGenres
    {
        [JsonProperty("music_genre_list")]
        public List<MusicGenreList> MusicGenreList;
    }

    public class Track
    {
        [JsonProperty("track_id")]
        public int TrackId;

        [JsonProperty("track_mbid")]
        public string TrackMbid;

        [JsonProperty("track_isrc")]
        public string TrackIsrc;

        [JsonProperty("commontrack_isrcs")]
        public List<List<string>> CommontrackIsrcs;

        [JsonProperty("track_spotify_id")]
        public string TrackSpotifyId;

        [JsonProperty("commontrack_spotify_ids")]
        public List<string> CommontrackSpotifyIds;

        [JsonProperty("track_soundcloud_id")]
        public int TrackSoundcloudId;

        [JsonProperty("track_xboxmusic_id")]
        public string TrackXboxmusicId;

        [JsonProperty("track_name")]
        public string TrackName;

        [JsonProperty("track_name_translation_list")]
        public List<object> TrackNameTranslationList;

        [JsonProperty("track_rating")]
        public int TrackRating;

        [JsonProperty("track_length")]
        public int TrackLength;

        [JsonProperty("commontrack_id")]
        public int CommontrackId;

        [JsonProperty("instrumental")]
        public int Instrumental;

        [JsonProperty("explicit")]
        public int Explicit;

        [JsonProperty("has_lyrics")]
        public int HasLyrics;

        [JsonProperty("has_lyrics_crowd")]
        public int HasLyricsCrowd;

        [JsonProperty("has_subtitles")]
        public int HasSubtitles;

        [JsonProperty("has_richsync")]
        public int HasRichsync;

        [JsonProperty("has_track_structure")]
        public int HasTrackStructure;

        [JsonProperty("num_favourite")]
        public int NumFavourite;

        [JsonProperty("lyrics_id")]
        public int LyricsId;

        [JsonProperty("subtitle_id")]
        public int SubtitleId;

        [JsonProperty("album_id")]
        public int AlbumId;

        [JsonProperty("album_name")]
        public string AlbumName;

        [JsonProperty("artist_id")]
        public int ArtistId;

        [JsonProperty("artist_mbid")]
        public string ArtistMbid;

        [JsonProperty("artist_name")]
        public string ArtistName;

        [JsonProperty("album_coverart_100x100")]
        public string AlbumCoverart100x100;

        [JsonProperty("album_coverart_350x350")]
        public string AlbumCoverart350x350;

        [JsonProperty("album_coverart_500x500")]
        public string AlbumCoverart500x500;

        [JsonProperty("album_coverart_800x800")]
        public string AlbumCoverart800x800;

        [JsonProperty("track_share_url")]
        public string TrackShareUrl;

        [JsonProperty("track_edit_url")]
        public string TrackEditUrl;

        [JsonProperty("commontrack_vanity_id")]
        public string CommontrackVanityId;

        [JsonProperty("restricted")]
        public int Restricted;

        [JsonProperty("first_release_date")]
        public DateTime FirstReleaseDate;

        [JsonProperty("updated_time")]
        public DateTime UpdatedTime;

        [JsonProperty("primary_genres")]
        public PrimaryGenres PrimaryGenres;

        [JsonProperty("secondary_genres")]
        public SecondaryGenres SecondaryGenres;
    }
}
