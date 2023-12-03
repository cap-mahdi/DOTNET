using Microsoft.EntityFrameworkCore;

namespace TP4.Models
{
    public class ApplicationdbContext: DbContext
    {

        public DbSet<Movie> Movie { get; set; }
        public DbSet<Role> Roles { get; set; }
        public ApplicationdbContext(DbContextOptions options) :base(options){ }

    }
}
