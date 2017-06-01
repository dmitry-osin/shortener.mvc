using System.Collections.Generic;
using System.Threading.Tasks;
using Shortener.Web.Models;

namespace Shortener.Web.Contracts
{
    public interface IUrlService
    {
        Task AddUrl(ShortUrl url);
        Task DeleteUrl(ShortUrl url);
        Task DeleteRange(IEnumerable<ShortUrl> urls);
        Task<IEnumerable<ShortUrl>> GetByCount(int count = 10);
        Task<IEnumerable<ShortUrl>> GetAll();
        Task<ShortUrl> GetByUrl(string url);
    }
}