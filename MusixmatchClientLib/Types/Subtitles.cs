using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusixmatchClientLib.Types
{
    public class Subtitles
    {
        public List<LyricsLine> Lines { get; set; }

        /// <summary>
        /// Create an empty <see cref="Subtitles"/>.
        /// </summary>
        public Subtitles() { }

        /// <summary>
        /// Create <see cref="Subtitles"/> object from musixmatch serialized subtitle string.
        /// </summary>
        /// <param name="mxmss">Musixmatch serialized subtitles</param>
        public Subtitles(string mxmss) => LoadFromMusixmatchSubtitleLines(JsonConvert.DeserializeObject<List<MusixmatchSubtitleFormattedLine>>(mxmss));

        /// <summary>
        /// Create <see cref="Subtitles"/> object from musixmatch serialized subtitles.
        /// </summary>
        /// <param name="mxmss">Musixmatch serialized subtitles</param>
        public Subtitles(List<MusixmatchSubtitleFormattedLine> lines) => LoadFromMusixmatchSubtitleLines(lines);

        private void LoadFromMusixmatchSubtitleLines(List<MusixmatchSubtitleFormattedLine> msf)
        {
            Lines = new List<LyricsLine>();
            foreach (var line in msf)
                Lines.Add(LyricsLine.FromMusixmatchSubtitle(line));
        }

        private List<MusixmatchSubtitleFormattedLine> GetMusixmatchSubtitles()
        {
            List<MusixmatchSubtitleFormattedLine> lines = new List<MusixmatchSubtitleFormattedLine>();
            foreach (var line in Lines)
                lines.Add(MusixmatchSubtitleFormattedLine.FromLyricsLine(line));
            return lines;
        }

        public override string ToString() => JsonConvert.SerializeObject(GetMusixmatchSubtitles());
    }
}
