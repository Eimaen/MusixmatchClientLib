using MusixmatchClientLib;
using MusixmatchClientLib.Auth;
using MusixmatchClientLib.Types;
using static MusixmatchClientLib.MusixmatchClient;

MusixmatchToken token;
if (File.Exists("token.txt"))
{
    token = new MusixmatchToken(File.ReadAllText("token.txt"));
    Console.WriteLine($"Token loaded: {token}\n");
}
else
{
    token = new MusixmatchToken(); // Desktop context is set by default
    File.WriteAllText("token.txt", token.ToString());
    Console.WriteLine($"Token generated (please save & reuse it in your apps): {token}\n");
}

var client = new MusixmatchClient(token);

Console.WriteLine($"If you want to login to your Musixmatch account and update/upload lyrics, please use this link:\n{token.GetAuthUrl()}\nWARNING: It will and should display an error, it will log you in anyway.\nPress ENTER to proceed with login or to try it without logging in.\n");
while (Console.ReadKey().Key != ConsoleKey.Enter) { Thread.Sleep(1000); }
Thread.Sleep(1000);

try
{
    var user = client.GetUserScore();
    Console.WriteLine($"Welcome to MusixmatchClientLib, {user.UserName}. You've got {user.Score} points (+{user.WeeklyScore} this week), not bad.\nBy the way, I see that you {(user.Moderator ? "are a curator! Good job, but remember that this library is definitely AGAINST TOS and MIGHT GET YOUR ACCOUNT TERMINATED!" : "aren't a curator. Contribute more and you'll be invited to the curators team!")}\nWish you happy coding using this library <3\n");
}
catch
{
    Console.WriteLine("You haven't logged in.\n");
}

var songs = client.SongSearch(new TrackSearchParameters
{
    Query = "Cepheid - Catch Wind"
}, new PaginationParameters
{
    Page = 1,
    PageSize = 5
});

Console.WriteLine($"Found {songs.Count} songs (max page size: 5)");
foreach (var song in songs)
    Console.WriteLine($"[{song.TrackId}] {song.ArtistName} - {song.TrackName} (on {song.AlbumName})");

Console.WriteLine($"\nFirst track id: {songs.First().TrackId}\n");

var lyrics = client.GetTrackLyrics(songs.First().TrackId);
Console.WriteLine($"Lyrics:\n{lyrics.LyricsBody}\n");

var subtitlesLrc = client.GetTrackSubtitlesRaw(songs.First().TrackId, SubtitleFormat.Lrc);
Console.WriteLine($"LRC subtitles:\n{subtitlesLrc.SubtitleBody}\n");