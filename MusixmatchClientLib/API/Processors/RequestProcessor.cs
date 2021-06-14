namespace MusixmatchClientLib.API.Processors
{
    public abstract class RequestProcessor
    {
        public abstract string Post(string url, string data);
        public abstract string Get(string url);
    }
}
