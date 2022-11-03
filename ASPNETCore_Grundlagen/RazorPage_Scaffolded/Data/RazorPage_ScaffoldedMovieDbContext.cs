using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPage_Scaffolded.Models;

namespace RazorPage_Scaffolded.Data
{
    public class RazorPage_ScaffoldedMovieDbContext : DbContext
    {
        public RazorPage_ScaffoldedMovieDbContext (DbContextOptions<RazorPage_ScaffoldedMovieDbContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPage_Scaffolded.Models.Movie> Movie { get; set; } = default!;
    }
}
