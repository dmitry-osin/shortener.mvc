using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shortener.Web.Infrastructure;
using Shortener.Web.Repository;

namespace Shortener.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (var ctx = new ShortUrlRepository(new AppDbContext()))
            {
                var list = ctx.FindBy(url => url.Link != null);
            }
            return View();
        }
    }
}