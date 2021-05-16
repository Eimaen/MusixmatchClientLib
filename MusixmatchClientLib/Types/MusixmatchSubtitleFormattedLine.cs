using Newtonsoft.Json;
using System;

namespace MusixmatchClientLib.Types
{
    public class MusixmatchSubtitleFormattedLine
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

            public static LineTime FromTimeSpan(TimeSpan time) => new LineTime { Total = time.TotalSeconds, Minutes = time.Minutes, Seconds = time.Seconds, Hundredths = time.Milliseconds / 10 };
        }

        public static MusixmatchSubtitleFormattedLine FromLyricsLine(LyricsLine line) => new MusixmatchSubtitleFormattedLine { Text = line.Text, Time = LineTime.FromTimeSpan(line.LyricsTime) };
    }
}
