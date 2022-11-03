using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPage_Scaffolded.Data;
using RazorPage_Scaffolded.Models;

namespace RazorPage_Scaffolded.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPage_Scaffolded.Data.RazorPage_ScaffoldedMovieDbContext _context;

        public IndexModel(RazorPage_Scaffolded.Data.RazorPage_ScaffoldedMovieDbContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Movie != null)
            {
                Movie = await _context.Movie.ToListAsync();
            }
        }
    }
}
