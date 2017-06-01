using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Shortener.Web.Helper;
using Shortener.Web.Infrastructure;
using Shortener.Web.Models;
using Shortener.Web.Repository;
using Shortener.Web.Service;

namespace Shortener.Web.Controllers
{
    public class HomeController : Controller
    {
        [Route("urls")]
        public async Task<ActionResult> List()
        {
            var service = new UrlService();
            var list = await service.GetAll();
            return View(list);
        }

        [HttpGet]
        [Route("")]
        public ActionResult Create()
        {
            var url = new ShortUrl()
            {
                ShortLink = ShortUrlHelper.GenerateUrl()
            };
            return View(url);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Create(ShortUrl url)
        {
            if (url == null) throw new ArgumentNullException(nameof(url));
            var service = new UrlService();
            await service.AddUrl(url);

            return RedirectToAction("List");
        }


        [Route("gt/{url}")]
        public async Task<ActionResult> GoToUrl(string url)
        {
            if (url == null) throw new ArgumentNullException(nameof(url));
            var service = new UrlService();
            var redirectUrl = await service.GetByUrl(url);

            if (redirectUrl == null)
                return RedirectToAction("Create");

            return Redirect(redirectUrl.Link);
        }
    }
}