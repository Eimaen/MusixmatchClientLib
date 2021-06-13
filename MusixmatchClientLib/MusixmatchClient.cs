using MusixmatchClientLib.API;
using MusixmatchClientLib.API.Model;
using MusixmatchClientLib.API.Model.Exceptions;
using MusixmatchClientLib.API.Model.Requests;
using MusixmatchClientLib.API.Model.Types;
using MusixmatchClientLib.API.Processors;
using MusixmatchClientLib.Auth;
using MusixmatchClientLib.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusixmatchClientLib
{
    public class MusixmatchClient
    {
        private ApiRequestFactory requestFactory;

        /// <summary>
        /// Current musixmatch token.
        /// </summary>
        public MusixmatchToken Token { get => new MusixmatchToken(requestFactory.UserToken); }

        /// <summary>
        /// Initializes an instance of <see cref="MusixmatchClient"/> class using the given <see cref="MusixmatchToken"/>.
        /// </summary>
        /// <param name="userToken"></param>
        public MusixmatchClient(MusixmatchToken userToken) => requestFactory = new ApiRequestFactory(userToken.Token, userToken.Context);

        public void SetRequestProcessor(RequestProcessor requestProcessor) => requestFactory.RequestProcessor = requestProcessor;

        /// <summary>
        /// Search the Musixmatch song database for a track.
        /// </summary>
        /// <param name="parameters">Search parameters</param>
        /// <param name="paginationParameters">Pagination parameters</param>
        /// <returns>List of tracks</returns>
        public List<Track> SongSearch(TrackSearchParameters parameters, PaginationParameters paginationParameters = null)
        {
            if (paginationParameters == null)
                paginationParameters = new PaginationParameters();
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
                ["f_lyrics_language"] = parameters.Language,
                ["page"] = paginationParameters.Page.ToString(),
                ["page_size"] = paginationParameters.PageSize.ToString()
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
        /// <param name="paginationParameters">Pagination parameters</param>
        /// <returns>List of tracks</returns>
        public List<Track> SongSearch(string query, PaginationParameters paginationParameters = null)
        {
            if (paginationParameters == null)
                paginationParameters = new PaginationParameters();
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.TrackSearch, new Dictionary<string, string>
            {
                ["q"] = query,
                ["page"] = paginationParameters.Page.ToString(),
                ["page_size"] = paginationParameters.PageSize.ToString()
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
        /// <param name="paginationParameters">Pagination parameters</param>
        /// <returns>List of tracks</returns>
        public List<Track> SongSearch(string artist, string song, PaginationParameters paginationParameters)
        {
            if (paginationParameters == null)
                paginationParameters = new PaginationParameters();
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.TrackSearch, new Dictionary<string, string>
            {
                ["q_artist"] = artist,
                ["q_track"] = song,
                ["page"] = paginationParameters.Page.ToString(),
                ["page_size"] = paginationParameters.PageSize.ToString()
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
            /// <summary>LRC format.</summary>
            Lrc,
            /// <summary>Some kind of XML representation.</summary>
            Dfxp,
            /// <summary>Stledu format, unknown for me xd.</summary>
            Stledu,
            /// <summary>JSON representation, used by Musixmatch desktop client and is not documented in an official API sheet.</summary>
            Musixmatch
        }

        /// <summary>
        /// Get synced subtitles for the song by its Musixmatch id 
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="format">Subtitle format</param>
        /// <returns>Subtitle</returns>
        public SubtitleRawResponse GetTrackSubtitlesRaw(int id, SubtitleFormat format = SubtitleFormat.Lrc)
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
        /// Get synced lyrics in MusixmatchClientLib format as an array of <see cref="LyricsLine"/>s.
        /// </summary>
        /// <param name="id">Musximatch track id</param>
        /// <returns>Array of LyricsLines</returns>
        public Subtitles GetTrackSubtitles(int id)
        {
            var synced = GetTrackSubtitlesRaw(id, SubtitleFormat.Musixmatch);
            return new Subtitles(synced.SubtitleBody);
        }

        /// <summary>
        /// Submit track subtitles by its Musixmatch id. Use Musixmatch (mxm) format!
        /// TODO: I don't know what's wrong, but as the subtitle is submitted, they are immediately removed from Musixmatch, but points are added.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="subtitles">Subtitle data in Musixmatch (mxm) format</param>
        public void SubmitTrackSubtitlesRaw(int id, string subtitles)
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
        /// Submit track subtitles by its Musixmatch id.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="subtitles">Subtitle data</param>
        public void SubmitTrackSubtitles(int id, Subtitles subtitles) => SubmitTrackSubtitlesRaw(id, subtitles.ToString());

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
        public OauthTokenGet.Oauthtoken GetSpotifyOauthToken()
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
        /// Returns a list of user feedbacks (activity).  
        /// </summary>
        /// <returns>List of feedbacks</returns>
        public List<FeedbackList> GetCrowdUserFeedback()
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.CrowdUserFeedbackGet, new Dictionary<string, string>
            {
                ["feedback_type"] = "lyrics_missing,lyrics_ok,lyrics_ko,lyrics_generic_ko,lyrics_changed,lyrics_subtitle_added,lyrics_favourite_added,lyrics_music_id,track_annotat",
                ["part"] = "user,track"
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
            return response.Cast<CrowdUserFeedbackGet>().Feedbacks;
        }

        /// <summary>
        /// Returns a list of community activity.
        /// </summary>
        /// <returns>List of feedbacks</returns>
        // TODO: scopes (!!!)
        public List<FeedbackList> GetCrowdFeedback()
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.CrowdFeedbackGet, new Dictionary<string, string>
            {
                ["part"] = "user,track"
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
            return response.Cast<CrowdFeedbackGet>().Feedbacks;
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
        /// Submit track lyrics by its Musixmatch id.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="lyrics">Track lyrics</param>
        public void SubmitTrackLyrics(int id, string lyrics)
        {
            var trackData = GetTrackById(id);
            Random random = new Random();
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.TrackLyricsPost, new Dictionary<string, string>
            {
                ["commontrack_id"] = trackData.CommontrackId.ToString(),
                ["q_track"] = trackData.TrackName,
                ["q_artist"] = trackData.ArtistName
            }, new Dictionary<string, string>()
            {
                ["lyrics_body"] = lyrics
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
        }

        /// <summary>
        /// Get trending tracks.
        /// Not working yet.
        /// </summary>
        /// <returns>List of track ids</returns>
        public List<string> ChartTracksGet(PaginationParameters paginationParameters = null)
        {
            if (paginationParameters == null)
                paginationParameters = new PaginationParameters();
            List<string> returnValue = new List<string>();
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.ChartTracksGet, new Dictionary<string, string>
            {
                ["page"] = paginationParameters.Page.ToString(),
                ["page_size"] = paginationParameters.PageSize.ToString()
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
            foreach (var track in response.Cast<ChartTracksGet>().TrackList)
                returnValue.Add(track.Track);
            return returnValue;
        }

        /// <summary>
        /// Get tracks that need your contribution. 
        /// Not working yet. Use <see cref="GetContributeSuggestionsTracks"/> instead.
        /// </summary>
        /// <returns>List of tracks</returns>
        public List<Track> GetPollTracks()
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.CrowdPollsTracksSearch, new Dictionary<string, string>
            {

            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
            List<Track> tracks = new List<Track>();
            foreach (var track in response.Cast<TrackSearch>().Results)
                tracks.Add(track.Track);
            return tracks;
        }

        public enum ContributionType
        {
            Lyrics,
            Sync,
            Translation,
            Vote
        }

        /// <summary>
        /// Get tracks that need your contribution using scopes. See <see cref="ContributionType"/>.
        /// </summary>
        /// <returns>List of tracks</returns>
        public List<Track> GetContributeSuggestionsTracks(ContributionType contributionType, string language = "")
        {
            ApiRequestFactory.ApiMethod apiMethod = ApiRequestFactory.ApiMethod.None;
            switch (contributionType)
            {
                case ContributionType.Lyrics:
                    apiMethod = ApiRequestFactory.ApiMethod.CrowdUserSuggestionLyricsGet;
                    break;
                case ContributionType.Sync:
                    apiMethod = ApiRequestFactory.ApiMethod.CrowdUserSuggestionSubtitlesGet;
                    break;
                case ContributionType.Translation:
                    apiMethod = ApiRequestFactory.ApiMethod.CrowdUserSuggestionTranslationsGet;
                    break;
                case ContributionType.Vote:
                    apiMethod = ApiRequestFactory.ApiMethod.CrowdUserSuggestionVotesGet;
                    break;
            }
            var response = requestFactory.SendRequest(apiMethod, new Dictionary<string, string>
            {
                ["language"] = language
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
            List<Track> tracks = new List<Track>();
            foreach (var track in response.Cast<CrowdSuggestionGet>().Results)
                tracks.Add(track.Track);
            return tracks;
        }
        /// <summary>
        /// Submit AI question data (track language).
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="language">ISO language abbreviation (lowercase)</param>
        public void SubmitTrackLanguage(int id, string language)
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.AiQuestionPost, new Dictionary<string, string>
            {
                ["answer_id"] = "lyrics_ai_ugc_language",
                ["track_id"] = id.ToString(),
                ["selected_language"] = language,
                ["question_id"] = "lyrics_ai_language_collect"
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
        }

        /// <summary>
        /// Submit AI question data (track mood).
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="energy">Track energy ratio (integer between 0 and 100)</param>
        /// <param name="mood">Track mood ratio (integer between 0 and 100)</param>
        public void SubmitTrackMood(int id, int energy, int mood)
        {
            if (energy > 100 || energy < 0)
                throw new ArgumentException("Track energy is an integer between 0 and 100");
            if (mood > 100 || mood < 0)
                throw new ArgumentException("Track mood is an integer between 0 and 100");
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.AiQuestionPost, new Dictionary<string, string>
            {
                ["answer_id"] = "lyrics_ai_mood_analysis_v3_value",
                ["track_id"] = id.ToString(),
                ["energy_ratio"] = energy.ToString(),
                ["mood_ratio"] = mood.ToString(),
                ["question_id"] = "lyrics_ai_mood_analysis_v3"
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
        }

        /// <summary>
        /// Returns user top for a country.
        /// </summary>
        /// <param name="country">Country ISO code</param>
        /// <returns>List of top users</returns>
        public List<User> GetUserWeeklyTop(string country = "", PaginationParameters paginationParameters = null)
        {
            if (paginationParameters == null)
                paginationParameters = new PaginationParameters();
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.CrowdChartUsersGet, new Dictionary<string, string>
            {
                ["country"] = country,
                ["page"] = paginationParameters.Page.ToString(),
                ["page_size"] = paginationParameters.PageSize.ToString()
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
            List<User> users = new List<User>();
            foreach (var user in response.Cast<CrowdChartUsersGet>().Results)
                users.Add(user.User);
            return users;
        }

        /// <summary>
        /// Get track richsync by its Musixmatch id.
        /// Body has a <see href="https://developer.musixmatch.com/documentation/api-reference/track-richsync-get">specific format</see>.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <returns>Raw richsync response</returns>
        public RichsyncRawResponse GetTrackRichsyncRaw(int id)
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.TrackRichsyncGet, new Dictionary<string, string>
            {
                ["track_id"] = id.ToString()
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
            return response.Cast<TrackRichsyncGet>().Richsync;
        }

        /// <summary>
        /// Get track richsync by its Musixmatch id.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <returns>Richsync</returns>
        public Richsync GetTrackRichsync(int id)
        {
            RichsyncRawResponse richsyncRawResponse = GetTrackRichsyncRaw(id);
            return new Richsync(richsyncRawResponse.RichsyncBody);
        }

        /// <summary>
        /// Submit track richsync by its Musixmatch id.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="richsync">Raw richsync</param>
        public void SubmitTrackRichsyncRaw(int id, string richsync)
        {
            var trackData = GetTrackById(id);
            Random random = new Random();
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.TrackRichsyncPost, new Dictionary<string, string>
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
                ["richsync_body"] = richsync
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
        }

        /// <summary>
        /// Submit track richsync by its Musixmatch id.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="richsync">Richsync</param>
        public void SubmitTrackRichsync(int id, Richsync richsync) => SubmitTrackRichsyncRaw(id, richsync.ToString());

        /// <summary>
        /// Get current user score.
        /// </summary>
        /// <returns>User</returns>
        public User GetUserScore()
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.CrowdScoreGet, new Dictionary<string, string>());
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
            return response.Cast<CrowdScoreGet>().User;
        }

        /// <summary>
        /// Get all the genres supported by Musixmatch database.
        /// </summary>
        /// <returns>List of genres</returns>
        public List<MusicGenre> GetMusicGenres()
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.MusicGenresGet, new Dictionary<string, string>());
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
            List<MusicGenre> genres = new List<MusicGenre>();
            foreach (var genre in response.Cast<MusicGenresGet>().Results)
                genres.Add(genre.MusicGenre);
            return genres;
        }

        /// <summary>
        /// Get top artists by the given country
        /// </summary>
        /// <param name="country">Country ISO code</param>
        /// <returns>List of artists</returns>
        public List<Artist> GetChartArtists(string country = "", PaginationParameters paginationParameters = null)
        {
            if (paginationParameters == null)
                paginationParameters = new PaginationParameters();
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.ChartArtistsGet, new Dictionary<string, string>
            {
                ["country"] = country,
                ["page"] = paginationParameters.Page.ToString(),
                ["page_size"] = paginationParameters.PageSize.ToString()
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
            List<Artist> artists = new List<Artist>();
            foreach (var artist in response.Cast<ChartArtistsGet>().Results)
                artists.Add(artist.Artist);
            return artists;
        }

        /// <summary>
        /// Look for artists in the database by query.
        /// </summary>
        /// <param name="query">Query</param>
        /// <returns>List of artists</returns>
        public List<Artist> ArtistSearch(string query, PaginationParameters paginationParameters = null)
        {
            if (paginationParameters == null)
                paginationParameters = new PaginationParameters();
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.ArtistSearch, new Dictionary<string, string>
            {
                ["q_artist"] = query,
                ["page"] = paginationParameters.Page.ToString(),
                ["page_size"] = paginationParameters.PageSize.ToString()
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
            List<Artist> artists = new List<Artist>();
            foreach (var artist in response.Cast<ArtistSearch>().Results)
                artists.Add(artist.Artist);
            return artists;
        }

        /// <summary>
        /// Get artist by his Musixmatch id.
        /// </summary>
        /// <param name="id">Musixmatch id</param>
        /// <returns>Artist</returns>
        public Artist GetArtistById(int id)
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.ArtistGet, new Dictionary<string, string>
            {
                ["artist_id"] = id.ToString()
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
            return response.Cast<ArtistGet>().Artist;
        }

        /// <summary>
        /// Get albums by artist
        /// </summary>
        /// <param name="id">Artist id</param>
        /// <returns>List of albums</returns>
        public List<Album> GetArtistAlbums(int id, PaginationParameters paginationParameters = null)
        {
            if (paginationParameters == null)
                paginationParameters = new PaginationParameters();
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.ArtistAlbumsGet, new Dictionary<string, string>
            {
                ["artist_id"] = id.ToString(),
                ["page"] = paginationParameters.Page.ToString(),
                ["page_size"] = paginationParameters.PageSize.ToString()
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
            List<Album> albums = new List<Album>();
            foreach (var album in response.Cast<ArtistAlbumsGet>().Results)
                albums.Add(album.Album);
            return albums;
        }

        /// <summary>
        /// Get album by its Musixmatch id.
        /// </summary>
        /// <param name="id">Musixmatch album id</param>
        /// <returns>Album</returns>
        public Album GetAlbumById(int id)
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.AlbumGet, new Dictionary<string, string>
            {
                ["album_id"] = id.ToString()
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
            return response.Cast<AlbumGet>().Album;
        }

        /// <summary>
        /// Get tracks from chosen album
        /// </summary>
        /// <param name="id">Musixmatch album id</param>
        /// <returns>List of tracks</returns>
        public List<Track> GetAlbumTracks(int id, PaginationParameters paginationParameters = null)
        {
            if (paginationParameters == null)
                paginationParameters = new PaginationParameters();
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.AlbumTracksGet, new Dictionary<string, string>
            {
                ["album_id"] = id.ToString(),
                ["page"] = paginationParameters.Page.ToString(),
                ["page_size"] = paginationParameters.PageSize.ToString()
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
            List<Track> tracks = new List<Track>();
            foreach (var track in response.Cast<AlbumTracksGet>().Results)
                tracks.Add(track.Track);
            return tracks;
        }

        /// <summary>
        /// Submit track translation by Musixmatch track id.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="translation">List of <see cref="TranslationPost"/>s.</param>
        /// <param name="timeSpent">Time spent on the translation in milliseconds.</param>
        public void SubmitTrackTranslationsRaw(int id, List<TranslationPost> translation, int timeSpent = int.MaxValue)
        {
            var trackData = GetTrackById(id);
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.TrackLyricsTranslationPost, new Dictionary<string, string>
            {
                ["commontrack_id"] = trackData.CommontrackId.ToString(),
                ["track_id"] = trackData.TrackId.ToString()
            }, new Dictionary<string, string>()
            {
                ["translations_list"] = JsonConvert.SerializeObject(translation),
                ["time_spent"] = timeSpent.ToString()
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
        }

        /// <summary>
        /// Update user's profile and leaderboard country.
        /// </summary>
        /// <param name="country">Country ISO code</param>
        public void UpdateUserProfileCountry(string country)
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.CrowdUserProfilePost, new Dictionary<string, string>
            {

            }, new Dictionary<string, string>
            {
                ["profile"] = $"{{\"country\":\"{country.ToUpper()}\"}}"
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
        }

        /// <summary>
        /// Update user's profile favourite artists.
        /// </summary>
        /// <param name="artistIds">List of artist ids to favourite</param>
        public void UpdateUserProfileFavouriteArtists(List<int> artistIds)
        {
            string artistString = "[]";

            if (artistIds.Count != 0)
            {
                StringBuilder artistStringBuilder = new StringBuilder("[");
                foreach (var artistId in artistIds)
                    artistStringBuilder.Append(artistId.ToString() + ',');
                artistStringBuilder[artistStringBuilder.Length - 1] = ']';
                artistString = artistStringBuilder.ToString();
            }

            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.CrowdUserProfilePost, new Dictionary<string, string>
            {

            }, new Dictionary<string, string>
            {
                ["profile"] = $"{{\"favourite_artists\":{artistString}}}"
            });
            if ((StatusCode)response.StatusCode != StatusCode.Success)
                throw new MusixmatchRequestException((StatusCode)response.StatusCode);
        }

        #region Work In Progress
        public MissionManager RequestMissionManager()
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.RequestJwtToken).Cast<JwtGet>();
            return new MissionManager(response.JwtToken);
        }
        #endregion
    }
}
