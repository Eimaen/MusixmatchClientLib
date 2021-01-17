using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusixmatchClientLib.API.Model
{
    public class Root
    {
        [JsonProperty("data")]
        public Data SongData;

        public class Badge
        {
            [JsonProperty("image_url_large")]
            public string ImageUrlLarge;

            [JsonProperty("image_url_small")]
            public string ImageUrlSmall;

            [JsonProperty("name")]
            public string Name;

            [JsonProperty("__typename")]
            public string Typename;
        }

        public class Item
        {
            [JsonProperty("id")]
            public string Id;

            [JsonProperty("badges")]
            public List<Badge> Badges;

            [JsonProperty("categories")]
            public List<string> Categories;

            [JsonProperty("description")]
            public string Description;

            [JsonProperty("duration")]
            public int Duration;

            [JsonProperty("expiry")]
            public DateTime Expiry;

            [JsonProperty("lastUpdated")]
            public DateTime LastUpdated;

            [JsonProperty("missionId")]
            public string MissionId;

            [JsonProperty("num_tasks_target")]
            public int NumTasksTarget;

            [JsonProperty("title")]
            public string Title;

            [JsonProperty("userProgress")]
            public object UserProgress;

            [JsonProperty("__typename")]
            public string Typename;
        }

        public class GetAvailableMissions
        {
            [JsonProperty("items")]
            public List<Item> Items;

            [JsonProperty("nextToken")]
            public object NextToken;

            [JsonProperty("__typename")]
            public string Typename;
        }

        public class Data
        {
            [JsonProperty("getAvailableMissions")]
            public GetAvailableMissions GetAvailableMissions;
        }
    }
}
