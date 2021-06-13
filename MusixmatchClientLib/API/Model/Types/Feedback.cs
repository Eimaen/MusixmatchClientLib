using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusixmatchClientLib.API.Model.Types
{
    public class Feedback
    {
        [JsonProperty("type_id")]
        public string TypeId;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("app_id")]
        public string AppId;

        [JsonProperty("prev_lyrics_id")]
        public object PrevLyricsId;

        [JsonProperty("artist_id")]
        public int ArtistId;

        [JsonProperty("wantkey")]
        public bool Wantkey;

        [JsonProperty("lyrics_id")]
        public int LyricsId;

        [JsonProperty("type_id_weight")]
        public int TypeIdWeight;

        [JsonProperty("moderator")]
        public int Moderator;

        [JsonProperty("effectiveness")]
        public double Effectiveness;

        [JsonProperty("days_in_chart")]
        public int DaysInChart;

        [JsonProperty("last_updated")]
        public DateTime LastUpdated;

        [JsonProperty("key")]
        public string Key;

        [JsonProperty("create_timestamp")]
        public int CreateTimestamp;

        [JsonProperty("group_key")]
        public string GroupKey;

        [JsonProperty("image_id")]
        public int ImageId;

        [JsonProperty("video_id")]
        public int VideoId;

        [JsonProperty("subtitle_id")]
        public int SubtitleId;

        [JsonProperty("updated_time")]
        public DateTime UpdatedTime;

        [JsonProperty("created_date")]
        public DateTime CreatedDate;

        [JsonProperty("commontrack_id")]
        public int CommontrackId;

        [JsonProperty("friendly_type_id")]
        public string FriendlyTypeId;

        [JsonProperty("is_expired")]
        public int IsExpired;

        [JsonProperty("track")]
        public Track Track;

        [JsonProperty("user")]
        public User User;

        [JsonProperty("time_spent")]
        public string TimeSpent;

        [JsonProperty("num_keypressed")]
        public object NumKeypressed;
    }

    public class FeedbackList
    {
        [JsonProperty("feedback")]
        public Feedback Feedback;
    }
}
