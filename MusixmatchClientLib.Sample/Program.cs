using MusixmatchClientLib.Auth;
using MusixmatchClientLib.Types;
using System;

namespace MusixmatchClientLib.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            MusixmatchToken token = new MusixmatchToken();
            MusixmatchClient client = new MusixmatchClient(token);
            var tracks = client.SongSearch(new TrackSearchParameters
            {
                Artist = "Camellia",
                Title = "Nasty * Nasty * Spell",
                Album = "Blackmagik Blazing"
            });
            if (tracks.Count > 0)
            {
                var track = tracks[0];
                Console.WriteLine($"Lyrics for \"{track.ArtistName} - {track.TrackName}\":\n");
                Console.WriteLine(client.GetTrackLyrics(track.TrackId).LyricsBody);
            }
            else
            {
                Console.WriteLine("Track search failed: No results matching the query found.");
            }
            Console.ReadKey();
        }
    }
}
