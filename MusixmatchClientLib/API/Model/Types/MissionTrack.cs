using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusixmatchClientLib.API.Model.Types
{
    public class MissionTrack
    {
        [JsonProperty("id")]
        public string Id;
        [JsonProperty("artistName")]
        public string Artist;
        [JsonProperty("commonTrackId")]
        public string CommonTrackId;
        [JsonProperty("language")]
        public string Language;
        [JsonProperty("hasLyrics")]
        public bool HasLyrics;
        [JsonProperty("hasSubtitles")]
        public bool HasSubtitles;
        [JsonProperty("title")]
        public string Title;
    }
}
