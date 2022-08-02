using System;

namespace MusixmatchClientLib.Types
{
    public class LyricsLine
    {
        public TimeSpan LyricsTime { get; set; }
        public string Text { get; set; }
        public MusixmatchSubtitleFormattedLine GetMusixmatchSubtitle() => MusixmatchSubtitleFormattedLine.FromLyricsLine(this);
        public static LyricsLine FromMusixmatchSubtitle(MusixmatchSubtitleFormattedLine msfl) => new LyricsLine { LyricsTime = TimeSpan.FromSeconds(msfl.Time.Total), Text = msfl.Text };
    }
}
