# MusixmatchClientLib
**Partial Musixmatch client API documentation and its C# implementation**

[![CodeFactor](https://www.codefactor.io/repository/github/eimaen/musixmatchclientlib/badge?s=70546a2802f8bab8bf9f44f18eeff4177faa14e7)](https://www.codefactor.io/repository/github/eimaen/musixmatchclientlib)
[![CircleCI](https://circleci.com/gh/Eimaen/MusixmatchClientLib.svg?style=shield&circle-token=161ae5a56e3c9352df1ca627e1b8c09e0d63e32f)](https://app.circleci.com/pipelines/github/Eimaen/MusixmatchClientLib)
[![DungeonCI](https://img.shields.io/static/v1?label=dungeonci&message=slave&color=critical)](https://www.google.com/search?q=Van+Darkholme)

----

**MusixmatchClientLib** is a .NET library designed to interact with Musixmatch client API easily. This project also contains an information about Musixmatch's hidden endpoints to work with. 

## TODO
Definitions:
- **W**: Work in progress
- **H**: Hold
- **I**: Implemented
- **S**: Code-documented (summary)
- **T**: Tested
- **D**: Wiki-documented
- **R**: Research in progress (for undocumented)

**Officially implemented API methods**
- [ ] chart.artists.get | **H**
- [x] chart.tracks.get | **IS**
- [x] track.search | **IST**
- [x] track.get | **IST**
- [x] track.lyrics.get | **IST**
- [x] track.snippet.get | **IST**
- [x] track.subtitle.get | **IST**
- [ ] track.richsync.get | **W**
- [x] track.lyrics.translation.get | **IS**
- [ ] track.subtitle.translation.get | **W**
- [ ] music.genres.get | **H**
- [ ] matcher.lyrics.get | **H**
- [ ] matcher.track.get | **H**
- [ ] matcher.subtitle.get | **H**
- [ ] artist.get | **H**
- [ ] artist.search | **H**
- [ ] artist.albums.get | **H**
- [ ] artist.related.get | **H**
- [ ] album.get | **H**
- [ ] album.tracks.get | **H**

**Unofficial API methods**
- [x] track.subtitle.post | **IST**
- [x] track.lyrics.post | **IST**
- [x] crowd.user.feedback.get | **IS**
- [x] crowd.polls.tracks.search | **I**
- [x] token.get | **IST**
- [ ] credentials.post | **H**

**Missions API**
- [x] Get missions | **I**
- [ ] Get tasks | **H**

## A *really* earnest request *(call it a disclaimer)*
All the information provided in this repository is **for educational purposes only**. 
**Please do not use this to write bots or other automation applications.** 
This platform is good for it is supported by people. 
There is no point in the race for points, they will not give you anything. 
Another thing is the database of lyrics, which has been replenished every day since the beginning of Musixmatch's existence, and continues to grow to this day. 
It is open to absolutely everyone, free of charge.

*I apologize for such a long story.*
In any case, you can get points for free without destroying the database of lyrics. 
I do not recommend doing this, because it is against the rules for using Musixmatch, 
however, if you don’t care what the paragraph above says, at least make sure you don’t do the following:
- Don't write bots to translate lyrics *(machine-translated texts are just awful)*
- Don't write bots to recognize lyrics *(STT is shit when used with songs)*
- Don't write bots to sync lyrics *(as above, STT is a bad idea)*
- Don't write bots to check lyrics *(they have to be checked by human)*
- Don't write bots to spam lyrics *(oh my god why)*
- Don't write bots to spam translations *(same as above)*
- **Don't write bots at all**

*There is a funny fact that the MusixmatchClientLib's functionality does not allow creating bots yet.*

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
List<track> tracks = client.SongSearch("Hommarju - Universe");

// Search by artist and track name
List<track> tracks = client.SongSearch("Kobaryo", "Speed Complexxx");

// Search by the lyrics part
List<track> tracks = client.SongSearchByLyrics("Watchin' you every night, to cast a small spell of fright"); 

// It is also possible to separate lines with '\n'
List<track> tracks = client.SongSearchByLyrics("Just like you never ruined my heart\nLike you never said the words"); 

// Advanced search by parameters
List<track> tracks = client.SongSearch(new TrackSearchParameters
{
    Album = "Heartache Debug", // Album name
    Artist = "t+pazolite", // Artist name
    Title = "Messed Up Gravity", // Track name
    LyricsQuery = "", // Search by the given part of lyrics
    Query = "t+pazolite - Messed Up Gravity", // Search query, covers all the search parameters above
    HasLyrics = false, // Only search for tracks with lyrics
    HasSubtitles = false, // Only search for tracks with synced lyrics
    Language = "", // Only search for tracks with lyrics in specified language
    PageNumber = 1, // Pagination parameter. Represents page number.
    PageSize = 1, // Pagination parameter. Represents page size. Recommended to set to 1 for one-track search.
    Sort = TrackSearchParameters.SortStrategy.TrackRatingDesc // List sorting strategy 
});
```

**Song lyrics:**
```C#
// Search for the track and get lyrics
int trackId = client.SongSearch("REDALiCE - Alive").First().TrackId;
Lyrics lyrics = client.GetTrackLyrics(trackId);
string lyricsBody = lyrics.Instrumental != 1 ? lyrics.LyricsBody : "This track is instrumental"; // lyrics.LyricsBody is null when the track is instrumental
```

**Song lyrics (synced):**
```C#
// Search for the track and get synced lyrics
int trackId = client.SongSearch("REDALiCE - Alive").First().TrackId;
Subtitle lyrics = client.GetSyncedLyrics(trackId, MusixmatchClient.SubtitleFormat.Lrc); // Throws ResourceNotFound if the track has no subtitles, check that first
string subtitleBody = lyrics.SubtitleBody;
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

**Submit track synced lyrics:**
```C#
// Submit track lyrics with time sync (in Musixmatch format)
int trackId = client.SongSearch("REDALiCE - Alive").First().TrackId;
client.SubmitTrackLyricsSynced(trackId, "[{\"text\":\"You make me feel alive\",\"time\":{\"total\":17.33,\"minutes\":0,\"seconds\":17,\"hundredths\":33}}]");
```

### Exception handling
Exceptions are WIP too, so right now you have to handle default exceptions with messages.
Later you will find more exceptions like `MusixmatchRequestException`

## How to help
Just star the project so as to understand that it is not useless and I could continue developing it *(and become a little happier ^_^)*
