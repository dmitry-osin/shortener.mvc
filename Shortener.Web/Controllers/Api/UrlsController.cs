using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Shortener.Web.Dtos;
using Shortener.Web.Helper;
using Shortener.Web.Models;
using Shortener.Web.Service;

namespace Shortener.Web.Controllers.Api
{
    public class UrlsController : ApiController
    {
        //GET api/urls
        public async Task<IHttpActionResult> GetUrls()
        {
            var service = new UrlService();
            var urls = await service.GetAll();
            return Ok(urls.Select(Mapper.Map<ShortUrl, UrlDto>));
        }

        //GET api/urls/1
        public async Task<IHttpActionResult> GetUrl(int? id)
        {
            if (id == null)
                return BadRequest("You must provide url id");

            var service = new UrlService();
            var url = await service.Get(id.Value);

            if (url == null)
                return NotFound(); 

            return Ok(Mapper.Map<ShortUrl, UrlDto>(url));
        }

        //POST api/urls
        [HttpPost]
        public async Task<IHttpActionResult> CreateUrl(UrlDto url) // Can be Post by Convention with PostUrl name
        {
            if (url == null)
                return BadRequest("You must provide url to redirect");

            var service = new UrlService();

            var shortUrl = Mapper.Map<UrlDto, ShortUrl>(url);
            shortUrl.ShortLink = ShortUrlHelper.GenerateUrl();

            var result = await service.AddUrl(shortUrl);
            return Created($"{Request.RequestUri}/{result.Id}", Mapper.Map<ShortUrl, UrlDto>(result));
        }
    }
}
