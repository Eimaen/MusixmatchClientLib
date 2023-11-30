﻿using MusixmatchClientLib.API;
using MusixmatchClientLib.API.Contexts;
using MusixmatchClientLib.API.Model;
using MusixmatchClientLib.API.Model.Requests;
using MusixmatchClientLib.API.Model.Types;
using MusixmatchClientLib.API.Processors;
using MusixmatchClientLib.Auth;
using MusixmatchClientLib.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MusixmatchClientLib.Utils;

namespace MusixmatchClientLib
{
    public class MusixmatchClient
    {
        internal ApiRequestFactory requestFactory;

        /// <summary>
        /// Indicates whether an exception will be thrown when an error occurs on the API side.
        /// </summary>
        public bool AssertOnRequestException
        {
            get => requestFactory.AssertOnError;
            set => requestFactory.AssertOnError = value;
        }

        /// <summary>
        /// Current musixmatch token.
        /// </summary>
        public MusixmatchToken Token { get => new MusixmatchToken(requestFactory.UserToken, MusixmatchApiContext.Recover(requestFactory.Context)); }

        /// <summary>
        /// Initializes an instance of <see cref="MusixmatchClient"/> class using the given <see cref="MusixmatchToken"/>.
        /// </summary>
        /// <param name="userToken"></param>
        public MusixmatchClient(MusixmatchToken userToken)
        {
            requestFactory = new ApiRequestFactory(userToken.Token, userToken.Context);
        }

        /// <summary>
        /// Initializes an instance of <see cref="MusixmatchClient"/> class using a newly-generated <see cref="MusixmatchToken"/>.
        /// </summary>
        [Obsolete("Generating too many tokens gets your IP address rate-limited. For development purposes you should try creating token first and then re-using it again.", false)]
        public MusixmatchClient() : this(new MusixmatchToken())
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.ForegroundColor = previousColor;
        }

