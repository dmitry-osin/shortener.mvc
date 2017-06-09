using AutoMapper;
using Shortener.Web.Dtos;
using Shortener.Web.Models;
using Shortener.Web.ViewModel;

namespace Shortener.Web
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<ShortUrl, ShortUrlViewModel>().ReverseMap();
                x.CreateMap<ShortUrl, UrlDto>().ReverseMap();
            });
        }
    }
}