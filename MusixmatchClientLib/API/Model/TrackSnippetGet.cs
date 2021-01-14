using MusixmatchClientLib.API.Model.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusixmatchClientLib.API.Model
{
    class TrackSnippetGet
    {
        [JsonProperty("snippet")]
        public Snippet Snippet;
    }
}
