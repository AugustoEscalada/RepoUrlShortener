using Microsoft.EntityFrameworkCore;
using ProyectoAcortadorURL.Entities;

namespace ProyectoAcortadorURL.Data
{
    public class UrlShortenerContext : DbContext
    {
        public UrlShortenerContext() { 
        }
        public DbSet<ShortenedURL> ShortenedUrls { get; set; }

        public DbSet<User> Users { get; set; }
        public UrlShortenerContext(DbContextOptions<UrlShortenerContext>options) : base(options)
        {
             
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ShortenedURL>().ToTable("ShortenedUrls");
            modelBuilder.Entity<User>().ToTable("Users");

            User user1 = new User()
            {
                UserId = 1,
                Username = "augusto",
                Password = "password",
            };
          
            modelBuilder.Entity<User>().HasData(user1);

            base.OnModelCreating(modelBuilder);
        }
    }
}
 