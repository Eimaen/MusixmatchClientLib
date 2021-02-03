using MusixmatchClientLib.API.Model.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusixmatchClientLib.API.Model
{
    public class CrowdScoreGet : MusixmatchApiResponse
    {
        [JsonProperty("user")]
        public User User;
    }
}
