﻿using System;
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
        #region [Action Methods]

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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ShortUrlViewModel url)
        {
            if (ModelState.IsValid)
            {
                HandleLinkPrefix(url);

                var service = new UrlService();
                var res = Mapper.Map<ShortUrlViewModel, ShortUrl>(url);
                await service.AddUrl(res);
                return RedirectToAction("Details", new { url = url.ShortLink });
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

        [Route("me")]
        public ActionResult AboutMe()
        {
            return Redirect("http://d-osin.ru");
        }

        #endregion

        #region [Helper Methods]

        private static void HandleLinkPrefix(ShortUrlViewModel url)
        {
            if (!url.Link.StartsWith("http") && !url.Link.StartsWith("ftp") && !url.Link.StartsWith("https") &&
                !url.Link.StartsWith("file"))
                url.Link = $"http://{url.Link}";
        }

        #endregion
    }
}