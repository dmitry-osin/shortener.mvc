using System;
using Shortener.Web.Infrastructure;
using Shortener.Web.Models;

namespace Shortener.Web.Repository
{
    public class ShortUrlRepository : GenericRepository<ShortUrl>, IDisposable
    {
        public ShortUrlRepository(AppDbContext context) : base(context)
        {
        }
    }
}