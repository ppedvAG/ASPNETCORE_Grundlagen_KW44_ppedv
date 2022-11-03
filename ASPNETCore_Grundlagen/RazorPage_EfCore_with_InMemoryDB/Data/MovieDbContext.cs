using Microsoft.EntityFrameworkCore;
using RazorPage_EfCore_with_InMemoryDB.Models;

namespace RazorPage_EfCore_with_InMemoryDB.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> dbContextOptions)
            :base(dbContextOptions)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
