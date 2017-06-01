using System;
using System.Collections.Generic;
using Shortener.Web.Models;

namespace Shortener.Web.Contracts
{
    public interface IUrlRepository : IDisposable
    {
        IEnumerable<ShortUrl> GetAll();
        IEnumerable<ShortUrl> GetByCount(int count);
        IEnumerable<ShortUrl> GetByDate(DateTime time);
    }
}