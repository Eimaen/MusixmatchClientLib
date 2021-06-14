using MusixmatchClientLib.API.Model.Types;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MusixmatchClientLib.API.Model.Requests
{
    public class CrowdUserFeedbackGet : MusixmatchApiResponse
    {
        [JsonProperty("feedback_list")]
        public List<FeedbackList> Feedbacks;
    }
}
