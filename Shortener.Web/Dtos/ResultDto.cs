﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shortener.Web.Dtos
{
    public class ResultDto
    {
        public IEnumerable<string> Errors { get; set; }
        public UrlDto UrlsDto { get; set; }
    }
}