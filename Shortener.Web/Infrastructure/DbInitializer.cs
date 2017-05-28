using System;
using System.Data.Entity;
using Shortener.Web.Models;

namespace Shortener.Web.Infrastructure
{
    // DropCreateDatabaseAlways<DataContext>
    // DropCreateDatabaseIfModelChanges<DataContext>
    // MigrateDatabaseToLatestVersion<DataContext, Configuration>
    // CreateDatabaseIfNotExists<DataContext>

    public sealed class DbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            base.Seed(context);
            context.ShortUrls.Add(new ShortUrl()
            {
                ShortLink = "a12Zcx1D",
                DateTime = DateTime.UtcNow.ToString("d"),
                Link = "http://google.com"
            });

            context.SaveChanges();
        }
    }
}