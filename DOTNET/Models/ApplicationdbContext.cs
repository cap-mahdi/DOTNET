using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;

namespace TP3.Models
{
    public class ApplicationdbContext : DbContext
    {
        public ApplicationdbContext(DbContextOptions options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Membershiptype> Membershiptypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            string GenreJSon = System.IO.File.ReadAllText("Genre.Json");
            List<Genre>? Genre = System.Text.Json.JsonSerializer.Deserialize<List<Genre>>(GenreJSon);
            foreach (Genre c in Genre)
                modelBuilder.Entity<Genre>()
                .HasData(c);

        }
    }
}
