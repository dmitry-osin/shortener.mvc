namespace Shortener.Web.Models
{
    public class ShortUrl
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string ShortLink { get; set; }
        public string DateTime { get; set; }
        public string Description { get; set; }

        public void Deconstruct(out int id,
            out string link, 
            out string shortLink, 
            out string dateTime, 
            out string description)
        {
            id = Id;
            link = Link;
            shortLink = ShortLink;
            dateTime = DateTime;
            description = Description;
        }
    }
}