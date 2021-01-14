using MusixmatchClientLib.API;
using MusixmatchClientLib.API.Model;
using MusixmatchClientLib.API.Model.Types;
using MusixmatchClientLib.Auth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusixmatchClientLib
{
    public class MusixmatchClient
    {
        private static string ConfigFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MusixmatchClientLib");

        private enum StatusCode
        {
            Success = 200, // The request was successful.
            BadSyntax = 400, // The request had bad syntax or was inherently impossible to be satisfied.
            AuthFailed = 401, // Authentication failed, probably because of invalid/missing API key.
            UsageLimitReached = 402, // The usage limit has been reached, either you exceeded per day requests limits or your balance is insufficient.
            NotAuthorized = 403, // You are not authorized to perform this operation.
            ResourceNotFound = 404, // The requested resource was not found.
            MethodNotFound = 405, // The requested method was not found.
            ServerError = 500, // Ops. Something were wrong.
            ServerBusy = 503 // Our system is a bit busy at the moment and your request can’t be satisfied.
        }

        private ApiRequestFactory requestFactory;

        public MusixmatchClient(MusixmatchToken userToken)
        {
            requestFactory = new ApiRequestFactory(userToken.Token);
        }

        /// <summary>
        /// Search the Musixmatch song database for a track.
        /// </summary>
        /// <param name="query">Search query, any word in the song title or artist name or lyrics</param>
        /// <returns>List of tracks</returns>
        public List<Track> SongSearch(string query)
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.TrackSearch, new Dictionary<string, string>
            {
                ["q"] = query
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new Exception($"Musixmatch request failed: {(StatusCode)response.StatusCode}");
            List<Track> tracks = new List<Track>();
            foreach (var track in response.Cast<TrackSearch>().Results)
                tracks.Add(track.Track);
            return tracks;
        }

        /// <summary>
        /// Search the Musixmatch song database for a track.
        /// </summary>
        /// <param name="artist">The song artist</param>
        /// <param name="song">The song title</param>
        /// <returns>List of tracks</returns>
        public List<Track> SongSearch(string artist, string song)
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.TrackSearch, new Dictionary<string, string>
            {
                ["q_artist"] = artist,
                ["q_track"] = song
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new Exception($"Musixmatch request failed: {(StatusCode)response.StatusCode}");
            List<Track> tracks = new List<Track>();
            foreach (var track in response.Cast<TrackSearch>().Results)
                tracks.Add(track.Track);
            return tracks;
        }

        /// <summary>
        /// Search the Musixmatch song database for a track.
        /// </summary>
        /// <param name="artist">The song artist</param>
        /// <param name="song">The song title</param>
        /// <param name="album">The song album</param>
        /// <returns>List of tracks</returns>
        public List<Track> SongSearch(string artist, string song, string album)
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.TrackSearch, new Dictionary<string, string>
            {
                ["q_artist"] = artist,
                ["q_track"] = song,
                ["q_album"] = album // Not documented but works ;)
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new Exception($"Musixmatch request failed: {(StatusCode)response.StatusCode}");
            List<Track> tracks = new List<Track>();
            foreach (var track in response.Cast<TrackSearch>().Results)
                tracks.Add(track.Track);
            return tracks;
        }

        /// <summary>
        /// Search the Musixmatch song database for a track by the piece of lyrics.
        /// </summary>
        /// <param name="lyrics">Piece of lyrics to search</param>
        /// <returns>List of tracks</returns>
        public List<Track> SongSearchByLyrics(string lyrics)
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.TrackSearch, new Dictionary<string, string>
            {
                ["q_lyrics"] = lyrics
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new Exception($"Musixmatch request failed: {(StatusCode)response.StatusCode}");
            List<Track> tracks = new List<Track>();
            foreach (var track in response.Cast<TrackSearch>().Results)
                tracks.Add(track.Track);
            return tracks;
        }

        /// <summary>
        /// Find a track by given id in Musixmatch database.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <returns>Track</returns>
        public Track GetTrackById(int id)
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.TrackGet, new Dictionary<string, string>
            {
                ["track_id"] = id.ToString()
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new Exception($"Musixmatch request failed: {(StatusCode)response.StatusCode}");
            return response.Cast<TrackGet>().Track;
        }

        /// <summary>
        /// Get track snippet by its Musixmatch id. Snippet is a lyrics line which (is meant to) represent the sense of lyrics?
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <returns>If the song is not instrumental, returns the snippet, otherwise returns an empty string</returns>
        public string GetTrackSnippet(int id)
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.TrackSnippetGet, new Dictionary<string, string>
            {
                ["track_id"] = id.ToString()
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new Exception($"Musixmatch request failed: {(StatusCode)response.StatusCode}");
            var snippet = response.Cast<TrackSnippetGet>();
            return snippet.Snippet.Instrumental == 0 ? snippet.Snippet.SnippetBody : string.Empty;
        }

        /// <summary>
        /// Represents the lyrics format
        /// </summary>
        public enum SubtitleFormat
        {
            Lrc,
            Musixmatch
        }

        /// <summary>
        /// Get synced subtitles for the song by its Musixmatch id 
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="format">Subtitle format</param>
        /// <returns>Subtitle</returns>
        public Subtitle GetSyncedLyrics(int id, SubtitleFormat format = SubtitleFormat.Lrc)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string> { ["track_id"] = id.ToString() };
            switch (format)
            {
                case SubtitleFormat.Lrc:
                    parameters.Add("subtitle_format", "lrc");
                    break;
                case SubtitleFormat.Musixmatch:
                    parameters.Add("subtitle_format", "mxm");
                    break;
            }
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.TrackSubtitleGet, parameters);
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new Exception($"Musixmatch request failed: {(StatusCode)response.StatusCode}");
            return response.Cast<TrackSubtitleGet>().Subtitle;
        }

        /// <summary>
        /// Get track lyrics by its Musixmatch id.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <returns>Lyrics</returns>
        public Lyrics GetTrackLyrics(int id)
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.TrackLyricsGet, new Dictionary<string, string>
            {
                ["track_id"] = id.ToString(),
                ["part"] = "user,lyrics_verified_by"
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new Exception($"Musixmatch request failed: {(StatusCode)response.StatusCode}");
            return response.Cast<TrackLyricsGet>().Lyrics;
        }
    }
}
