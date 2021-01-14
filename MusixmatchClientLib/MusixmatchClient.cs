using MusixmatchClientLib.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusixmatchClientLib
{
    public class MusixmatchClient
    {
        private ApiRequestFactory requestFactory;

        public MusixmatchClient(string userToken)
        {
            requestFactory = new ApiRequestFactory(userToken);
        }
    }
}
