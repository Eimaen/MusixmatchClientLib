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
            MusixmatchToken token;
            if (!File.Exists("tempToken.txt"))
            {
                // Initialize a new token 
                token = new MusixmatchToken();

                // Save token to prevent cooldown by IP
                File.WriteAllText("tempToken.txt", token.Token);
            }
            else
                token = new MusixmatchToken(File.ReadAllText("tempToken.txt"));

            // Create a new client using our token
            MusixmatchClient client = new MusixmatchClient(token);

            // Example usage of request processor functions
            // The one below is used as a default function to process requests and requires cloudflare cookie handling
            CookieContainer container = new CookieContainer();
            client.SetRequestProcessor((string url, string method, string data) =>
            {
                // Console.WriteLine(url);
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

            // Authenticate using Musixmatch account credentials
            // token.AuthenticateMusixmatch("", "");

            // Get user score and profile
            var userProfile = client.GetUserScore();
            Console.WriteLine($"{userProfile.UserName} // {userProfile.Score} points // {userProfile.WeeklyScore} weekly // Moderator: {userProfile.Moderator}");

            // Important note: Only user-related requests need authentication, most "GET" requests you may make without auth.
            // Also do not create a new token every time you run your application. It makes a huge cooldown and theese tokens are never removed (I guess so).

            // Get my country's top rated users
            foreach (var user in client.GetUserWeeklyTop())
                Console.WriteLine($"{user.UserName} // {user.Score} points // {user.WeeklyScore} weekly // Moderator: {user.Moderator}");

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
