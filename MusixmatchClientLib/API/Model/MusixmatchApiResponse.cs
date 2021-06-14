using Newtonsoft.Json;

namespace MusixmatchClientLib.API.Model
{
    public class MusixmatchApiResponse
    {
        public int StatusCode { get; set; }
        public double TimeElapsed { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }

        public T Cast<T>() where T : MusixmatchApiResponse => JsonConvert.DeserializeObject<T>(Body, new JsonSerializerSettings { Error = (se, ev) => { ev.ErrorContext.Handled = true; } });
    }
}
