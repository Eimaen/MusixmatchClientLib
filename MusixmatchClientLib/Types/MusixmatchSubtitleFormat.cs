using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusixmatchClientLib.Types
{
    public class MusixmatchSubtitleFormat
    {
        [JsonProperty("text")]
        public string Text;

        [JsonProperty("time")]
        public LineTime Time;

        public class LineTime
        {
            [JsonProperty("total")]
            public double Total;

            [JsonProperty("minutes")]
            public int Minutes;

            [JsonProperty("seconds")]
            public int Seconds;

            [JsonProperty("hundredths")]
            public int Hundredths;
        }
    }
}
