using System;
using System.Collections.Generic;
using System.Linq;
using Shortener.Web.Contracts;
using Shortener.Web.Infrastructure;
using Shortener.Web.Models;

namespace Shortener.Web.Repository
{
    public class UrlRepository : GenericRepository<ShortUrl>, IUrlRepository, IDisposable
    {

        #region [Constuctor]

        public UrlRepository(AppDbContext context) : base(context)
        {
        }

        #endregion

        #region [IUrlRepository Impl]

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
                .Where(x => x.DateTimeUtc == time)
                .ToArray();
        }

        #endregion
    }
}