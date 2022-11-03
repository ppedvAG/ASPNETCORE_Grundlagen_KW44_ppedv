using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPage_Scaffolded.Data;
using RazorPage_Scaffolded.Models;

namespace RazorPage_Scaffolded.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly RazorPage_Scaffolded.Data.RazorPage_ScaffoldedMovieDbContext _context;

        public CreateModel(RazorPage_Scaffolded.Data.RazorPage_ScaffoldedMovieDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
