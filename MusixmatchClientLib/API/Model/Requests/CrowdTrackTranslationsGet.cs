using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MusixmatchClientLib.API.Model.Requests
{
    public class CrowdTrackTranslationsGet : MusixmatchApiResponse
    {
        [JsonProperty("translations_list")]
        public List<TranslationsListRoot> TranslationsList;

        public class PostActionParams
        {
            [JsonProperty("skip_stats_update")]
            public bool SkipStatsUpdate;
        }

        public class Translation
        {
            [JsonProperty("type_id")]
            public string TypeId;

            [JsonProperty("artist_id")]
            public int ArtistId;

            [JsonProperty("language_from")]
            public string LanguageFrom;

            [JsonProperty("app_id")]
            public string AppId;

            [JsonProperty("ids")]
            public string Ids;

            [JsonProperty("snippet")]
            public string Snippet;

            [JsonProperty("description")]
            public string Description;

            [JsonProperty("selected_language")]
            public string SelectedLanguage;

            [JsonProperty("num_keypressed")]
            public int NumKeypressed;

            [JsonProperty("position")]
            public int Position;

            [JsonProperty("do_not_increment_ranking")]
            public bool DoNotIncrementRanking;

            [JsonProperty("do_not_detect_language")]
            public bool DoNotDetectLanguage;

            [JsonProperty("language")]
            public string Language;

            [JsonProperty("wantkey")]
            public bool Wantkey;

            [JsonProperty("group_key")]
            public string GroupKey;

            [JsonProperty("_validated")]
            public bool Validated;

            [JsonProperty("create_timestamp")]
            public int CreateTimestamp;

            [JsonProperty("type_id_weight")]
            public int TypeIdWeight;

            [JsonProperty("effectiveness")]
            public double Effectiveness;

            [JsonProperty("days_in_chart")]
            public int DaysInChart;

            [JsonProperty("last_updated")]
            public DateTime LastUpdated;

            [JsonProperty("key")]
            public string Key;

            [JsonProperty("matched_line")]
            public string MatchedLine;

            [JsonProperty("subtitle_matched_line")]
            public string SubtitleMatchedLine;

            [JsonProperty("confidence")]
            public double Confidence;

            [JsonProperty("user_score")]
            public int UserScore;

            [JsonProperty("published_status_macro")]
            public int PublishedStatusMacro;

            [JsonProperty("image_id")]
            public int ImageId;

            [JsonProperty("video_id")]
            public int VideoId;

            [JsonProperty("lyrics_id")]
            public int LyricsId;

            [JsonProperty("subtitle_id")]
            public int SubtitleId;

            [JsonProperty("created_date")]
            public DateTime CreatedDate;

            [JsonProperty("commontrack_id")]
            public int CommontrackId;

            [JsonProperty("is_expired")]
            public int IsExpired;

            [JsonProperty("can_translate")]
            public int CanTranslate;

            [JsonProperty("can_delete")]
            public int CanDelete;

            [JsonProperty("is_mine")]
            public int IsMine;

            [JsonProperty("can_approve")]
            public int CanApprove;

            [JsonProperty("moderator")]
            public int? Moderator;

            [JsonProperty("votes")]
            public Votes Votes;

            [JsonProperty("post_action_params")]
            public PostActionParams PostActionParams;
        }

        public class TranslationsListRoot
        {
            [JsonProperty("translation")]
            public Translation Translation;
        }

        public class Votes
        {
            [JsonProperty("translation_ok")]
            public int TranslationOk;
        }
    }
}
