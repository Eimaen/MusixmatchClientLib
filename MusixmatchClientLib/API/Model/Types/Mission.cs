using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusixmatchClientLib.API.Model.Types
{
    public class Mission
    {
        [JsonProperty("id")]
        public string Id;
        [JsonProperty("title")]
        public string Title;
        [JsonProperty("description")]
        public string Description;
    }
}
