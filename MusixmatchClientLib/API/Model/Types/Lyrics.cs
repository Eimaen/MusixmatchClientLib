using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusixmatchClientLib.API.Model.Types
{
    public class LyricsUser
    {
        [JsonProperty("user")]
        public User User;
    }

    public class LyricsVerifiedBy
    {
        [JsonProperty("user")]
        public User User;
    }

    public class Lyrics
    {
        [JsonProperty("lyrics_id")]
        public int LyricsId;

        [JsonProperty("can_edit")]
        public int CanEdit;

        [JsonProperty("locked")]
        public int Locked;

        [JsonProperty("published_status")]
        public int PublishedStatus;

        [JsonProperty("action_requested")]
        public string ActionRequested;

        [JsonProperty("verified")]
        public int Verified;

        [JsonProperty("restricted")]
        public int Restricted;

        [JsonProperty("instrumental")]
        public int Instrumental;

        [JsonProperty("explicit")]
        public int Explicit;

        [JsonProperty("lyrics_body")]
        public string LyricsBody;

        [JsonProperty("lyrics_language")]
        public string LyricsLanguage;

        [JsonProperty("lyrics_language_description")]
        public string LyricsLanguageDescription;

        [JsonProperty("script_tracking_url")]
        public string ScriptTrackingUrl;

        [JsonProperty("pixel_tracking_url")]
        public string PixelTrackingUrl;

        [JsonProperty("html_tracking_url")]
        public string HtmlTrackingUrl;

        [JsonProperty("lyrics_copyright")]
        public string LyricsCopyright;

        [JsonProperty("writer_list")]
        public List<object> WriterList; // TODO: What is this?

        [JsonProperty("publisher_list")]
        public List<object> PublisherList; // TODO: What is this?

        [JsonProperty("backlink_url")]
        public string BacklinkUrl;

        [JsonProperty("updated_time")]
        public DateTime UpdatedTime;

        [JsonProperty("lyrics_user")]
        public LyricsUser LyricsUser;

        [JsonProperty("lyrics_verified_by")]
        public List<LyricsVerifiedBy> LyricsVerifiedBy;
    }
}
