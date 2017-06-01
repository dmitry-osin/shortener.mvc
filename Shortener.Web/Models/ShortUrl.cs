using System;

namespace Shortener.Web.Models
{
    public class ShortUrl
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string ShortLink { get; set; }
        public DateTime DateTimeUtc { get; set; }
        public string Description { get; set; }

        public ShortUrl()
        {
            DateTimeUtc = DateTime.UtcNow;
        }

        public void Deconstruct(out int id,
            out string link, 
            out string shortLink, 
            out DateTime dateTime, 
            out string description)
        {
            id = Id;
            link = Link;
            shortLink = ShortLink;
            dateTime = DateTimeUtc;
            description = Description;
        }
    }
}