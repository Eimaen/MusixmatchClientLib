using System;
using System.Collections.Generic;

namespace MusixmatchClientLib.Types
{
    public class Richsync
    {
        public List<RichsyncLine> Lines { get; set; }
        public List<RichsyncCharacter> Characters { get; set; }

        public Richsync(List<MusixmatchRichsyncFormat> mrf)
        {
            Lines = new List<RichsyncLine>();
            foreach (var line in mrf)
            {
                var linep = new RichsyncLine
                {
                    FullLine = line.FullLine,
                    TimeStart = TimeSpan.FromSeconds(line.TimeStart),
                    Characters = new List<RichsyncCharacter>()
                };
                foreach (var character in line.SingleCharOffsets)
                {
                    var characterp = new RichsyncCharacter
                    {
                        Character = character.Char[0],
                        TimeOffset = TimeSpan.FromSeconds(character.Offset),
                        TimeStart = TimeSpan.FromSeconds(character.Offset).Add(linep.TimeStart)
                    };
                    linep.Characters.Add(characterp);
                    Characters.Add(characterp);
                }
                Lines.Add(linep);
            }
        }
    }
}
