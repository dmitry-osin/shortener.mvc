using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public IEnumerable<ShortUrl> GetByCount(int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShortUrl> GetByDate(DateTime time)
        {
            throw new NotImplementedException();
        }
    }
}