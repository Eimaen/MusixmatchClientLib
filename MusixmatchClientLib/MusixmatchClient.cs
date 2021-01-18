using MusixmatchClientLib.API;
using MusixmatchClientLib.API.Model;
using MusixmatchClientLib.API.Model.Exceptions;
using MusixmatchClientLib.API.Model.Types;
using MusixmatchClientLib.Auth;
using MusixmatchClientLib.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MusixmatchClientLib.API.Model.CrowdUserFeedbackGet;
using static MusixmatchClientLib.API.Model.OauthTokenGet;

namespace MusixmatchClientLib
{
    public class MusixmatchClient
    {
        private static string ConfigFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MusixmatchClientLib");

        private ApiRequestFactory requestFactory;

        /// <summary>
        /// Initializes an instance of <see cref="MusixmatchClient"/> class using the given <see cref="MusixmatchToken"/>.
        /// </summary>
        /// <param name="userToken"></param>
        public MusixmatchClient(MusixmatchToken userToken) => requestFactory = new ApiRequestFactory(userToken.Token);

        /// <summary>
        /// Search the Musixmatch song database for a track.
        /// </summary>
        /// <param name="query">Search query, any word in the song title or artist name or lyrics</param>
        /// <returns>List of tracks</returns>
        public List<Track> SongSearch(TrackSearchParameters parameters)
        {
            var sortDecrypted = TrackSearchParameters.StrategyDecryptions[TrackSearchParameters.SortStrategy.TrackRatingAsc];
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.TrackSearch, new Dictionary<string, string>
            {
                ["q"] = parameters.Query,
                ["q_lyrics"] = parameters.LyricsQuery,
                ["q_artist"] = parameters.Artist,
                ["q_track"] = parameters.Title,
                ["q_album"] = parameters.Album,
                ["f_has_lyrics"] = parameters.HasLyrics ? "1" : "",
                ["f_has_subtitle"] = parameters.HasSubtitles ? "1" : "",
                [sortDecrypted.Key] = sortDecrypted.Value,
                ["page"] = parameters.PageNumber.ToString(),
                ["page_size"] = parameters.PageSize.ToString(),
                ["f_lyrics_language"] = parameters.Language
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
            List<Track> tracks = new List<Track>();
            foreach (var track in response.Cast<TrackSearch>().Results)
                tracks.Add(track.Track);
            return tracks;
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
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
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
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
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
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
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
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
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
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
            var snippet = response.Cast<TrackSnippetGet>();
            return snippet.Snippet.Instrumental == 0 ? snippet.Snippet.SnippetBody : string.Empty;
        }

        /// <summary>
        /// Represents the lyrics format
        /// </summary>
        public enum SubtitleFormat
        {
            Lrc, 
            Dfxp, // Xml representation
            Stledu, // I dont know what is it
            Musixmatch // Secret one
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
                case SubtitleFormat.Dfxp:
                    parameters.Add("subtitle_format", "dfxp");
                    break;
                case SubtitleFormat.Stledu:
                    parameters.Add("subtitle_format", "stledu");
                    break;
                case SubtitleFormat.Musixmatch:
                    parameters.Add("subtitle_format", "mxm");
                    break;
            }
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.TrackSubtitleGet, parameters);
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
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
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
            return response.Cast<TrackLyricsGet>().Lyrics;
        }

        /// <summary>
        /// Submit track subtitles by its Musixmatch id. Use Musixmatch (mxm) format!
        /// TODO: I don't know what's wrong, but as the subtitle is submitted, they are immediately removed from Musixmatch, but points are added.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="subtitles">Subtitle data in Musixmatch (mxm) format</param>
        public void SubmitTrackLyricsSynced(int id, string subtitles)
        {
            var trackData = GetTrackById(id);
            Random random = new Random();
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.TrackSubtitlePost, new Dictionary<string, string>
            {
                ["commontrack_id"] = trackData.CommontrackId.ToString(),
                ["length"] = trackData.TrackLength.ToString(),
                ["q_track"] = trackData.TrackName,
                ["original_title"] = trackData.TrackName,
                ["q_artist"] = trackData.ArtistName,
                ["original_artist"] = trackData.ArtistName,
                ["original_uri"] = trackData.TrackSpotifyId,
                ["num_keypressed"] = random.Next(16, 2048).ToString(),
                ["time_spent"] = random.Next(2048, 1048576).ToString()
            }, new Dictionary<string, string>()
            {
                ["subtitle_body"] = subtitles
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
        }

        /// <summary>
        /// Gets Musixmatch user information.
        /// </summary>
        /// <returns>User data</returns>
        public UserGet GetUserInfo()
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.UserGet);
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
            return response.Cast<UserGet>();
        }

        /// <summary>
        /// Get spotify <see cref="Oauthtoken"/>. I have also noticed, that even with free spotify account this token acts like premium. Learn more at <see href="developer.spotify.com"/>.
        /// </summary>
        /// <returns>Spotify token info</returns>
        public Oauthtoken GetSpotifyOauthToken()
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.SpotifyOauthTokenGet);
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
            return response.Cast<OauthTokenGet>().Token;
        }

        /// <summary>
        /// Gets lyrics translation.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="language">Selected language in ISO format</param>
        /// <returns>String with translated lyrics</returns>
        public string GetLyricsTranslation(int id, string language)
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.TrackLyricsTranslationGet, new Dictionary<string, string>
            {
                ["track_id"] = id.ToString(),
                ["selected_language"] = language
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
            return response.Cast<TrackLyricsTranslationGet>().Lyrics.TranslatedLyrics.LyricsBody;
        }

        /// <summary>
        /// Returns a list of tasks to complete.
        /// </summary>
        /// <returns>List of feedbacks</returns>
        public List<FeedbackList> GetCrowdFeedback()
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.CrowdUserFeedbackGet, new Dictionary<string, string>
            {
                ["feedback_type"] = "feedback_type=lyrics_missing,lyrics_ok,lyrics_ko,lyrics_generic_ko,%20lyrics_changed,lyrics_subtitle_added,lyrics_favourite_added,%20lyrics_music_id,track_annotat",
                ["part"] = "track"
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
            return response.Cast<CrowdUserFeedbackGet>().Feedbacks;
        }

        /// <summary>
        /// Submit track lyrics by its Musixmatch id.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="subtitles">Track lyrics</param>
        public void SubmitTrackLyrics(int id, string lyrics)
        {
            var trackData = GetTrackById(id);
            Random random = new Random();
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.TrackLyricsPost, new Dictionary<string, string>
            {
                ["track_id"] = trackData.CommontrackId.ToString(),
                ["q_track"] = trackData.TrackName,
                ["q_artist"] = trackData.ArtistName
            }, new Dictionary<string, string>()
            {
                ["lyrics_body"] = lyrics
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
        }

        #region Work In Progress
        public string RequestMissionManager()
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.RequestJwtToken).Cast<JwtGet>();
            return response.JwtToken;
        }
        #endregion
    }
}
