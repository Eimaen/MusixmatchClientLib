using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusixmatchClientLib.API.Model.Types
{
    public class RankColors
    {
        [JsonProperty("rank_color_10")]
        public string RankColor10;

        [JsonProperty("rank_color_50")]
        public string RankColor50;

        [JsonProperty("rank_color_100")]
        public string RankColor100;

        [JsonProperty("rank_color_200")]
        public string RankColor200;
    }

    public class NextRankColors
    {
        [JsonProperty("rank_color_10")]
        public string RankColor10;

        [JsonProperty("rank_color_50")]
        public string RankColor50;

        [JsonProperty("rank_color_100")]
        public string RankColor100;

        [JsonProperty("rank_color_200")]
        public string RankColor200;
    }

    public class Counters
    {
        [JsonProperty("track_translation")]
        public int TrackTranslation;

        [JsonProperty("lyrics_missing")]
        public int LyricsMissing;

        [JsonProperty("lyrics_ok")]
        public int LyricsOk;

        [JsonProperty("lyrics_ko")]
        public int LyricsKo;

        [JsonProperty("lyrics_changed")]
        public int LyricsChanged;

        [JsonProperty("vote_bonuses")]
        public int VoteBonuses;

        [JsonProperty("translation_ok")]
        public int TranslationOk;

        [JsonProperty("track_influencer_bonus_moderator_vote")]
        public int TrackInfluencerBonusModeratorVote;

        [JsonProperty("lyrics_favourite_added")]
        public int LyricsFavouriteAdded;

        [JsonProperty("lyrics_ai_phrases_not_related_no")]
        public int LyricsAiPhrasesNotRelatedNo;

        [JsonProperty("lyrics_report_contain_mistakes")]
        public int LyricsReportContainMistakes;

        [JsonProperty("lyrics_subtitle_added")]
        public int LyricsSubtitleAdded;

        [JsonProperty("lyrics_music_id")]
        public int LyricsMusicId;

        [JsonProperty("lyrics_ai_phrases_not_related_yes")]
        public int LyricsAiPhrasesNotRelatedYes;

        [JsonProperty("lyrics_report_incomplete_lyrics")]
        public int LyricsReportIncompleteLyrics;

        [JsonProperty("lyrics_ai_phrases_not_related_skip")]
        public int LyricsAiPhrasesNotRelatedSkip;

        [JsonProperty("lyrics_report_completely_wrong")]
        public int LyricsReportCompletelyWrong;

        [JsonProperty("lyrics_implicitly_ok")]
        public int LyricsImplicitlyOk;

        [JsonProperty("vote_maluses")]
        public int VoteMaluses;

        [JsonProperty("lyrics_richsync_added")]
        public int LyricsRichsyncAdded;

        [JsonProperty("lyrics_ranking_change")]
        public int LyricsRankingChange;

        [JsonProperty("lyrics_ai_mood_analysis_v3_value")]
        public int LyricsAiMoodAnalysisV3Value;

        [JsonProperty("lyrics_ai_ugc_language")]
        public int LyricsAiUgcLanguage;

        [JsonProperty("track_structure")]
        public int TrackStructure;

        [JsonProperty("track_complete_metadata")]
        public int TrackCompleteMetadata;
    }

    public class User
    {
        [JsonProperty("uaid")]
        public string Uaid;

        [JsonProperty("is_mine")]
        public int IsMine;

        [JsonProperty("user_name")]
        public string UserName;

        [JsonProperty("user_profile_photo")]
        public string UserProfilePhoto;

        [JsonProperty("has_private_profile")]
        public int HasPrivateProfile;

        [JsonProperty("score")]
        public int Score;

        [JsonProperty("position")]
        public int Position;

        [JsonProperty("weekly_score")]
        public int WeeklyScore;

        [JsonProperty("level")]
        public string Level;

        [JsonProperty("key")]
        public string Key;

        [JsonProperty("rank_level")]
        public int RankLevel;

        [JsonProperty("points_to_next_level")]
        public int PointsToNextLevel;

        [JsonProperty("ratio_to_next_level")]
        public double RatioToNextLevel;

        [JsonProperty("rank_name")]
        public string RankName;

        [JsonProperty("next_rank_name")]
        public string NextRankName;

        [JsonProperty("ratio_to_next_rank")]
        public double RatioToNextRank;

        [JsonProperty("rank_color")]
        public string RankColor;

        [JsonProperty("rank_colors")]
        public RankColors RankColors;

        [JsonProperty("rank_image_url")]
        public string RankImageUrl;

        [JsonProperty("next_rank_color")]
        public string NextRankColor;

        [JsonProperty("next_rank_colors")]
        public NextRankColors NextRankColors;

        [JsonProperty("next_rank_image_url")]
        public string NextRankImageUrl;

        [JsonProperty("counters")]
        public Counters Counters;

        [JsonProperty("academy_completed")]
        public bool AcademyCompleted;

        [JsonProperty("moderator")]
        public bool Moderator;
    }
}
