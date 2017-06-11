using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace Shortener.Web.ViewModel
{
    public class ShortUrlViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field must be filled")]
        [Display(Name = "Link to redirect")]
        [RegularExpression("^((http|https|ssh|file):\\/\\/)?(www[0-9]\\.)?(([A-Za-z0-9_-])+\\.{1})+([A-Za-z]{2,4}|\\<[^<>]+\\>)(\\/([A-Za-z0-9_-])+)*(\\/)?$", ErrorMessage = "Please enter correct url")]
        [StringLength(2048, ErrorMessage = "Length must be less than 2048 chars")]
        public string Link { get; set; }
        [Display(Name = "Short link")]
        public string ShortLink { get; set; }
        [Display(Name = "Link creating date and time")]
        public DateTime DateTimeUtc { get; set; }
        [Display(Name = "Link title")]
        [StringLength(256, ErrorMessage = "Length must be less than 256 chars")]
        public string Title { get; set; }

        public ShortUrlViewModel()
        {
            DateTimeUtc = DateTime.UtcNow;
        }

        public string RedirectUri => $"{HttpContext.Current.Request.Url.Host}/g/{ShortLink}";
        public string PlainLink => RedirectUri;
        public string BbCode => $"[url={RedirectUri}]{Title ?? "ShortLink"}[/url]";
        public string Html => $"<a href=\"{RedirectUri}\">{Title ?? "ShortLink"}</a>";

        public void Deconstruct(out int id,
            out string link,
            out string shortLink,
            out DateTime dateTime,
            out string title)
        {
            id = Id;
            link = Link;
            shortLink = ShortLink;
            dateTime = DateTimeUtc;
            title = Title;
        }
    }
}