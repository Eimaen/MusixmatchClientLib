using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusixmatchClientLib.API.Model
{
    public class MusixmatchApiResponse
    {
        public int StatusCode { get; set; }
        public double TimeElapsed { get; set; }
        public string Body { get; set; }

        public T Cast<T>() where T : MusixmatchApiResponse => JsonConvert.DeserializeObject<T>(Body);
    }
}
