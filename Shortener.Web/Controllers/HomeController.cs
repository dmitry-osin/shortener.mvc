using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Shortener.Web.Helper;
using Shortener.Web.Infrastructure;
using Shortener.Web.Models;
using Shortener.Web.Repository;
using Shortener.Web.Service;
using Shortener.Web.ViewModel;

namespace Shortener.Web.Controllers
{
    public class HomeController : Controller
    {
        [Route("urls")]
        public async Task<ActionResult> List()
        {
            var service = new UrlService();
            var list = await service.GetAll();
            var res = Mapper.Map<IEnumerable<ShortUrl>, IEnumerable<ShortUrlViewModel>>(list);
            return View(res);
        }

        [HttpGet]
        [Route("")]
        public ActionResult Create()
        {
            var url = new ShortUrl {ShortLink = ShortUrlHelper.GenerateUrl()};
            var res = Mapper.Map<ShortUrl, ShortUrlViewModel>(url);
            return View(res);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Create(ShortUrlViewModel url)
        {
            if (ModelState.IsValid)
            {
                var service = new UrlService();
                var res = Mapper.Map<ShortUrlViewModel, ShortUrl>(url);
                await service.AddUrl(res);
                return RedirectToAction("List");
            }
            return RedirectToAction("Create");
        }


        [Route("g/{url}")]
        public async Task<ActionResult> GoToUrl(string url)
        {
            var service = new UrlService();
            var redirectUrl = await service.GetByUrl(url);

            if (redirectUrl == null)
                return RedirectToAction("Create");

            return Redirect(redirectUrl.Link);
        }

        [Route("d/{url}")]
        public async Task<ActionResult> Details(string url)
        {
            var service = new UrlService();
            var redirectUrl = await service.GetByUrl(url);

            if (redirectUrl == null)
                return RedirectToAction("Create");

            var model = Mapper.Map<ShortUrl, ShortUrlViewModel>(redirectUrl);
            return View(model);
        }
    }
}