using System;
using System.Collections.Generic;

namespace MusixmatchClientLib.Types
{
    public struct RichsyncLine
    {
        public TimeSpan TimeStart;
        public TimeSpan TimeEnd;
        public List<RichsyncCharacter> Characters;
        public string FullLine;
    }
}
