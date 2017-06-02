using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shortener.Web.ViewModel
{
    public class ShortUrlViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field must be filled")]
        [Display(Name = "Link to redirect")]
        [StringLength(2048, ErrorMessage = "Length must be less than 2048 chars")]
        public string Link { get; set; }
        [Display(Name = "Short link")]
        public string ShortLink { get; set; }
        [Display(Name = "Link creating date and time")]
        public DateTime DateTimeUtc { get; set; }
        [Display(Name = "Link description")]
        [StringLength(256, ErrorMessage = "Length must be less than 256 chars")]
        public string Description { get; set; }

        public ShortUrlViewModel()
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