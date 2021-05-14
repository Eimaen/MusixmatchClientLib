using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MusixmatchClientLib.API.Model.Requests
{
    public class UserGet : MusixmatchApiResponse
    {
        [JsonProperty("user")]
        public User UserData;

        [JsonProperty("device")]
        public Device DeviceData;

        public class UserLastLocation
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

        public class Offers
        {
        }

        public class ReferralCode
        {
            [JsonProperty("name")]
            public string Name;

            [JsonProperty("invitation")]
            public string Invitation;

            [JsonProperty("url")]
            public string Url;
        }

        public class ReferralCodeList
        {
            [JsonProperty("referral_code")]
            public ReferralCode ReferralCode;
        }

        public class Profile
        {
            [JsonProperty("last_name")]
            public string LastName;

            [JsonProperty("first_name")]
            public string FirstName;

            [JsonProperty("middle_name")]
            public string MiddleName;

            [JsonProperty("email")]
            public string Email;

            [JsonProperty("user_id")]
            public string UserId;

            [JsonProperty("user_picture")]
            public string UserPicture;

            [JsonProperty("user_nickname")]
            public string UserNickname;

            [JsonProperty("user_type")]
            public string UserType;

            [JsonProperty("user_last_location")]
            public UserLastLocation UserLastLocation;

            [JsonProperty("name")]
            public string Name;

            [JsonProperty("birthday")]
            public string Birthday;

            [JsonProperty("gender")]
            public string Gender;

            [JsonProperty("age_range")]
            public string AgeRange;

            [JsonProperty("user_creation_date")]
            public DateTime UserCreationDate;

            [JsonProperty("has_profile_photo")]
            public bool HasProfilePhoto;
        }

        public class Authorizations
        {
            [JsonProperty("active")]
            public bool Active;

            [JsonProperty("private")]
            public bool Private;

            [JsonProperty("safe")]
            public string Safe;

            [JsonProperty("user_id")]
            public string UserId;

            [JsonProperty("last_updated")]
            public DateTime LastUpdated;

            [JsonProperty("namespace")]
            public string Namespace;

            [JsonProperty("userdata_id")]
            public string UserdataId;

            [JsonProperty("mission_subscriber")]
            public bool MissionSubscriber;
        }

        public class Features
        {
            [JsonProperty("no_ads")]
            public int NoAds;

            [JsonProperty("lyrics_offline")]
            public int LyricsOffline;

            [JsonProperty("clean_metadata")]
            public int CleanMetadata;

            [JsonProperty("party_mode")]
            public int PartyMode;
        }

        public class ActiveProduct
        {
            [JsonProperty("product_id")]
            public string ProductId;

            [JsonProperty("product_type")]
            public string ProductType;

            [JsonProperty("creation_date")]
            public DateTime CreationDate;

            [JsonProperty("start_date")]
            public DateTime StartDate;

            [JsonProperty("end_date")]
            public DateTime EndDate;

            [JsonProperty("credits")]
            public int Credits;

            [JsonProperty("features")]
            public Features Features;
        }

        public class User
        {
            [JsonProperty("user_id")]
            public string UserId;

            [JsonProperty("id")]
            public string Id;

            [JsonProperty("name")]
            public string Name;

            [JsonProperty("user_last_location")]
            public UserLastLocation UserLastLocation;

            [JsonProperty("user_creation_date")]
            public DateTime UserCreationDate;

            [JsonProperty("offers")]
            public Offers Offers;

            [JsonProperty("referral_code_list")]
            public List<ReferralCodeList> ReferralCodeList;

            [JsonProperty("profile")]
            public Profile Profile;

            [JsonProperty("authorizations")]
            public Authorizations Authorizations;

            [JsonProperty("payment_widget_link")]
            public string PaymentWidgetLink;

            [JsonProperty("active_products")]
            public List<ActiveProduct> ActiveProducts;
        }

        public class Device
        {
            [JsonProperty("guid")]
            public string Guid;

            [JsonProperty("build_number")]
            public string BuildNumber;
        }
    }
}
