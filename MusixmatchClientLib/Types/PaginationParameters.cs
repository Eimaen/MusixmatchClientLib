using System;
using System.Collections.Generic;
using System.Text;

namespace MusixmatchClientLib.Types
{
    public class PaginationParameters
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set } = 10;
    }
}
