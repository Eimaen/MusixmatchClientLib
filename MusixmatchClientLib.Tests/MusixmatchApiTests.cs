using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusixmatchClientLib.API.Model.Exceptions;
using MusixmatchClientLib.Auth;
using System.Threading;

namespace MusixmatchClientLib.Tests
{
    [TestClass]
    public class MusixmatchApiTests
    {
        private static MusixmatchClient client;

        [TestMethod("Initialize a Musixmatch client")]
        public MusixmatchClient InitializeClient()
        {
            if (client == null)
            {
                MusixmatchToken token = new MusixmatchToken();
                client = new MusixmatchClient(token);
            }
            return client;
        }

        [TestMethod("Track lyrics by Id")]
        public void GetTrackLyrics()
        {
            Thread.Sleep(1000);
            MusixmatchClient client = InitializeClient();
            try
            {
                var lyrics = client.GetTrackLyrics(182281390);
                Assert.IsNotNull(lyrics, "GetTrackLyrics() returned null.");
            }
            catch (MusixmatchRequestException ex)
            {
                Assert.Fail($"GetTrackLyrics() returned error code {(int)ex.StatusCode} ({ex.StatusCode.ToString()}).");
            }
        }

        [TestMethod("Track info by Id")]
        public void GetTrackById()
        {
            Thread.Sleep(1000);
            MusixmatchClient client = InitializeClient();
            try
            {
                var track = client.GetTrackById(182281390);
                Assert.IsNotNull(track, "GetTrackById() returned null.");
            }
            catch (MusixmatchRequestException ex)
            {
                Assert.Fail($"GetTrackById() returned error code {(int)ex.StatusCode} ({ex.StatusCode.ToString()}).");
            }
        }
        
        [TestMethod("Track search by query")]
        public void SongSearch()
        {
            Thread.Sleep(1000);
            MusixmatchClient client = InitializeClient();
            try
            {
                var tracks = client.SongSearch("Getty - FLVSH OUT");
                Assert.IsNotNull(tracks, "SongSearch() returned null.");
            }
            catch (MusixmatchRequestException ex)
            {
                Assert.Fail($"SongSearch() returned error code {(int)ex.StatusCode} ({ex.StatusCode.ToString()}).");
            }
        }

        [TestMethod("Track search by lyrics")]
        public void SongSearchByLyrics()
        {
            Thread.Sleep(1000);
            MusixmatchClient client = InitializeClient();
            try
            {
                var tracks = client.SongSearchByLyrics("So I'm tired of all the pain, all the misery inside");
                Assert.IsNotNull(tracks, "SongSearchByLyrics() returned null.");
            }
            catch (MusixmatchRequestException ex)
            {
                Assert.Fail($"SongSearchByLyrics() returned error code {(int)ex.StatusCode} ({ex.StatusCode.ToString()}).");
            }
        }
    }
}
