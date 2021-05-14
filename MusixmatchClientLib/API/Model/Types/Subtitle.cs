using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MusixmatchClientLib.API.Model.Types
{
    public class Subtitle
    {
        [JsonProperty("subtitle_id")]
        public int SubtitleId;

        [JsonProperty("restricted")]
        public int Restricted;

        [JsonProperty("subtitle_body")]
        public string SubtitleBody;

        [JsonProperty("subtitle_avg_count")]
        public int SubtitleAvgCount;

        [JsonProperty("lyrics_copyright")]
        public string LyricsCopyright;

        [JsonProperty("subtitle_length")]
        public int SubtitleLength;

        [JsonProperty("subtitle_language")]
        public string SubtitleLanguage;

        [JsonProperty("subtitle_language_description")]
        public string SubtitleLanguageDescription;

        [JsonProperty("script_tracking_url")]
        public string ScriptTrackingUrl;

        [JsonProperty("pixel_tracking_url")]
        public string PixelTrackingUrl;

        [JsonProperty("html_tracking_url")]
        public string HtmlTrackingUrl;

        [JsonProperty("writer_list")]
        public List<object> WriterList;

        [JsonProperty("publisher_list")]
        public List<object> PublisherList;

        [JsonProperty("updated_time")]
        public DateTime UpdatedTime;
    }
}
