using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusixmatchClientLib.Types
{
    public class MusixmatchRichsyncFormat
    {
        [JsonProperty("ts")]
        public double TimeStart;

        [JsonProperty("te")]
        public double TimeEnd;

        [JsonProperty("l")]
        public List<SingleCharOffset> SingleCharOffsets;

        [JsonProperty("x")]
        public string FullLine;

        public class SingleCharOffset
        {
            [JsonProperty("c")]
            public string Char;

            [JsonProperty("o")]
            public double Offset; // From TimeStart
        }
    }
}
