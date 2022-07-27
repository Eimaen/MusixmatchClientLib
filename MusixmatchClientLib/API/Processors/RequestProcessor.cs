using System.Threading.Tasks;

namespace MusixmatchClientLib.API.Processors
{
    public abstract class RequestProcessor
    {
        public abstract string Post(string url, string data);
        public abstract string Get(string url);
        public abstract Task<string> PostAsync(string url, string data);
        public abstract Task<string> GetAsync(string url);
    }
}
