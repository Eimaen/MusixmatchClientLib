namespace MusixmatchClientLib.API
{
    public enum RequestMethod
    {
        GET,
        POST
    }

    class CustomRequestParameters
    {
        public RequestMethod RequestMethod { get; set; } = RequestMethod.GET;
        public string EndpointResource { get; set; } = "";
    }
}
