using MusixmatchClientLib;
using MusixmatchClientLib.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MusixmatchClient client = new MusixmatchClient(new MusixmatchToken());
            var tracks = client.SongSearch("Tristam - Once Again"); // JSaB <3
            var firstTrack = tracks.First();
            var lyrics = client.GetSyncedLyrics(firstTrack.TrackId);
            Console.WriteLine(lyrics.SubtitleBody);
            Console.ReadKey();
        }
    }
}
