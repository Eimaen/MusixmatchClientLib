
# MusixmatchClientLib
**Not partial Musixmatch client API documentation and its C# implementation**

[![CodeFactor](https://www.codefactor.io/repository/github/eimaen/musixmatchclientlib/badge?s=70546a2802f8bab8bf9f44f18eeff4177faa14e7)](https://www.codefactor.io/repository/github/eimaen/musixmatchclientlib)
[![DungeonCI](https://img.shields.io/static/v1?label=dungeonci&message=master&color=success)](https://www.google.com/search?q=Van+Darkholme)

----

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
- [x] Get missions | **IT**
- [ ] Get tasks | **W**

**Project**
- [ ] Write samples for all the functions | **H**
- [ ] Create wiki | **H**

## A *really* earnest request

All the information provided in this repository is **for educational purposes only**. 
**Please do not use this to write bots or other automation applications**.
Everything in this repo is **against Musixmatch ToS**.

## Usage
Using the library is quite simple. 
A complete list of samples is under development, until it's ready I'll leave some usage examples:

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

**Profile data update:**
```C#
client.UpdateUserProfileCountry("BY"); // Set country by ISO code
client.UpdateUserProfileFavouriteArtists(new List<int>() { client.ArtistSearch("Camellia").First().ArtistId }); // Set favourite artists
client.UpdateUserProfileFavouriteGenres(new List<int>() { client.GetMusicGenres().Where(genre => genre.MusicGenreName.ToLower() == "hardcore").First().MusicGenreId }); // Set favourite genres
```

### Exception handling
Currently this library supports only `MusixmatchRequestException`. It has a `StatusCode` property to understand the problem better.

### Warning
The docs are really outdated, this project is WIP and I refactor it literally on every commit. If you want to use it as a dependency, fork it first ;)
