using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusixmatchClientLib.API.Model
{
    class TokenGet : MusixmatchApiResponse
    {
        [JsonProperty("user_token")]
        public string UserToken;

        [JsonProperty("app_config")]
        public AppConfig ApplicationConfig;

        [JsonProperty("location")]
        public Location LocationData;

        public class Missions
        {
            [JsonProperty("enabled")]
            public bool Enabled;

            [JsonProperty("community")]
            public List<string> Community;
        }

        public class Tracking
        {
            [JsonProperty("context")]
            public string Context;

            [JsonProperty("delay")]
            public int Delay;

            [JsonProperty("track_cache_ttl")]
            public int TrackCacheTtl;
        }

        public class TrackingList
        {
            [JsonProperty("tracking")]
            public Tracking Tracking;
        }

        public class OauthWebSignin
        {
            [JsonProperty("enabled")]
            public bool Enabled;

            [JsonProperty("user_prefix")]
            public string UserPrefix;
        }

        public class Service
        {
            [JsonProperty("name")]
            public string Name;

            [JsonProperty("display_name")]
            public string DisplayName;

            [JsonProperty("type")]
            public string Type;

            [JsonProperty("oauth_api")]
            public bool OauthApi;

            [JsonProperty("oauth_web_signin")]
            public OauthWebSignin OauthWebSignin;

            [JsonProperty("streaming")]
            public bool Streaming;

            [JsonProperty("playlist")]
            public bool Playlist;

            [JsonProperty("locker")]
            public bool Locker;

            [JsonProperty("deeplink")]
            public bool Deeplink;
        }

        public class ServiceList
        {
            [JsonProperty("service")]
            public Service Service;
        }

        public class Piggyback
        {
            [JsonProperty("server_weight")]
            public int ServerWeight;
        }

        public class EventMap
        {
            [JsonProperty("regex")]
            public string Regex;

            [JsonProperty("enabled")]
            public bool Enabled;

            [JsonProperty("piggyback")]
            public Piggyback Piggyback;
        }

        public class AppConfig
        {
            [JsonProperty("trial")]
            public bool Trial;

            [JsonProperty("mobilePopOverMaximum")]
            public int MobilePopOverMaximum;

            [JsonProperty("mobilePopOverMinTimes")]
            public int MobilePopOverMinTimes;

            [JsonProperty("mobilePopOverMaxTimes")]
            public int MobilePopOverMaxTimes;

            [JsonProperty("isRoviCopyEnabled")]
            public bool IsRoviCopyEnabled;

            [JsonProperty("isGettyCopyEnabled")]
            public bool IsGettyCopyEnabled;

            [JsonProperty("searchMaxResults")]
            public int SearchMaxResults;

            [JsonProperty("fbShareUrlSpotify")]
            public bool FbShareUrlSpotify;

            [JsonProperty("twShareUrlSpotify")]
            public bool TwShareUrlSpotify;

            [JsonProperty("fbPostTimeline")]
            public bool FbPostTimeline;

            [JsonProperty("fbOpenGraph")]
            public bool FbOpenGraph;

            [JsonProperty("subtitlesMaxDeviation")]
            public int SubtitlesMaxDeviation;

            [JsonProperty("localeDefaultLang")]
            public string LocaleDefaultLang;

            [JsonProperty("missionEnable")]
            public bool MissionEnable;

            [JsonProperty("content_team")]
            public bool ContentTeam;

            [JsonProperty("missions")]
            public Missions Missions;

            [JsonProperty("appstore_products")]
            public List<object> AppstoreProducts;

            [JsonProperty("tracking_list")]
            public List<TrackingList> TrackingList;

            [JsonProperty("spotifyCountries")]
            public List<string> SpotifyCountries;

            [JsonProperty("service_list")]
            public List<ServiceList> ServiceList;

            [JsonProperty("show_amazon_music")]
            public bool ShowAmazonMusic;

            [JsonProperty("isSentryEnabled")]
            public bool IsSentryEnabled;

            [JsonProperty("languages")]
            public List<string> Languages;

            [JsonProperty("last_updated")]
            public DateTime LastUpdated;

            [JsonProperty("cluster")]
            public string Cluster;

            [JsonProperty("event_map")]
            public List<EventMap> EventMap;
        }

        public class Location
        {
            [JsonProperty("GEOIP_CITY_COUNTRY_CODE")]
            public string GEOIPCITYCOUNTRYCODE;

            [JsonProperty("GEOIP_CITY_COUNTRY_CODE3")]
            public string GEOIPCITYCOUNTRYCODE3;

            [JsonProperty("GEOIP_CITY_COUNTRY_NAME")]
            public string GEOIPCITYCOUNTRYNAME;

            [JsonProperty("GEOIP_CITY")]
            public string GEOIPCITY;

            [JsonProperty("GEOIP_CITY_CONTINENT_CODE")]
            public string GEOIPCITYCONTINENTCODE;

            [JsonProperty("GEOIP_LATITUDE")]
            public double GEOIPLATITUDE;

            [JsonProperty("GEOIP_LONGITUDE")]
            public double GEOIPLONGITUDE;

            [JsonProperty("GEOIP_AS_ORG")]
            public string GEOIPASORG;

            [JsonProperty("GEOIP_ORG")]
            public string GEOIPORG;

            [JsonProperty("GEOIP_ISP")]
            public string GEOIPISP;

            [JsonProperty("GEOIP_NET_NAME")]
            public string GEOIPNETNAME;

            [JsonProperty("BADIP_TAGS")]
            public List<object> BADIPTAGS;
        }
    }
}
