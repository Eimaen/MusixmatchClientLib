using Newtonsoft.Json;
using System;

namespace MusixmatchClientLib.API.Model.Types
{
    public class Snippet
    {
        [JsonProperty("snippet_id")]
        public int SnippetId;

        [JsonProperty("snippet_language")]
        public string SnippetLanguage;

        [JsonProperty("restricted")]
        public int Restricted;

        [JsonProperty("instrumental")]
        public int Instrumental;

        [JsonProperty("snippet_body")]
        public string SnippetBody;

        [JsonProperty("script_tracking_url")]
        public string ScriptTrackingUrl;

        [JsonProperty("pixel_tracking_url")]
        public string PixelTrackingUrl;

        [JsonProperty("html_tracking_url")]
        public string HtmlTrackingUrl;

        [JsonProperty("updated_time")]
        public DateTime UpdatedTime;
    }
}
