using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GeoRelationSample.Data;
using GeoRelationSample.Models;

namespace GeoRelationSample.Pages.Continents
{
    public class CreateModel : PageModel
    {
        private readonly GeoRelationSample.Data.GeoDbContext _context;

        public CreateModel(GeoRelationSample.Data.GeoDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Continent Continent { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Continent.Countries");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Continents.Add(Continent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
