using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MusixmatchClientLib.API.Model.Requests
{
    public class AuthenticationGet : MusixmatchApiResponse
    {
        [JsonProperty("tokens")]
        public Tokens tokens { get; set; }

        [JsonProperty("credential")]
        public Credential credential { get; set; }

        [JsonProperty("auth")]
        public Auth auth { get; set; }
    }
    
    public class Account
    {
        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("email_redirect_url")]
        public string email_redirect_url { get; set; }

        [JsonProperty("extra_params")]
        public ExtraParams extra_params { get; set; }

        [JsonProperty("first_name")]
        public string first_name { get; set; }

        [JsonProperty("last_name")]
        public string last_name { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("registration_country")]
        public string registration_country { get; set; }

        [JsonProperty("user_type")]
        public string user_type { get; set; }

        [JsonProperty("user_id")]
        public string user_id { get; set; }

        [JsonProperty("user_picture")]
        public string user_picture { get; set; }

        [JsonProperty("user_nickname")]
        public string user_nickname { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("verified")]
        public bool verified { get; set; }

        [JsonProperty("user_last_location")]
        public UserLastLocation user_last_location { get; set; }

        [JsonProperty("user_creation_date")]
        public DateTime user_creation_date { get; set; }

        [JsonProperty("last_updated")]
        public DateTime last_updated { get; set; }

        [JsonProperty("namespace")]
        public string @namespace { get; set; }

        [JsonProperty("userdata_id")]
        public string userdata_id { get; set; }

        [JsonProperty("has_profile_photo")]
        public bool has_profile_photo { get; set; }

        [JsonProperty("country")]
        public string country { get; set; }
    }

    public class Auth
    {
        [JsonProperty("user_id")]
        public string user_id { get; set; }

        [JsonProperty("authorizations")]
        public Authorizations authorizations { get; set; }
    }

    public class Authorizations
    {
        [JsonProperty("active")]
        public bool active { get; set; }

        [JsonProperty("private")]
        public bool @private { get; set; }

        [JsonProperty("safe")]
        public string safe { get; set; }

        [JsonProperty("user_id")]
        public string user_id { get; set; }

        [JsonProperty("last_updated")]
        public DateTime last_updated { get; set; }

        [JsonProperty("namespace")]
        public string @namespace { get; set; }

        [JsonProperty("userdata_id")]
        public string userdata_id { get; set; }

        [JsonProperty("referral_list")]
        public List<ReferralList> referral_list { get; set; }
    }

    public class Credential
    {
        [JsonProperty("action")]
        public string action { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("account")]
        public Account account { get; set; }
    }

    public class ExtraParams
    {
        [JsonProperty("mode")]
        public string mode { get; set; }

        [JsonProperty("redirect_url")]
        public string redirect_url { get; set; }
    }

    public class ReferralList
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("active")]
        public bool active { get; set; }

        [JsonProperty("code")]
        public string code { get; set; }

        [JsonProperty("invitation")]
        public string invitation { get; set; }
    }

    public class Tokens
    {
        [JsonProperty("musixmatch-artists-v2.0")]
        public string musixmatchartistsv20 { get; set; }

        [JsonProperty("mxm-backoffice-v1.0")]
        public string mxmbackofficev10 { get; set; }

        [JsonProperty("musixmatch-podcasts-v2.0")]
        public string musixmatchpodcastsv20 { get; set; }

        [JsonProperty("musixmatch-podcasts-v2.0-pp")]
        public string musixmatchpodcastsv20pp { get; set; }

        [JsonProperty("mxm-pro-web-v1.0")]
        public string mxmprowebv10 { get; set; }

        [JsonProperty("mxm-com-v1.0")]
        public string mxmcomv10 { get; set; }

        [JsonProperty("musixmatch-publishers-v2.0")]
        public string musixmatchpublishersv20 { get; set; }

        [JsonProperty("web-desktop-app-v1.0")]
        public string webdesktopappv10 { get; set; }

        [JsonProperty("community-app-v1.0")]
        public string communityappv10 { get; set; }

        [JsonProperty("mxm-proxy-manager-v1.0")]
        public string mxmproxymanagerv10 { get; set; }

        [JsonProperty("mxm-studio-v1.0")]
        public string mxmstudiov10 { get; set; }

        [JsonProperty("mxm-account-v1.0")]
        public string mxmaccountv10 { get; set; }
    }

    public class UserLastLocation
    {
        [JsonProperty("GEOIP_CITY_COUNTRY_CODE")]
        public string GEOIP_CITY_COUNTRY_CODE { get; set; }

        [JsonProperty("GEOIP_CITY_COUNTRY_CODE3")]
        public string GEOIP_CITY_COUNTRY_CODE3 { get; set; }

        [JsonProperty("GEOIP_CITY_COUNTRY_NAME")]
        public string GEOIP_CITY_COUNTRY_NAME { get; set; }

        [JsonProperty("GEOIP_CITY")]
        public string GEOIP_CITY { get; set; }

        [JsonProperty("GEOIP_CITY_CONTINENT_CODE")]
        public string GEOIP_CITY_CONTINENT_CODE { get; set; }

        [JsonProperty("GEOIP_LATITUDE")]
        public double GEOIP_LATITUDE { get; set; }

        [JsonProperty("GEOIP_LONGITUDE")]
        public double GEOIP_LONGITUDE { get; set; }

        [JsonProperty("GEOIP_AS_ORG")]
        public string GEOIP_AS_ORG { get; set; }

        [JsonProperty("GEOIP_ORG")]
        public string GEOIP_ORG { get; set; }

        [JsonProperty("GEOIP_ISP")]
        public string GEOIP_ISP { get; set; }

        [JsonProperty("GEOIP_NET_NAME")]
        public string GEOIP_NET_NAME { get; set; }

        [JsonProperty("BADIP_TAGS")]
        public List<object> BADIP_TAGS { get; set; }
    }
}