

# MusixmatchClientLib
**Complete Musixmatch client API C# implementation**

[![CodeFactor](https://www.codefactor.io/repository/github/eimaen/musixmatchclientlib/badge?s=70546a2802f8bab8bf9f44f18eeff4177faa14e7)](https://www.codefactor.io/repository/github/eimaen/musixmatchclientlib)
[![DungeonCI](https://img.shields.io/static/v1?label=dungeonci&message=master&color=success)](https://www.google.com/search?q=Van+Darkholme)

----

## Development suspension notice
Development of this project is suspended due to pending rewrite in Node.js, [libmxm](https://github.com/Eimaen/libmxm). When the project is finished, I'll keep both projects up to date.

## TODO
Definitions:
- **W**: Work in progress
- **H**: Hold
- **I**: Implemented
- **S**: Code-documented (summary)
- **T**: Tested
- **D**: Wiki-documented
- **R**: Research in progress (for undocumented)
- **U**: Ignored (useless)

**Core**
- [x] Custom request function | **I**
- [x] Async functionality

**Officially implemented API methods**
- [x] chart.artists.get | **IS**
- [x] chart.tracks.get | **IST**
- [x] track.search | **IST**
- [x] track.get | **IST**
- [x] track.lyrics.get | **IST**
- [x] track.snippet.get | **IST**
- [x] track.subtitle.get | **IST**
- [x] track.richsync.get | **IST**
- [x] track.lyrics.translation.get | **IS**
- [ ] track.subtitle.translation.get | **W**
- [x] music.genres.get | **IS**
- [ ] matcher.lyrics.get | **HU**
- [ ] matcher.track.get | **HU**
- [ ] matcher.subtitle.get | **HU**
- [x] artist.get | **IST**
- [x] artist.search | **IST**
- [x] artist.albums.get | **IST**
- [ ] artist.related.get | **H**
- [x] album.get | **IST**
- [x] album.tracks.get | **IST**

**Unofficial API methods**
- [x] track.subtitle.post | **IST**
- [x] track.lyrics.post | **IST**
- [ ] track.translation.post | **H**
- [x] crowd.user.feedback.get | **IS**
- [x] crowd.polls.tracks.search | **IS**
- [x] token.get | **IST**
- [x] credentials.post | **IST**
- [x] crowd.user.suggestion.lyrics.get | **IST**
- [x] crowd.user.suggestion.subtitles.get | **IST**
- [x] crowd.user.suggestion.translations.get | **IST**
- [x] crowd.user.suggestion.votes.get | **IST**
- [x] ai.question.post | **WRIST**
- [x] crowd.chart.users.get | **IST**
- [x] track.richsync.post | **IS**
- [x] crowd.score.get | **WIST**

**Missions API**
- [x] Get missions | **IST**
- [x] Get tasks | **WS**
- [x] Reserve tasks | **WS**
- [x] Release tasks | **WS**

**Project**
- [x] Write samples for all the functions | **IT**
- [ ] Create wiki | **H**

## A *really* earnest request

All the information provided in this repository is **for educational purposes only**. 
**Please do not use this to write bots or other automation applications**.
Everything in this repo is **against Musixmatch ToS**.

## Usage
Using the library is quite simple. 
A complete list of samples is under development, until it's ready I'll leave some usage examples:

Too boring? [Jump to example app!](https://github.com/Eimaen/MusixmatchClientLib/blob/dev/MusixmatchClientLib.Example/Program.cs)

### Tokens
`MusixmatchToken` class represents the Musixmatch client token, that is used in all the client requests. 
It can be requested from Musixmatch:
```C#
MusixmatchToken token = new MusixmatchToken();
```
Or it can be extracted from Musixmatch desktop application and used in the library:
```C#
MusixmatchToken token = new MusixmatchToken("MyToken");
```
A token could be created with a different API context, such as Musixmatch Community or Musixmatch iOS (more coming soon):
```C#
MusixmatchToken token = new MusixmatchToken("MyToken", API.Contexts.ApiContext.iOS);
```
Currently, you cannot create a token with a context other than `Desktop`.
Also, a token requested from Musixmatch has limited capabilities *(let's call it ***guest token***)* until you log in through the browser:
```C#
MusixmatchToken token = new MusixmatchToken();
Process.Start(token.GetAuthUrl()); // Open a browser with auth link
```

### Client class
To create a `MusixmatchClient` class you have to pass a `MusixmatchToken` to its constructor:
```C#
MusixmatchToken token = new MusixmatchToken("MyToken");
MusixmatchClient client = new MusixmatchClient(token);
```
You may also create a client without creating a token:
```C#
MusixmatchClient client = new MusixmatchClient("MyToken", API.Contexts.ApiContext.iOS);
```

### Other examples
**Song search:**
```C#
// Search by query
List<Track> tracks = client.SongSearch("Hommarju - Universe");

// Search by artist and track name
List<Track> tracks = client.SongSearch("Kobaryo", "Speed Complexxx");

// Search by the lyrics part
List<Track> tracks = client.SongSearchByLyrics("Watchin' you every night, to cast a small spell of fright"); 

// It is also possible to separate lines with '\n'
List<Track> tracks = client.SongSearchByLyrics("Just like you never ruined my heart\nLike you never said the words"); 

// Advanced search by parameters
List<Track> tracks = client.SongSearch(new TrackSearchParameters
{
    Album = "Heartache Debug", // Album name
    Artist = "t+pazolite", // Artist name
    Title = "Messed Up Gravity", // Track name
    LyricsQuery = "", // Search by the given part of lyrics
    Query = "t+pazolite - Messed Up Gravity", // Search query, covers all the search parameters above
    HasLyrics = false, // Only search for tracks with lyrics
    HasSubtitles = false, // Only search for tracks with synced lyrics
    Language = "", // Only search for tracks with lyrics in specified language
    Sort = TrackSearchParameters.SortStrategy.TrackRatingDesc // List sorting strategy 
});
```

**Get song lyrics:**
```C#
// Search for the track and get lyrics
int trackId = client.SongSearch("REDALiCE - Alive").First().TrackId;
Lyrics lyrics = client.GetTrackLyrics(trackId);
string lyricsBody = lyrics.Instrumental != 1 ? lyrics.LyricsBody : "This track is instrumental"; // lyrics.LyricsBody is null when the track is instrumental
```

**Submit song lyrics:**
```C#
// Submit track lyrics by id
int trackId = client.SongSearch("REDALiCE - Alive").First().TrackId;
client.SubmitTrackLyrics(trackId, "You make me feel alright\nYou make me feel alive...");
```

**Get track by id:**
```C#
// Get track by its Musixmatch id
Track track = client.GetTrackById(206481521);
string trackName = track.TrackName;
```

**Get track snippet:**
```C#
// Get track snippet (short line of lyrics to define the song)
int trackId = client.SongSearch("REDALiCE - Alive").First().TrackId;
string snippet = client.GetTrackSnippet(trackId);
```

**Submit synced song lyrics:**
```C#
// Submit track lyrics with time sync
Subtitles subtitles = new Subtitles();
subtitles.Lines.Add(new LyricsLine
{
    Text = "You make me feel alive",
    LyricsTime = TimeSpan.FromMilliseconds(1448)
});
int trackId = client.SongSearch("REDALiCE - Alive").First().TrackId;
client.SubmitTrackSubtitles(trackId, subtitles);
```

**Get synced song lyrics:**
```C#
// Search for the track and get synced lyrics
int trackId = client.SongSearch("REDALiCE - Alive").First().TrackId;
Subtitles subtitles = client.GetTrackSubtitles(trackId); // Throws ResourceNotFound if the track has no subtitles, check that first
List<LyricsLine> lines = subtitles.Lines;
string lineContent = lines.First().Text; // Line content
TimeSpan lineTime = lines.First().LyricsTime; // Line time (from the beginning of the song)
```

**Submit raw synced song lyrics:**
```C#
// Submit track lyrics with time sync (in Musixmatch format)
int trackId = client.SongSearch("REDALiCE - Alive").First().TrackId;
client.SubmitTrackSubtitlesRaw(trackId, "[{\"text\":\"You make me feel alive\",\"time\":{\"total\":17.33,\"minutes\":0,\"seconds\":17,\"hundredths\":33}}]");
```

**Get raw synced song lyrics:**
```C#
// Get raw track lyrics with time sync
int trackId = client.SongSearch("REDALiCE - Alive").First().TrackId;
string mxm = client.GetTrackSubtitlesRaw(trackId, MusixmatchClient.SubtitleFormat.Musixmatch);
```

**Submit track mood:**
```C#
int trackId = client.SongSearch("Camellia - AREA 52").First().TrackId;
client.SubmitTrackMood(trackId, 100 /* energy */, 69 /* mood */);
```

**Get lyrics translation:**
```C#
int trackId = client.SongSearch("Camellia - Nasty * Nasty * Spell").First().TrackId;
string translated = client.GetLyricsTranslation(trackId, "ru");
```

**Get top weekly contributors:**
```C#
List<User> coolGuysFromBelarus = client.GetUserWeeklyTop("BY");
List<User> theCoolestGuys = client.GetUserWeeklyTop();
```

**Get spotify token (LOL):**
```C#
string spotifyToken = client.GetSpotifyOauthToken().OauthRefreshtokenReply.AccessToken;
string refreshToken = client.GetSpotifyOauthToken().OauthRefreshtokenReply.RefreshToken;
string scope = client.GetSpotifyOauthToken().OauthRefreshtokenReply.Scope;
```

**Get your statistics:**
```C#
User you = client.GetUserScore();
int score = you.Score; // Cannot implicitly convert type 'long' to 'int' (joke, it works)
```

**Your data:**
```C#
var user = client.GetUserInfo();
string yourAge = user.UserData.Profile.AgeRange; // Not for everyone
```

**Profile data update:**
```C#
client.UpdateUserProfileCountry("BY"); // Set country by ISO code
client.UpdateUserProfileFavouriteArtists(new List<int>() { client.ArtistSearch("Camellia").First().ArtistId }); // Set favourite artists
client.UpdateUserProfileFavouriteGenres(new List<int>() { client.GetMusicGenres().Where(genre => genre.MusicGenreName.ToLower() == "hardcore").First().MusicGenreId }); // Set favourite genres
```
### Missions
The cool stuff is, now the library supports [musixmatch missions](https://curators.musixmatch.com). The implementation is pretty raw tho, so feel free to contact me and give feedback via issues page or directly either via [Discord](https://discordapp.com/users/394601924881809408) or [Telegram](https://t.me/eimaen). Here are some quick examples on how to use the API: 

**Get mission tracks:**
```C#
MissionManager missions = client.RequestMissionManager();
List<Mission> missionList = missions.GetMissions();
Mission mission = missionList.Find(m => m.Title == "The Jukebox");
foreach (var track in missions.GetMissionTracks(mission.Id, "en", "en"))
    Console.WriteLine($"{track.Artist} - {track.Title}");
```
This prints out the entire mission list to your console window.

**Reserve a mission task:**
```C#
// Imagine spamming this one :clown:
MissionManager missions = client.RequestMissionManager();
List<Mission> missionList = missions.GetMissions();
Mission mission = missionList.Find(m => m.Title == "The Jukebox");
MissionTrack missionTrack = missions.GetMissionTracks(mission.Id, "en", "en").Find(t => t.Artist == "Cepheid" && t.Title == "Catch Wind");
missions.ReserveTask(mission.Id, missionTrack.Id); // this reserves a Catch Wind task (it doesn't exist, example), so it appears on your "In Progress" list
```

### Async development
Thanks to [@AlexanderDotH](https://github.com/AlexanderDotH), library now supports async calls. The usage hasn't changed.

### Exception handling
Currently this library supports only `MusixmatchRequestException`. It has a `StatusCode` property to understand the problem better.
By default, `MusixmatchClient` would throw these if it runs into a problem during request. To ignore some problems, you could set `AssertOnRequestException` parameter to `false`.
