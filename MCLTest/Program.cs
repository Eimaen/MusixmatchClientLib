using MusixmatchClientLib;
using MusixmatchClientLib.Auth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var token = string.Empty;
            if (File.Exists("token.mxm"))
                token = File.ReadAllText("token.mxm");
            else
                File.WriteAllText("token.mxm", (token = new MusixmatchToken().Token));
            MusixmatchClient client = new MusixmatchClient(new MusixmatchToken(token));
            var tracks = client.SongSearch("Tristam - Once Again"); // JSaB <3
            var firstTrack = tracks.First();
            var lyrics = client.GetSyncedLyrics(firstTrack.TrackId, MusixmatchClient.SubtitleFormat.Musixmatch);
            Console.WriteLine(lyrics.SubtitleBody);
            Console.ReadKey();
        }
    }
}
