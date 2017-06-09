using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shortener.Web.Contracts;
using Shortener.Web.Infrastructure;
using Shortener.Web.Models;
using Shortener.Web.Repository;

namespace Shortener.Web.Service
{
    public class UrlService : IUrlService
    {
        #region [IUrlService Impl]

        public Task<ShortUrl> AddUrl(ShortUrl url)
        {
            return Task.Run(() =>
            {
                using (var repo = new UrlRepository(AppDbContext.Create()))
                {
                    var entity = repo.Add(url);
                    repo.Commit();
                    return entity;
                }
            });
        }

        public Task<ShortUrl> Get(int id)
        {
            return Task.Run(() =>
            {
                using (var repo = new UrlRepository(AppDbContext.Create()))
                {
                    var entity = repo.FindBy(url => url.Id == id).FirstOrDefault();
                    repo.Commit();
                    return entity;
                }
            });
        }

        public async Task DeleteUrl(ShortUrl url)
        {
            await Task.Run(() =>
                {
                    using (var repo = new UrlRepository(AppDbContext.Create()))
                    {
                        repo.Remove(url);
                        repo.Commit();
                    }
                })
                .ConfigureAwait(false);
        }

        public async Task DeleteRange(IEnumerable<ShortUrl> urls)
        {
            await Task.Run(() =>
                {
                    using (var repo = new UrlRepository(AppDbContext.Create()))
                    {
                        repo.RemoveRange(urls);
                        repo.Commit();
                    }
                })
                .ConfigureAwait(false);
        }

        public Task<IEnumerable<ShortUrl>> GetByCount(int count = 10)
        {
            return Task.Run(() =>
            {
                using (var repo = new UrlRepository(AppDbContext.Create()))
                {
                    return repo.GetByCount(count);
                }
            });
        }

        public Task<IEnumerable<ShortUrl>> GetAll()
        {
            return Task.Run(() =>
            {
                using (var repo = new UrlRepository(AppDbContext.Create()))
                {
                    return repo.GetAll();
                }
            });
        }

        public Task<ShortUrl> GetByUrl(string url)
        {
            return Task.Run(() =>
            {
                using (var repo = new UrlRepository(AppDbContext.Create()))
                {
                    return repo.GetByUrl(url);
                }
            });
        }

        #endregion
    }
}