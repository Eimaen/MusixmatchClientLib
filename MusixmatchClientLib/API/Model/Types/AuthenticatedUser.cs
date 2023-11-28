using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MusixmatchClientLib.API.Model.Types
{
    public class AuthenticatedUser
    {
        [JsonProperty("tokens")]
        public Tokens Tokens { get; set; }

        [JsonProperty("credential")]
        public Credential Credential { get; set; }

        [JsonProperty("auth")]
        public Auth Auth { get; set; }
    }
    
    public class Account
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("email_redirect_url")]
        public string EmailRedirectUrl { get; set; }

        [JsonProperty("extra_params")]
        public ExtraParams ExtraParams { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("registration_country")]
        public string RegistrationCountry { get; set; }

        [JsonProperty("user_type")]
        public string UserType { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("user_picture")]
        public string UserPicture { get; set; }

        [JsonProperty("user_nickname")]
        public string UserNickname { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("verified")]
        public bool Verified { get; set; }

        [JsonProperty("user_last_location")]
        public UserLastLocation UserLastLocation { get; set; }

        [JsonProperty("user_creation_date")]
        public DateTime UserCreationDate { get; set; }

        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }

        [JsonProperty("namespace")]
        public string Namespace { get; set; }

        [JsonProperty("userdata_id")]
        public string UserdataId { get; set; }

        [JsonProperty("has_profile_photo")]
        public bool HasProfilePhoto { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }

    public class Auth
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("authorizations")]
        public Authorizations Authorizations { get; set; }
    }

    public class Authorizations
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("private")]
        public bool Private { get; set; }

        [JsonProperty("safe")]
        public string Safe { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }

        [JsonProperty("namespace")]
        public string Namespace { get; set; }

        [JsonProperty("userdata_id")]
        public string UserdataId { get; set; }

        [JsonProperty("referral_list")]
        public List<ReferralList> ReferralList { get; set; }
    }

    public class Credential
    {
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("account")]
        public Account Account { get; set; }
    }

    public class ExtraParams
    {
        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }
    }

    public class ReferralList
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("invitation")]
        public string Invitation { get; set; }
    }

    public class Tokens
    {
        [JsonProperty("musixmatch-artists-v2.0")]
        public string MusixmatchArtistsV20 { get; set; }

        [JsonProperty("mxm-backoffice-v1.0")]
        public string MxmBackofficeV10 { get; set; }

        [JsonProperty("musixmatch-podcasts-v2.0")]
        public string MusixmatchPodcastsV20 { get; set; }

        [JsonProperty("musixmatch-podcasts-v2.0-pp")]
        public string MusixmatchPodcastsV20Pp { get; set; }

        [JsonProperty("mxm-pro-web-v1.0")]
        public string MxmProWebV10 { get; set; }

        [JsonProperty("mxm-com-v1.0")]
        public string MxmComV10 { get; set; }

        [JsonProperty("musixmatch-publishers-v2.0")]
        public string MusixmatchPublishersV20 { get; set; }

        [JsonProperty("web-desktop-app-v1.0")]
        public string WebDesktopAppV10 { get; set; }

        [JsonProperty("community-app-v1.0")]
        public string CommunityAppV10 { get; set; }

        [JsonProperty("mxm-proxy-manager-v1.0")]
        public string MxmProxyManagerV10 { get; set; }

        [JsonProperty("mxm-studio-v1.0")]
        public string MxmStudioV10 { get; set; }

        [JsonProperty("mxm-account-v1.0")]
        public string MxmAccountV10 { get; set; }
    }

    public class UserLastLocation
    {
        [JsonProperty("GEOIP_CITY_COUNTRY_CODE")]
        public string GEOIPCITYCOUNTRYCODE { get; set; }

        [JsonProperty("GEOIP_CITY_COUNTRY_CODE3")]
        public string GEOIPCITYCOUNTRYCODE3 { get; set; }

        [JsonProperty("GEOIP_CITY_COUNTRY_NAME")]
        public string GEOIPCITYCOUNTRYNAME { get; set; }

        [JsonProperty("GEOIP_CITY")]
        public string GEOIPCITY { get; set; }

        [JsonProperty("GEOIP_CITY_CONTINENT_CODE")]
        public string GEOIPCITYCONTINENTCODE { get; set; }

        [JsonProperty("GEOIP_LATITUDE")]
        public double GEOIPLATITUDE { get; set; }

        [JsonProperty("GEOIP_LONGITUDE")]
        public double GEOIPLONGITUDE { get; set; }

        [JsonProperty("GEOIP_AS_ORG")]
        public string GEOIPASORG { get; set; }

        [JsonProperty("GEOIP_ORG")]
        public string GEOIPORG { get; set; }

        [JsonProperty("GEOIP_ISP")]
        public string GEOIPISP { get; set; }

        [JsonProperty("GEOIP_NET_NAME")]
        public string GEOIPNETNAME { get; set; }

        [JsonProperty("BADIP_TAGS")]
        public List<object> BADIPTAGS { get; set; }
    }
}