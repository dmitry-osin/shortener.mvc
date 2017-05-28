using System;
using System.Collections.Generic;
using System.Linq;
using Shortener.Web.Contracts;
using Shortener.Web.Infrastructure;
using Shortener.Web.Models;

namespace Shortener.Web.Repository
{
    public class ShortUrlRepository : GenericRepository<ShortUrl>, IShortUrlRepository, IDisposable
    {
        public ShortUrlRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<ShortUrl> GetAll()
        {
            return GetAsNoTrackingQueryable().ToArray();
        }

        public IEnumerable<ShortUrl> GetByCount(int count)
        {
            return GetAsNoTrackingQueryable().Take(count);
        }

        public IEnumerable<ShortUrl> GetByDate(DateTime time)
        {
            return GetAsNoTrackingQueryable()
                .Where(x => x.DateTime == time.ToString("d"))
                .ToArray();
        }
    }
}