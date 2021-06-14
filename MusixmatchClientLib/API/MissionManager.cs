using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace MusixmatchClientLib.API
{
    // [ Circus-P - Last of Me ] You can keep the last of me, I don't care, I am obsolete 🎵
    public class MissionManager
    {
        private string jwtToken { get; set; }

        internal MissionManager(string jwtToken) => this.jwtToken = jwtToken;

        [Obsolete("This class has to be rewritten with GraphQL support.")]
        public List<MissionResponse.Mission> ParseMissions(string userToken, string userId)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://missions-backend.musixmatch.com/graphql"); // GraphQL request, now looking for the real endpoint (if it exists)
            request.Method = "POST";
            request.Headers = new WebHeaderCollection();
            request.Headers.Add(HttpRequestHeader.Authorization, jwtToken);
            request.CookieContainer = new CookieContainer();
            string requestBody = $"{{\"operationName\":\"AvailableMissionsList\",\"variables\":{{\"userToken\":\"{userToken}\",\"appId\":\"web-desktop-app-v1.0\",\"userId\":\"{userId}\"}},\"query\":" +
                $"\"query AvailableMissionsList($appId: String, $userId: ID!, $userToken: String = null) {{\\n  getAvailableMissions(input: {{appId: $appId, userId: $userId, userToken: $userToken}}) " +
                $"{{\\n    items {{\\n      id\\n      badges {{\\n        image_url_large\\n        image_url_small\\n        name\\n        __typename\\n      }}\\n      categories\\n      " +
                $"description\\n      duration\\n      expiry\\n      lastUpdated\\n      missionId\\n      num_tasks_target\\n      title\\n      userProgress {{\\n        id\\n        " +
                $"deadline\\n        lastUpdated\\n        missionId\\n        num_tasks_completed\\n        status\\n        __typename\\n      }}\\n      __typename\\n    }}\\n    " +
                $"nextToken\\n    __typename\\n  }}\\n}}\\n\"}}"; // So long...
            byte[] byteArray = Encoding.UTF8.GetBytes(requestBody);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            using (Stream dataStream = request.GetRequestStream())
                dataStream.Write(byteArray, 0, byteArray.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    var responseBody = reader.ReadToEnd();
                    Console.WriteLine(responseBody);
                    MissionResponse responseParsed = JsonConvert.DeserializeObject<MissionResponse>(responseBody);
                    return responseParsed.MissionData.GetAvailableMissions.Items;
                }
            }
        }

        [Obsolete("This class has to be rewritten with GraphQL support.")]
        public class MissionResponse
        {
            [JsonProperty("data")]
            public Data MissionData;

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

            public class Mission
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
                public List<Mission> Items;

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
}
