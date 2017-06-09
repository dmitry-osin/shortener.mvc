using System;

namespace Shortener.Web.Dtos
{
    public class UrlDto
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string ShortLink { get; set; }
    }
}