using Microsoft.EntityFrameworkCore;
using MovieApi.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MovieApi.Persistence.Identity;

namespace MovieApi.Persistence.Context
{
    public class MovieContext : IdentityDbContext<AppUser>
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Server=HAZALSAVRAN\\SQLEXPRESS;Database=MovieApiDb;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True"); 
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Cast> Casts { get; set; }
       
       
    }
}

