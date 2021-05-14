﻿using Newtonsoft.Json;

namespace MusixmatchClientLib.API.Model.Requests
{
    public class TrackLyricsTranslationGet : MusixmatchApiResponse
    {
        [JsonProperty("lyrics")]
        public TranslationLyrics Lyrics;

        public class TranslatedLyrics
        {
            [JsonProperty("selected_language")]
            public string SelectedLanguage;

            [JsonProperty("lyrics_body")]
            public string LyricsBody;

            [JsonProperty("script_tracking_url")]
            public string ScriptTrackingUrl;
        }

        public class TranslationLyrics
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
}
