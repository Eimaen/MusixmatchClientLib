﻿using MusixmatchClientLib.API.Model.Types;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MusixmatchClientLib.API.Model.Requests
{
    public class CrowdFeedbackGet : MusixmatchApiResponse
    {
        [JsonProperty("feedback_list")]
        public List<FeedbackList> Feedbacks;
    }
}
