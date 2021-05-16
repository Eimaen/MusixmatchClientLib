using System;
using System.Collections.Generic;
using System.Text;

namespace MusixmatchClientLib.API.Processors
{
    public abstract class RequestProcessor
    {
        public abstract string Post(string url, string data);
        public abstract string Get(string url);
    }
}
