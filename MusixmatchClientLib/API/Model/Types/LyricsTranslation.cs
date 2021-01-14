using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusixmatchClientLib.API.Model.Types
{
    public class TranslatedLyrics
    {
        [JsonProperty("selected_language")]
        public string SelectedLanguage;

        [JsonProperty("lyrics_body")]
        public string LyricsBody;

        [JsonProperty("script_tracking_url")]
        public string ScriptTrackingUrl;
    }

    public class LyricsTranslation
    {
        [JsonProperty("lyrics_id")]
        public int LyricsId;

        [JsonProperty("lyrics_body")]
        public string LyricsBody;

        [JsonProperty("script_tracking_url")]
        public string ScriptTrackingUrl;

        [JsonProperty("translated_lyrics")]
        public TranslatedLyrics TranslatedLyrics;
    }
}
