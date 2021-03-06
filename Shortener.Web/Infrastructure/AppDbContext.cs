﻿using System.Data.Entity;
using Shortener.Web.Models;

namespace Shortener.Web.Infrastructure
{
    public class AppDbContext : DbContext
    {
        #region [DbSets]

        public DbSet<ShortUrl> ShortUrls { get; set; }

        #endregion

        #region [Constructor]

        private AppDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        #endregion

        #region [Methods]

        public static AppDbContext Create(string nameOrConnectionString = "DefaultConnection")
        {
            return new AppDbContext(nameOrConnectionString);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            BuildShortUrlModelTree(modelBuilder);
        }

        private static void BuildShortUrlModelTree(DbModelBuilder modelBuilder)
        {
            modelBuilder.RegisterEntityType(typeof(ShortUrl));

            modelBuilder.Entity<ShortUrl>()
                .ToTable("Urls");

            modelBuilder.Entity<ShortUrl>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<ShortUrl>()
                .Property(x => x.Link)
                .HasMaxLength(2048)
                .IsRequired();

            modelBuilder.Entity<ShortUrl>()
                .Property(x => x.DateTimeUtc)
                .IsRequired();

            modelBuilder.Entity<ShortUrl>()
                .Property(x => x.ShortLink)
                .IsOptional();

            modelBuilder.Entity<ShortUrl>()
                .Property(x => x.Title)
                .HasMaxLength(256)
                .IsOptional();
        }

        #endregion
    }
}