using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MusixmatchClientLib.Types
{
    public class Richsync
    {
        public List<RichsyncLine> Lines { get; set; }
        public List<RichsyncCharacter> Characters { get; set; }

        /// <summary>
        /// Create <see cref="Richsync"/> object from musixmatch richsync serialized string.
        /// </summary>
        /// <param name="mrf">Musixmatch serialized richsync</param>
        public Richsync(string mxmrs) => LoadFromMusixmatchRichsyncLines(JsonConvert.DeserializeObject<List<MusixmatchRichsyncFormattedLine>>(mxmrs));

        /// <summary>
        /// Create <see cref="Richsync"/> object from musixmatch formatted line list.
        /// </summary>
        /// <param name="mrf">List of musixmatch formatted lines</param>
        public Richsync(List<MusixmatchRichsyncFormattedLine> mrf) => LoadFromMusixmatchRichsyncLines(mrf);

        private void LoadFromMusixmatchRichsyncLines(List<MusixmatchRichsyncFormattedLine> mrf)
        {
            Lines = new List<RichsyncLine>();
            Characters = new List<RichsyncCharacter>();
            foreach (var line in mrf)
            {
                var linep = new RichsyncLine
                {
                    FullLine = line.FullLine,
                    TimeStart = TimeSpan.FromSeconds(line.TimeStart),
                    TimeEnd = TimeSpan.FromSeconds(line.TimeEnd),
                    Characters = new List<RichsyncCharacter>()
                };
                foreach (var character in line.SingleCharOffsets)
                {
                    var characterp = new RichsyncCharacter
                    {
                        Character = character.Char,
                        TimeOffset = TimeSpan.FromSeconds(character.Offset),
                        TimeStart = TimeSpan.FromSeconds(character.Offset).Add(linep.TimeStart)
                    };
                    linep.Characters.Add(characterp);
                    Characters.Add(characterp);
                }
                Lines.Add(linep);
            }
        }

        /// <summary>
        /// Convert Richsync to mxm-richsync.
        /// </summary>
        /// <returns>Mxm-richsync represented as a list of <see cref="MusixmatchRichsyncFormattedLine"/></returns>
        public List<MusixmatchRichsyncFormattedLine> ToMusixmatchRichsync()
        {
            List<MusixmatchRichsyncFormattedLine> mxmEncoded = new List<MusixmatchRichsyncFormattedLine>();

            foreach (var line in Lines)
            {
                List<MusixmatchRichsyncFormattedLine.SingleCharOffset> charOffsets = new List<MusixmatchRichsyncFormattedLine.SingleCharOffset>();
                foreach (var character in line.Characters)
                    charOffsets.Add(new MusixmatchRichsyncFormattedLine.SingleCharOffset
                    {
                        Char = character.Character,
                        Offset = character.TimeOffset.TotalSeconds
                    });

                MusixmatchRichsyncFormattedLine mxmLine = new MusixmatchRichsyncFormattedLine
                {
                    FullLine = line.FullLine,
                    TimeStart = line.TimeStart.TotalSeconds,
                    TimeEnd = line.TimeEnd.TotalSeconds,
                    SingleCharOffsets = charOffsets
                };

                mxmEncoded.Add(mxmLine);
            }

            return mxmEncoded;
        }

        /// <summary>
        /// Convert Richsync to serialized mxm-richsync file.
        /// </summary>
        /// <returns>Serialized mxm-richsync</returns>
        public override string ToString()
        {
            List<MusixmatchRichsyncFormattedLine> mxmEncoded = ToMusixmatchRichsync();
            return JsonConvert.SerializeObject(mxmEncoded);
        }
    }
}
