﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusixmatchClientLib.API.Model.Types
{
    public class TranslationPost
    {
        [JsonProperty("originalIndex")]
        public string OriginalIndex;

        [JsonProperty("selected_language")]
        public string Language;

        [JsonProperty("description")]
        public string Translation;

        [JsonProperty("position")]
        public int Position;

        [JsonProperty("snippet")]
        public string SourceLine;
    }
}
