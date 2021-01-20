using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusixmatchClientLib.API.Model.Exceptions;
using MusixmatchClientLib.Auth;

namespace MusixmatchClientLib.Tests
{
    [TestClass]
    public class MusixmatchApiTests
    {
        public MusixmatchClient InitializeClient()
        {
            MusixmatchToken token = new MusixmatchToken();
            MusixmatchClient client = new MusixmatchClient(token);
            return client;
        }

        [TestMethod]
        public void GetTrackLyrics()
        {
            MusixmatchClient client = InitializeClient();
            try
            {
                client.GetTrackLyrics(182281390);
            }
            catch (MusixmatchRequestException ex)
            {
                Assert.Fail($"GetTrackLyrics() returned error code {(int)ex.StatusCode} ({ex.StatusCode.ToString()}).");
            }
        }

        [TestMethod]
        public void GetTrackById()
        {
            MusixmatchClient client = InitializeClient();
            try
            {
                client.GetTrackById(182281390);
            }
            catch (MusixmatchRequestException ex)
            {
                Assert.Fail($"GetTrackById() returned error code {(int)ex.StatusCode} ({ex.StatusCode.ToString()}).");
            }
        }
    }
}
