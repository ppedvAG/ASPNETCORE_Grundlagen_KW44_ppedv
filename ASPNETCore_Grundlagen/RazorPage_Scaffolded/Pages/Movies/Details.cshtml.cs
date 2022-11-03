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
    public class DetailsModel : PageModel
    {
        private readonly RazorPage_Scaffolded.Data.RazorPage_ScaffoldedMovieDbContext _context;

        public DetailsModel(RazorPage_Scaffolded.Data.RazorPage_ScaffoldedMovieDbContext context)
        {
            _context = context;
        }

      public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            else 
            {
                Movie = movie;
            }
            return Page();
        }
    }
}
