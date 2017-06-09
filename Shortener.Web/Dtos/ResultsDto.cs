using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shortener.Web.Dtos
{
    public class ResultsDto
    {
        public IEnumerable<string> Errors { get; set; }
        public IEnumerable<UrlDto> UrlsDtos { get; set; }
    }
}