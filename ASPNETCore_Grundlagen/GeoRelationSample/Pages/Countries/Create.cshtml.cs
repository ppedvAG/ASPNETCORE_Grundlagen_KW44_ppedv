using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GeoRelationSample.Data;
using GeoRelationSample.Models;

namespace GeoRelationSample.Pages.Countries
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
            ViewData["ContinentId"] = new SelectList(_context.Continents, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Country Country { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            ModelState.Remove("Country.ContinentRef");
            ModelState.Remove("Country.LanguagesInCountryRef");

            if (!ModelState.IsValid)
            {
                ViewData["ContinentId"] = new SelectList(_context.Continents, "Id", "Name");
                return Page();
            }

            _context.Countries.Add(Country);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
//Country.ContinentRef
//    Country.LanguagesInCountryRef