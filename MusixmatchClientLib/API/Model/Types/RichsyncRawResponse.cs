using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusixmatchClientLib.API.Model.Types
{
    public class RichsyncRawResponse
    {
        [JsonProperty("richsync_id")]
        public int RichsyncId;

        [JsonProperty("restricted")]
        public int Restricted;

        [JsonProperty("richsync_body")]
        public string RichsyncBody;

        [JsonProperty("lyrics_copyright")]
        public string LyricsCopyright;

        [JsonProperty("richsync_length")]
        public int RichsyncLength;

        [JsonProperty("richsync_language")]
        public string RichsyncLanguage;

        [JsonProperty("richsync_language_description")]
        public string RichsyncLanguageDescription;

        [JsonProperty("script_tracking_url")]
        public string ScriptTrackingUrl;

        [JsonProperty("updated_time")]
        public DateTime UpdatedTime;
    }
}