        /// <summary>
        /// Initializes an instance of <see cref="MusixmatchClient"/> class using token and context.
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="context"></param>
        public MusixmatchClient(string userToken, ApiContext context = ApiContext.Desktop)
        {
            requestFactory = new ApiRequestFactory(userToken, context);
        }

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
                ["f_has_rich_sync"] = parameters.HasRichSync ? "1" : "",
                [sortDecrypted.Key] = sortDecrypted.Value,
                ["f_lyrics_language"] = parameters.Language,
                ["page"] = paginationParameters.Page.ToString(),
                ["page_size"] = paginationParameters.PageSize.ToString()
            });

            return new GenericTypeConversion<TrackSearch.TrackList, Track>().
                MergeToList(response.Cast<TrackSearch>().Results, (list, list1) => list1.Add(list.Track));
        }

        /// <summary>
        /// Search the Musixmatch song database for a track async.
        /// </summary>
        /// <param name="parameters">Search parameters</param>
        /// <param name="paginationParameters">Pagination parameters</param>
        /// <returns>List of tracks</returns>
        public async Task<List<Track>> SongSearchAsync(TrackSearchParameters parameters, PaginationParameters paginationParameters = null)
        {
            if (paginationParameters == null)
                paginationParameters = new PaginationParameters();
            var sortDecrypted = TrackSearchParameters.StrategyDecryptions[TrackSearchParameters.SortStrategy.TrackRatingAsc];
            var response = await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.TrackSearch, new Dictionary<string, string>
            {
                ["q"] = parameters.Query,
                ["q_lyrics"] = parameters.LyricsQuery,
                ["q_artist"] = parameters.Artist,
                ["q_track"] = parameters.Title,
                ["q_album"] = parameters.Album,
                ["f_has_lyrics"] = parameters.HasLyrics ? "1" : "",
                ["f_has_subtitle"] = parameters.HasSubtitles ? "1" : "",
                ["f_has_rich_sync"] = parameters.HasRichSync ? "1" : "",
                [sortDecrypted.Key] = sortDecrypted.Value,
                ["f_lyrics_language"] = parameters.Language,
                ["page"] = paginationParameters.Page.ToString(),
                ["page_size"] = paginationParameters.PageSize.ToString()
            });

            return new GenericTypeConversion<TrackSearch.TrackList, Track>().
                MergeToList(response.Cast<TrackSearch>().Results, (list, list1) => list1.Add(list.Track));
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

            return new GenericTypeConversion<TrackSearch.TrackList, Track>().
                MergeToList(response.Cast<TrackSearch>().Results, (list, list1) => list1.Add(list.Track));
        }

        /// <summary>
        /// Search the Musixmatch song database for a track async.
        /// </summary>
        /// <param name="query">Search query, any word in the song title or artist name or lyrics</param>
        /// <param name="paginationParameters">Pagination parameters</param>
        /// <returns>List of tracks</returns>
        public async Task<List<Track>> SongSearchAsync(string query, PaginationParameters paginationParameters = null)
        {
            if (paginationParameters == null)
                paginationParameters = new PaginationParameters();
            var response = await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.TrackSearch, new Dictionary<string, string>
            {
                ["q"] = query,
                ["page"] = paginationParameters.Page.ToString(),
                ["page_size"] = paginationParameters.PageSize.ToString()
            });

            return new GenericTypeConversion<TrackSearch.TrackList, Track>().
                MergeToList(response.Cast<TrackSearch>().Results, (list, list1) => list1.Add(list.Track));
        }

        /// <summary>
        /// Search the Musixmatch song database for a track.
        /// </summary>
        /// <param name="artist">The song artist</param>
        /// <param name="song">The song title</param>
        /// <param name="paginationParameters">Pagination parameters</param>
        /// <returns>List of tracks</returns>
        public List<Track> SongSearch(string artist, string song, PaginationParameters paginationParameters = null)
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

            return new GenericTypeConversion<TrackSearch.TrackList, Track>().
                MergeToList(response.Cast<TrackSearch>().Results, (list, list1) => list1.Add(list.Track));
        }

        /// <summary>
        /// Search the Musixmatch song database for a track async.
        /// </summary>
        /// <param name="artist">The song artist</param>
        /// <param name="song">The song title</param>
        /// <param name="paginationParameters">Pagination parameters</param>
        /// <returns>List of tracks</returns>
        public async Task<List<Track>> SongSearchAsync(string artist, string song, PaginationParameters paginationParameters = null)
        {
            if (paginationParameters == null)
                paginationParameters = new PaginationParameters();
            var response = await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.TrackSearch, new Dictionary<string, string>
            {
                ["q_artist"] = artist,
                ["q_track"] = song,
                ["page"] = paginationParameters.Page.ToString(),
                ["page_size"] = paginationParameters.PageSize.ToString()
            });

            return new GenericTypeConversion<TrackSearch.TrackList, Track>().
                MergeToList(response.Cast<TrackSearch>().Results, (list, list1) => list1.Add(list.Track));
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

            return new GenericTypeConversion<TrackSearch.TrackList, Track>().
                MergeToList(response.Cast<TrackSearch>().Results, (list, list1) => list1.Add(list.Track));
        }

        /// <summary>
        /// Search the Musixmatch song database for a track by the piece of lyrics async.
        /// </summary>
        /// <param name="lyrics">Piece of lyrics to search</param>
        /// <returns>List of tracks</returns>
        public async Task<List<Track>> SongSearchByLyricsAsync(string lyrics)
        {
            var response = await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.TrackSearch, new Dictionary<string, string>
            {
                ["q_lyrics"] = lyrics
            });

            return new GenericTypeConversion<TrackSearch.TrackList, Track>().
                MergeToList(response.Cast<TrackSearch>().Results, (list, list1) => list1.Add(list.Track));
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
            return response.Cast<TrackGet>().Track;
        }

        /// <summary>
        /// Find a track by given id in Musixmatch database async.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <returns>Track</returns>
        public async Task<Track> GetTrackByIdAsync(int id)
        {
            var response = await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.TrackGet, new Dictionary<string, string>
            {
                ["track_id"] = id.ToString()
            });
            return response.Cast<TrackGet>().Track;
        }

        /// <summary>
        /// Get track snippet by its Musixmatch id. Snippet is the most memorable line.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <returns>If the song is not instrumental, returns the snippet, otherwise returns an empty string</returns>
        public string GetTrackSnippet(int id)
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.TrackSnippetGet, new Dictionary<string, string>
            {
                ["track_id"] = id.ToString()
            });
            var snippet = response.Cast<TrackSnippetGet>();
            return snippet.Snippet.Instrumental == 0 ? snippet.Snippet.SnippetBody : string.Empty;
        }

        /// <summary>
        /// Get track snippet by its Musixmatch id. Snippet is the most memorable line async.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <returns>If the song is not instrumental, returns the snippet, otherwise returns an empty string</returns>
        public async Task<string> GetTrackSnippetAsync(int id)
        {
            var response = await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.TrackSnippetGet, new Dictionary<string, string>
            {
                ["track_id"] = id.ToString()
            });
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
            /// <summary>Dfxp (XML) format.</summary>
            Dfxp,
            /// <summary>Stledu format.</summary>
            Stledu,
            /// <summary>JSON representation, used by Musixmatch desktop client and is not documented in the official API sheet.</summary>
            Musixmatch
        }

        /// <summary>
        /// Get synced subtitles for the song by its Musixmatch id.
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
            return response.Cast<TrackSubtitleGet>().Subtitle;
        }

        /// <summary>
        /// Get synced subtitles for the song by its Musixmatch id async.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="format">Subtitle format</param>
        /// <returns>Subtitle</returns>
        public async Task<SubtitleRawResponse> GetTrackSubtitlesRawAsync(int id, SubtitleFormat format = SubtitleFormat.Lrc)
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
            var response = await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.TrackSubtitleGet, parameters);
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
        /// Get synced lyrics in MusixmatchClientLib format as an array of <see cref="LyricsLine"/>s.
        /// </summary>
        /// <param name="id">Musximatch track id</param>
        /// <returns>Array of LyricsLines</returns>
        public async Task<Subtitles> GetTrackSubtitlesAsync(int id)
        {
            var synced = await GetTrackSubtitlesRawAsync(id, SubtitleFormat.Musixmatch);
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
            requestFactory.SendRequest(ApiRequestFactory.ApiMethod.TrackSubtitlePost, new Dictionary<string, string>
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
        }

        /// <summary>
        /// Submit track subtitles by its Musixmatch id. Use Musixmatch (mxm) format! Async!!
        /// TODO: I don't know what's wrong, but as the subtitle is submitted, they are immediately removed from Musixmatch, but points are added.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="subtitles">Subtitle data in Musixmatch (mxm) format</param>
        public async Task SubmitTrackSubtitlesRawAsync(int id, string subtitles)
        {
            var trackData = GetTrackById(id);
            Random random = new Random();
            await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.TrackSubtitlePost, new Dictionary<string, string>
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
        }

        /// <summary>
        /// Submit track subtitles by its Musixmatch id.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="subtitles">Subtitle data</param>
        public void SubmitTrackSubtitles(int id, Subtitles subtitles) => SubmitTrackSubtitlesRaw(id, subtitles.ToString());

        /// <summary>
        /// Submit track subtitles by its Musixmatch id.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="subtitles">Subtitle data</param>
        public async Task SubmitTrackSubtitlesAsync(int id, Subtitles subtitles) => await SubmitTrackSubtitlesRawAsync(id, subtitles.ToString());

        /// <summary>
        /// Gets Musixmatch user information.
        /// </summary>
        /// <returns>User data</returns>
        public UserGet GetUserInfo()
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.UserGet);
            return response.Cast<UserGet>();
        }

        /// <summary>
        /// Gets Musixmatch user information async.
        /// </summary>
        /// <returns>User data</returns>
        public async Task<UserGet> GetUserInfoAsync()
        {
            var response = await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.UserGet);
            return response.Cast<UserGet>();
        }

        /// <summary>
        /// Get spotify <see cref="Oauthtoken"/>. I have also noticed, that even with free spotify account this token acts like premium. Learn more at <see href="developer.spotify.com"/>.
        /// </summary>
        /// <returns>Spotify token info</returns>
        public OauthTokenGet.Oauthtoken GetSpotifyOauthToken()
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.SpotifyOauthTokenGet);
            return response.Cast<OauthTokenGet>().Token;
        }

        /// <summary>
        /// Get spotify <see cref="Oauthtoken"/>. I have also noticed, that even with free spotify account this token acts like premium. Learn more at <see href="developer.spotify.com"/>.
        /// </summary>
        /// <returns>Spotify token info</returns>
        public async Task<OauthTokenGet.Oauthtoken> GetSpotifyOauthTokenAsync()
        {
            var response = await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.SpotifyOauthTokenGet);
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
            var trackLyrics = GetTrackLyrics(id).LyricsBody;
            var trackTranslations = GetLyricsTranslationsRaw(id, language);

            foreach (var translation in trackTranslations)
                trackLyrics = trackLyrics.Replace(translation.Snippet, translation.Description);

            return trackLyrics;
        }

        /// <summary>
        /// Gets lyrics translation.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="language">Selected language in ISO format</param>
        /// <returns>String with translated lyrics</returns>
        public async Task<string> GetLyricsTranslationAsync(int id, string language)
        {
            var trackLyrics = (await GetTrackLyricsAsync(id)).LyricsBody;
            var trackTranslations = await GetLyricsTranslationsRawAsync(id, language);

            foreach (var translation in trackTranslations)
                trackLyrics = trackLyrics.Replace(translation.Snippet, translation.Description);

            return trackLyrics;
        }

        /// <summary>
        /// Gets raw lyrics translation object.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="language">Selected language in ISO format</param>
        /// <returns>List of translated lyrics</returns>
        public List<Translation> GetLyricsTranslationLines(int id, string language)
        {
            List<Translation> translations = new List<Translation>();
            foreach (var translation in GetLyricsTranslationsRaw(id, language))
                translations.Add(new Translation { OriginalLine = translation.Snippet, TranslatedLine = translation.Description });
            return translations;
        }

        /// <summary>
        /// Gets raw lyrics translation object.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="language">Selected language in ISO format</param>
        /// <returns>List of translated lyrics</returns>
        public async Task<List<Translation>> GetLyricsTranslationLinesAsync(int id, string language)
        {
            List<Translation> translations = new List<Translation>();
            foreach (var translation in await GetLyricsTranslationsRawAsync(id, language))
                translations.Add(new Translation { OriginalLine = translation.Snippet, TranslatedLine = translation.Description });
            return translations;
        }

        /// <summary>
        /// Gets raw lyrics translation object.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="language">Selected language in ISO format</param>
        /// <returns>List of translated lyrics</returns>
        public List<CrowdTrackTranslationsGet.Translation> GetLyricsTranslationsRaw(int id, string language)
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.CrowdTrackTranslationsGet, new Dictionary<string, string>
            {
                ["track_id"] = id.ToString(),
                ["selected_language"] = language
            });
            List<CrowdTrackTranslationsGet.Translation> translations = new List<CrowdTrackTranslationsGet.Translation>();
            foreach (var translation in response.Cast<CrowdTrackTranslationsGet>().TranslationsList)
                translations.Add(translation.Translation);
            return translations;
        }

        /// <summary>
        /// Gets raw lyrics translation object.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="language">Selected language in ISO format</param>
        /// <returns>List of translated lyrics</returns>
        public async Task<List<CrowdTrackTranslationsGet.Translation>> GetLyricsTranslationsRawAsync(int id, string language)
        {
            var response = await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.CrowdTrackTranslationsGet, new Dictionary<string, string>
            {
                ["track_id"] = id.ToString(),
                ["selected_language"] = language
            });
            List<CrowdTrackTranslationsGet.Translation> translations = new List<CrowdTrackTranslationsGet.Translation>();
            foreach (var translation in response.Cast<CrowdTrackTranslationsGet>().TranslationsList)
                translations.Add(translation.Translation);
            return translations;
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
            return response.Cast<CrowdUserFeedbackGet>().Feedbacks;
        }

        /// <summary>
        /// Returns a list of user feedbacks (activity).  
        /// </summary>
        /// <returns>List of feedbacks</returns>
        public async Task<List<FeedbackList>> GetCrowdUserFeedbackAsync()
        {
            var response = await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.CrowdUserFeedbackGet, new Dictionary<string, string>
            {
                ["feedback_type"] = "lyrics_missing,lyrics_ok,lyrics_ko,lyrics_generic_ko,lyrics_changed,lyrics_subtitle_added,lyrics_favourite_added,lyrics_music_id,track_annotat",
                ["part"] = "user,track"
            });
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
            return response.Cast<CrowdFeedbackGet>().Feedbacks;
        }

        /// <summary>
        /// Returns a list of community activity.
        /// </summary>
        /// <returns>List of feedbacks</returns>
        // TODO: scopes (!!!)
        public async Task<List<FeedbackList>> GetCrowdFeedbackAsync()
        {
            var response = await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.CrowdFeedbackGet, new Dictionary<string, string>
            {
                ["part"] = "user,track"
            });
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
            return response.Cast<TrackLyricsGet>().Lyrics;
        }

        /// <summary>
        /// Get track lyrics by its Musixmatch id.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <returns>Lyrics</returns>
        public async Task<Lyrics> GetTrackLyricsAsync(int id)
        {
            var response = await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.TrackLyricsGet, new Dictionary<string, string>
            {
                ["track_id"] = id.ToString(),
                ["part"] = "user,lyrics_verified_by"
            });
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
            requestFactory.SendRequest(ApiRequestFactory.ApiMethod.TrackLyricsPost, new Dictionary<string, string>
            {
                ["commontrack_id"] = trackData.CommontrackId.ToString(),
                ["q_track"] = trackData.TrackName,
                ["q_artist"] = trackData.ArtistName
            }, new Dictionary<string, string>
            {
                ["lyrics_body"] = lyrics
            });
        }

        /// <summary>
        /// Submit track lyrics by its Musixmatch id.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="lyrics">Track lyrics</param>
        public async Task SubmitTrackLyricsAsync(int id, string lyrics)
        {
            var trackData = await GetTrackByIdAsync(id);
            await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.TrackLyricsPost, new Dictionary<string, string>
            {
                ["commontrack_id"] = trackData.CommontrackId.ToString(),
                ["q_track"] = trackData.TrackName,
                ["q_artist"] = trackData.ArtistName
            }, new Dictionary<string, string>
            {
                ["lyrics_body"] = lyrics
            });
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

            return new GenericTypeConversion<ChartTracksGet.TrackListItem, string>().
                MergeToList(response.Cast<ChartTracksGet>().TrackList, (item, list) => list.Add(item.Track));
        }

        /// <summary>
        /// Get trending tracks.
        /// Not working yet.
        /// </summary>
        /// <returns>List of track ids</returns>
        public async Task<List<string>> ChartTracksGetAsync(PaginationParameters paginationParameters = null)
        {
            if (paginationParameters == null)
                paginationParameters = new PaginationParameters();
            List<string> returnValue = new List<string>();
            var response = await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.ChartTracksGet, new Dictionary<string, string>
            {
                ["page"] = paginationParameters.Page.ToString(),
                ["page_size"] = paginationParameters.PageSize.ToString()
            });

            return new GenericTypeConversion<ChartTracksGet.TrackListItem, string>().
                MergeToList(response.Cast<ChartTracksGet>().TrackList, (item, list) => list.Add(item.Track));
        }

        /// <summary>
        /// Get tracks that need your contribution. 
        /// Not working yet. Use <see cref="GetContributeSuggestionsTracks"/> instead.
        /// </summary>
        /// <returns>List of tracks</returns>
        public List<Track> GetPollTracks()
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.CrowdPollsTracksSearch);
            return new GenericTypeConversion<TrackSearch.TrackList, Track>().
                MergeToList(response.Cast<TrackSearch>().Results, (list, list1) => list1.Add(list.Track));
        }

        /// <summary>
        /// Get tracks that need your contribution. 
        /// Not working yet. Use <see cref="GetContributeSuggestionsTracks"/> instead.
        /// </summary>
        /// <returns>List of tracks</returns>
        public async Task<List<Track>> GetPollTracksAsync()
        {
            var response = await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.CrowdPollsTracksSearch);
            return new GenericTypeConversion<TrackSearch.TrackList, Track>().
                MergeToList(response.Cast<TrackSearch>().Results, (list, list1) => list1.Add(list.Track));
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

            return new GenericTypeConversion<CrowdSuggestionGet.TrackList, Track>().
                MergeToList(response.Cast<CrowdSuggestionGet>().Results, (list, list1) => list1.Add(list.Track));
        }

        /// <summary>
        /// Get tracks that need your contribution using scopes. See <see cref="ContributionType"/>.
        /// </summary>
        /// <returns>List of tracks</returns>
        public async Task<List<Track>> GetContributeSuggestionsTracksAsync(ContributionType contributionType, string language = "")
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
            var response = await requestFactory.SendRequestAsync(apiMethod, new Dictionary<string, string>
            {
                ["language"] = language
            });

            return new GenericTypeConversion<CrowdSuggestionGet.TrackList, Track>().
                MergeToList(response.Cast<CrowdSuggestionGet>().Results, (list, list1) => list1.Add(list.Track));
        }

        /// <summary>
        /// Submit AI question data (track language).
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="language">ISO language abbreviation (lowercase)</param>
        public void SubmitTrackLanguage(int id, string language)
        {
            requestFactory.SendRequest(ApiRequestFactory.ApiMethod.AiQuestionPost, new Dictionary<string, string>
            {
                ["answer_id"] = "lyrics_ai_ugc_language",
                ["track_id"] = id.ToString(),
                ["selected_language"] = language,
                ["question_id"] = "lyrics_ai_language_collect"
            });
        }

        /// <summary>
        /// Submit AI question data (track language).
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="language">ISO language abbreviation (lowercase)</param>
        public async Task SubmitTrackLanguageAsync(int id, string language)
        {
            await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.AiQuestionPost, new Dictionary<string, string>
            {
                ["answer_id"] = "lyrics_ai_ugc_language",
                ["track_id"] = id.ToString(),
                ["selected_language"] = language,
                ["question_id"] = "lyrics_ai_language_collect"
            });
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
            requestFactory.SendRequest(ApiRequestFactory.ApiMethod.AiQuestionPost, new Dictionary<string, string>
            {
                ["answer_id"] = "lyrics_ai_mood_analysis_v3_value",
                ["track_id"] = id.ToString(),
                ["energy_ratio"] = energy.ToString(),
                ["mood_ratio"] = mood.ToString(),
                ["question_id"] = "lyrics_ai_mood_analysis_v3"
            });
        }

        /// <summary>
        /// Submit AI question data (track mood).
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="energy">Track energy ratio (integer between 0 and 100)</param>
        /// <param name="mood">Track mood ratio (integer between 0 and 100)</param>
        public async Task SubmitTrackMoodAsync(int id, int energy, int mood)
        {
            if (energy > 100 || energy < 0)
                throw new ArgumentException("Track energy is an integer between 0 and 100");
            if (mood > 100 || mood < 0)
                throw new ArgumentException("Track mood is an integer between 0 and 100");
            await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.AiQuestionPost, new Dictionary<string, string>
            {
                ["answer_id"] = "lyrics_ai_mood_analysis_v3_value",
                ["track_id"] = id.ToString(),
                ["energy_ratio"] = energy.ToString(),
                ["mood_ratio"] = mood.ToString(),
                ["question_id"] = "lyrics_ai_mood_analysis_v3"
            });
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

            return new GenericTypeConversion<CrowdChartUsersGet.TrackList, User>().
                MergeToList(response.Cast<CrowdChartUsersGet>().Results, (list, list1) => list1.Add(list.User));
        }

        /// <summary>
        /// Returns user top for a country.
        /// </summary>
        /// <param name="country">Country ISO code</param>
        /// <returns>List of top users</returns>
        public async Task<List<User>> GetUserWeeklyTopAsync(string country = "", PaginationParameters paginationParameters = null)
        {
            if (paginationParameters == null)
                paginationParameters = new PaginationParameters();
            var response = await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.CrowdChartUsersGet, new Dictionary<string, string>
            {
                ["country"] = country,
                ["page"] = paginationParameters.Page.ToString(),
                ["page_size"] = paginationParameters.PageSize.ToString()
            });

            return new GenericTypeConversion<CrowdChartUsersGet.TrackList, User>().
                MergeToList(response.Cast<CrowdChartUsersGet>().Results, (list, list1) => list1.Add(list.User));
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
            return response.Cast<TrackRichsyncGet>().Richsync;
        }

        /// <summary>
        /// Get track richsync by its Musixmatch id.
        /// Body has a <see href="https://developer.musixmatch.com/documentation/api-reference/track-richsync-get">specific format</see>.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <returns>Raw richsync response</returns>
        public async Task<RichsyncRawResponse> GetTrackRichsyncRawAsync(int id)
        {
            var response = await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.TrackRichsyncGet, new Dictionary<string, string>
            {
                ["track_id"] = id.ToString()
            });
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
        /// Get track richsync by its Musixmatch id.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <returns>Richsync</returns>
        public async Task<Richsync> GetTrackRichsyncAsync(int id)
        {
            RichsyncRawResponse richsyncRawResponse = await GetTrackRichsyncRawAsync(id);
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
            requestFactory.SendRequest(ApiRequestFactory.ApiMethod.TrackRichsyncPost, new Dictionary<string, string>
            {
                ["commontrack_id"] = trackData.CommontrackId.ToString(),
                ["length"] = trackData.TrackLength.ToString(),
                ["q_track"] = trackData.TrackName,
                ["original_title"] = trackData.TrackName,
                ["q_artist"] = trackData.ArtistName,
                ["original_artist"] = trackData.ArtistName,
                ["original_uri"] = trackData.TrackSpotifyId,
                ["num_keypressed"] = random.Next(32, 4086).ToString(), // Oh, so much keys pressed
                ["time_spent"] = random.Next(2048, 1048576).ToString() // Oh, so much time spent
            }, new Dictionary<string, string>()
            {
                ["richsync_body"] = richsync
            });
        }

        /// <summary>
        /// Submit track richsync by its Musixmatch id.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="richsync">Raw richsync</param>
        public async Task SubmitTrackRichsyncRawAsync(int id, string richsync)
        {
            var trackData = GetTrackById(id);
            Random random = new Random();
            await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.TrackRichsyncPost, new Dictionary<string, string>
            {
                ["commontrack_id"] = trackData.CommontrackId.ToString(),
                ["length"] = trackData.TrackLength.ToString(),
                ["q_track"] = trackData.TrackName,
                ["original_title"] = trackData.TrackName,
                ["q_artist"] = trackData.ArtistName,
                ["original_artist"] = trackData.ArtistName,
                ["original_uri"] = trackData.TrackSpotifyId,
                ["num_keypressed"] = random.Next(32, 4086).ToString(), // Oh, so much keys pressed
                ["time_spent"] = random.Next(2048, 1048576).ToString() // Oh, so much time spent
            }, new Dictionary<string, string>()
            {
                ["richsync_body"] = richsync
            });
        }


        /// <summary>
        /// Submit track richsync by its Musixmatch id.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="richsync">Richsync</param>
        public void SubmitTrackRichsync(int id, Richsync richsync) => SubmitTrackRichsyncRaw(id, richsync.ToString());

        /// <summary>
        /// Submit track richsync by its Musixmatch id.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="richsync">Richsync</param>
        public async Task SubmitTrackRichsyncAsync(int id, Richsync richsync) => await SubmitTrackRichsyncRawAsync(id, richsync.ToString());

        /// <summary>
        /// Get current user score.
        /// </summary>
        /// <returns>User</returns>
        public User GetUserScore()
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.CrowdScoreGet);
            return response.Cast<CrowdScoreGet>().User;
        }

        /// <summary>
        /// Get current user score.
        /// </summary>
        /// <returns>User</returns>
        public async Task<User> GetUserScoreAsync()
        {
            var response = await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.CrowdScoreGet);
            return response.Cast<CrowdScoreGet>().User;
        }

        /// <summary>
        /// Get all the genres supported by Musixmatch database.
        /// </summary>
        /// <returns>List of genres</returns>
        public List<MusicGenre> GetMusicGenres()
        {
            var response = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.MusicGenresGet);

            return new GenericTypeConversion<MusicGenresGet.MusicGenreList, MusicGenre>().
                MergeToList(response.Cast<MusicGenresGet>().Results, (list, musicGenres) => musicGenres.Add(list.MusicGenre));
        }

        /// <summary>
        /// Get all the genres supported by Musixmatch database.
        /// </summary>
        /// <returns>List of genres</returns>
        public async Task<List<MusicGenre>> GetMusicGenresAsync()
        {
            var response = await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.MusicGenresGet);

            return new GenericTypeConversion<MusicGenresGet.MusicGenreList, MusicGenre>().
                MergeToList(response.Cast<MusicGenresGet>().Results, (list, musicGenres) => musicGenres.Add(list.MusicGenre));
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

            return new GenericTypeConversion<ChartArtistsGet.ArtistList, Artist>().
                MergeToList(response.Cast<ChartArtistsGet>().Results, (list, list1) => list1.Add(list.Artist));
        }

        /// <summary>
        /// Get top artists by the given country
        /// </summary>
        /// <param name="country">Country ISO code</param>
        /// <returns>List of artists</returns>
        public async Task<List<Artist>> GetChartArtistsAsync(string country = "", PaginationParameters paginationParameters = null)
        {
            if (paginationParameters == null)
                paginationParameters = new PaginationParameters();
            var response = await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.ChartArtistsGet, new Dictionary<string, string>
            {
                ["country"] = country,
                ["page"] = paginationParameters.Page.ToString(),
                ["page_size"] = paginationParameters.PageSize.ToString()
            });

            return new GenericTypeConversion<ChartArtistsGet.ArtistList, Artist>().
                MergeToList(response.Cast<ChartArtistsGet>().Results, (list, list1) => list1.Add(list.Artist));
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

            return new GenericTypeConversion<ArtistSearch.ArtistList, Artist>().
                MergeToList(response.Cast<ArtistSearch>().Results, (list, list1) => list1.Add(list.Artist));
        }

        /// <summary>
        /// Look for artists in the database by query.
        /// </summary>
        /// <param name="query">Query</param>
        /// <returns>List of artists</returns>
        public async Task<List<Artist>> ArtistSearchAsync(string query, PaginationParameters paginationParameters = null)
        {
            if (paginationParameters == null)
                paginationParameters = new PaginationParameters();
            var response = await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.ArtistSearch, new Dictionary<string, string>
            {
                ["q_artist"] = query,
                ["page"] = paginationParameters.Page.ToString(),
                ["page_size"] = paginationParameters.PageSize.ToString()
            });

            return new GenericTypeConversion<ArtistSearch.ArtistList, Artist>().
                MergeToList(response.Cast<ArtistSearch>().Results, (list, list1) => list1.Add(list.Artist));
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
            return response.Cast<ArtistGet>().Artist;
        }

        /// <summary>
        /// Get artist by his Musixmatch id.
        /// </summary>
        /// <param name="id">Musixmatch id</param>
        /// <returns>Artist</returns>
        public async Task<Artist> GetArtistByIdAsync(int id)
        {
            var response = await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.ArtistGet, new Dictionary<string, string>
            {
                ["artist_id"] = id.ToString()
            });
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

            return new GenericTypeConversion<ArtistAlbumsGet.AlbumList, Album>().
                MergeToList(response.Cast<ArtistAlbumsGet>().Results, (list, list1) => list1.Add(list.Album));
        }

        /// <summary>
        /// Get albums by artist
        /// </summary>
        /// <param name="id">Artist id</param>
        /// <returns>List of albums</returns>
        public async Task<List<Album>> GetArtistAlbumsAsync(int id, PaginationParameters paginationParameters = null)
        {
            if (paginationParameters == null)
                paginationParameters = new PaginationParameters();
            var response = await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.ArtistAlbumsGet, new Dictionary<string, string>
            {
                ["artist_id"] = id.ToString(),
                ["page"] = paginationParameters.Page.ToString(),
                ["page_size"] = paginationParameters.PageSize.ToString()
            });

            return new GenericTypeConversion<ArtistAlbumsGet.AlbumList, Album>().
                MergeToList(response.Cast<ArtistAlbumsGet>().Results, (list, list1) => list1.Add(list.Album));
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
            return response.Cast<AlbumGet>().Album;
        }

        /// <summary>
        /// Get album by its Musixmatch id.
        /// </summary>
        /// <param name="id">Musixmatch album id</param>
        /// <returns>Album</returns>
        public async Task<Album> GetAlbumByIdAsync(int id)
        {
            var response = await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.AlbumGet, new Dictionary<string, string>
            {
                ["album_id"] = id.ToString()
            });
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

            return new GenericTypeConversion<AlbumTracksGet.TrackList, Track>().
                MergeToList(response.Cast<AlbumTracksGet>().Results, (list, list1) => list1.Add(list.Track));
        }

        /// <summary>
        /// Get tracks from chosen album
        /// </summary>
        /// <param name="id">Musixmatch album id</param>
        /// <returns>List of tracks</returns>
        public async Task<List<Track>> GetAlbumTracksAsync(int id, PaginationParameters paginationParameters = null)
        {
            if (paginationParameters == null)
                paginationParameters = new PaginationParameters();
            var response = await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.AlbumTracksGet, new Dictionary<string, string>
            {
                ["album_id"] = id.ToString(),
                ["page"] = paginationParameters.Page.ToString(),
                ["page_size"] = paginationParameters.PageSize.ToString()
            });

            return new GenericTypeConversion<AlbumTracksGet.TrackList, Track>().
                MergeToList(response.Cast<AlbumTracksGet>().Results, (list, list1) => list1.Add(list.Track));
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
            requestFactory.SendRequest(ApiRequestFactory.ApiMethod.TrackLyricsTranslationPost, new Dictionary<string, string>
            {
                ["commontrack_id"] = trackData.CommontrackId.ToString(),
                ["track_id"] = trackData.TrackId.ToString()
            }, new Dictionary<string, string>()
            {
                ["translations_list"] = JsonConvert.SerializeObject(translation),
                ["time_spent"] = timeSpent.ToString()
            });
        }

        /// <summary>
        /// Submit track translation by Musixmatch track id.
        /// </summary>
        /// <param name="id">Musixmatch track id</param>
        /// <param name="translation">List of <see cref="TranslationPost"/>s.</param>
        /// <param name="timeSpent">Time spent on the translation in milliseconds.</param>
        public async Task SubmitTrackTranslationsRawAsync(int id, List<TranslationPost> translation, int timeSpent = int.MaxValue)
        {
            var trackData = await GetTrackByIdAsync(id);
            await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.TrackLyricsTranslationPost, new Dictionary<string, string>
            {
                ["commontrack_id"] = trackData.CommontrackId.ToString(),
                ["track_id"] = trackData.TrackId.ToString()
            }, new Dictionary<string, string>()
            {
                ["translations_list"] = JsonConvert.SerializeObject(translation),
                ["time_spent"] = timeSpent.ToString()
            });
        }


        /// <summary>
        /// Update user's profile and leaderboard country.
        /// </summary>
        /// <param name="country">Country ISO code</param>
        public void UpdateUserProfileCountry(string country)
        {
            requestFactory.SendRequest(ApiRequestFactory.ApiMethod.CrowdUserProfilePost, null, new Dictionary<string, string>
            {
                ["profile"] = $"{{\"country\":\"{country.ToUpper()}\"}}"
            });
        }

        /// <summary>
        /// Update user's profile and leaderboard country.
        /// </summary>
        /// <param name="country">Country ISO code</param>
        public async Task UpdateUserProfileCountryAsync(string country)
        {
            await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.CrowdUserProfilePost, null, new Dictionary<string, string>
            {
                ["profile"] = $"{{\"country\":\"{country.ToUpper()}\"}}"
            });
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

            requestFactory.SendRequest(ApiRequestFactory.ApiMethod.CrowdUserProfilePost, null, new Dictionary<string, string>
            {
                ["profile"] = $"{{\"favourite_artists\":{artistString}}}"
            });
        }

        /// <summary>
        /// Update user's profile favourite artists.
        /// </summary>
        /// <param name="artistIds">List of artist ids to favourite</param>
        public async Task UpdateUserProfileFavouriteArtistsAsync(List<int> artistIds)
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

            await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.CrowdUserProfilePost, null, new Dictionary<string, string>
            {
                ["profile"] = $"{{\"favourite_artists\":{artistString}}}"
            });
        }

        /// <summary>
        /// Update user's profile favourite genres.
        /// </summary>
        /// <param name="genreIds">List of genre ids to favourite</param>
        public void UpdateUserProfileFavouriteGenres(List<int> genreIds)
        {
            string artistString = "[]";

            if (genreIds.Count != 0)
            {
                StringBuilder artistStringBuilder = new StringBuilder("[");
                foreach (var artistId in genreIds)
                    artistStringBuilder.Append(artistId.ToString() + ',');
                artistStringBuilder[artistStringBuilder.Length - 1] = ']';
                artistString = artistStringBuilder.ToString();
            }

            requestFactory.SendRequest(ApiRequestFactory.ApiMethod.CrowdUserProfilePost, new Dictionary<string, string> { }, new Dictionary<string, string>
            {
                ["profile"] = $"{{\"favourite_genres\":{artistString}}}"
            });
        }

        /// <summary>
        /// Update user's profile favourite genres.
        /// </summary>
        /// <param name="genreIds">List of genre ids to favourite</param>
        public async Task UpdateUserProfileFavouriteGenresAsync(List<int> genreIds)
        {
            string artistString = "[]";

            if (genreIds.Count != 0)
            {
                StringBuilder artistStringBuilder = new StringBuilder("[");
                foreach (var artistId in genreIds)
                    artistStringBuilder.Append(artistId.ToString() + ',');
                artistStringBuilder[artistStringBuilder.Length - 1] = ']';
                artistString = artistStringBuilder.ToString();
            }

            await requestFactory.SendRequestAsync(ApiRequestFactory.ApiMethod.CrowdUserProfilePost, new Dictionary<string, string> { }, new Dictionary<string, string>
            {
                ["profile"] = $"{{\"favourite_genres\":{artistString}}}"
            });
        }

        public MissionManager RequestMissionManager() => new MissionManager(requestFactory);
    }
}
