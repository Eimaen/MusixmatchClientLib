using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusixmatchClientLib.API
{
    class CustomRequestParameters
    {
        public string EndpointOverride { get; set; } = null;
        public bool IgnoreDefaultCast { get; set; } = false;
    }
}
