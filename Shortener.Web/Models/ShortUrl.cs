namespace Shortener.Web.Models
{
    public class ShortUrl
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string ShortLink { get; set; }
        public string DateTime { get; set; }
        public string Description { get; set; }
    }
}