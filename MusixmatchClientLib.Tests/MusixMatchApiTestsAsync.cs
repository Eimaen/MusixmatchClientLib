using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MusixmatchClientLib.API.Contexts;
using MusixmatchClientLib.API.Model.Exceptions;
using MusixmatchClientLib.Auth;

namespace MusixmatchClientLib.Tests
{
    [TestClass]
    public class MusixmatchApiTestsAsync
    {
        private static MusixmatchClient client;

        [TestMethod("Initialize a Musixmatch client async")]
        public async Task<MusixmatchClient> InitializeClientAsync()
        {
            if (client == null)
            {
                string t = await new MusixmatchToken("", ApiContext.Desktop).IssueNewTokenAsync();
                MusixmatchToken token = new MusixmatchToken(t, ApiContext.Desktop);
                client = new MusixmatchClient(token);
            }
            return client;
        }

        [TestMethod("Track lyrics by Id async")]
        public async Task GetTrackLyricsAsync()
        {
            Thread.Sleep(1000);
            MusixmatchClient client = await InitializeClientAsync();
            try
            {
                var lyrics = await client.GetTrackLyricsAsync(182281390);
                Assert.IsNotNull(lyrics, "GetTrackLyricsAsync() returned null.");
            }
            catch (MusixmatchRequestException ex)
            {
                Assert.Fail($"GetTrackLyricsAsync() returned error code {(int)ex.StatusCode} ({ex.StatusCode.ToString()}).");
            }
        }

        [TestMethod("Track info by Id async")]
        public async Task GetTrackByIdAsync()
        {
            Thread.Sleep(1000);
            MusixmatchClient client = await InitializeClientAsync();
            try
            {
                var track = await client.GetTrackByIdAsync(182281390);
                Assert.IsNotNull(track, "GetTrackByIdAsync() returned null.");
            }
            catch (MusixmatchRequestException ex)
            {
                Assert.Fail($"GetTrackByIdAsync() returned error code {(int)ex.StatusCode} ({ex.StatusCode.ToString()}).");
            }
        }

        [TestMethod("Track search by query async")]
        public async Task SongSearchAsync()
        {
            Thread.Sleep(1000);
            MusixmatchClient client = await InitializeClientAsync();
            try
            {
                var tracks = await client.SongSearchAsync("Getty - FLVSH OUT");
                Assert.IsNotNull(tracks, "SongSearchAsync() returned null.");
            }
            catch (MusixmatchRequestException ex)
            {
                Assert.Fail($"SongSearchAsync() returned error code {(int)ex.StatusCode} ({ex.StatusCode.ToString()}).");
            }
        }

        [TestMethod("Track search by lyrics async")]
        public async Task SongSearchByLyrics()
        {
            Thread.Sleep(1000);
            MusixmatchClient client = await InitializeClientAsync();
            try
            {
                var tracks = await client.SongSearchByLyricsAsync("So I'm tired of all the pain, all the misery inside");
                Assert.IsNotNull(tracks, "SongSearchByLyricsAsync() returned null.");
            }
            catch (MusixmatchRequestException ex)
            {
                Assert.Fail($"SongSearchByLyricsAsync() returned error code {(int)ex.StatusCode} ({ex.StatusCode.ToString()}).");
            }
        }
    }
}
