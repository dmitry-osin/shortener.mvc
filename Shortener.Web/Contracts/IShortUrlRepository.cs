using System;
using System.Collections.Generic;
using Shortener.Web.Models;

namespace Shortener.Web.Contracts
{
    public interface IShortUrlRepository : IDisposable
    {
        IEnumerable<ShortUrl> GetAll();
        IEnumerable<ShortUrl> GetByCount(int count);
        IEnumerable<ShortUrl> GetByDate(DateTime time);
    }
}