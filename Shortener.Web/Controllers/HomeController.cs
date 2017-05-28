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
            using (var ctx = new UrlRepository(AppDbContext.Create()))
            {
                var list = ctx.GetAll();
            }
            return View();
        }
    }
}