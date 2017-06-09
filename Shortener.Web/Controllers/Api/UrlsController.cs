using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
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
            return Ok(urls);
        }
    }
}
