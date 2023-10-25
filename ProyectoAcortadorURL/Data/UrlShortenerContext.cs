using Microsoft.EntityFrameworkCore;
using ProyectoAcortadorURL.Entities;

namespace ProyectoAcortadorURL.Data
{
    public class UrlShortenerContext : DbContext
    {
        public UrlShortenerContext() { 
        }
        public DbSet<ShortenedURL> ShortenedURLs { get; set; }
        public UrlShortenerContext(DbContextOptions<UrlShortenerContext>options) : base(options)
        {
             
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortenedURL>().ToTable("ShortenedUrls");

            base.OnModelCreating(modelBuilder);
        }
    }
}
 