using MusixmatchClientLib.Auth;
using MusixmatchClientLib.Types;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace MusixmatchClientLib.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            MusixmatchToken token = new MusixmatchToken();
            MusixmatchClient client = new MusixmatchClient(token);

            // Example usage of request processor functions
            // The one below is used as a default function to process requests and requires cloudflare cookie handling
            CookieContainer container = new CookieContainer();
            client.SetRequestProcessor((string url, string method, string data) =>
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = method;
                request.CookieContainer = container;
                if (method == "POST")
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(data);
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = byteArray.Length;
                    using (Stream dataStream = request.GetRequestStream())
                        dataStream.Write(byteArray, 0, byteArray.Length);
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                container.Add(response.Cookies);
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            });

            // Search for a song named "Nasty * Nasty * Spell" by Camellia
            var tracks = client.SongSearch(new TrackSearchParameters
            {
                Artist = "Camellia",
                Title = "Nasty * Nasty * Spell",
                Album = "Blackmagik Blazing"
            });

            if (tracks.Count > 0)
            {
                // If the track count is greater than zero, get lyrics for the first result and display them
                var track = tracks[0];
                Console.WriteLine($"Lyrics for \"{track.ArtistName} - {track.TrackName}\":\n");
                Console.WriteLine(client.GetTrackLyrics(track.TrackId).LyricsBody);
            }
            else
            {
                Console.WriteLine("Track search failed: No results matching the query found.");
            }
        }
    }
}
