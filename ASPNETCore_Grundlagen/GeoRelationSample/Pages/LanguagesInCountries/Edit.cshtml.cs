using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GeoRelationSample.Data;
using GeoRelationSample.Models;

namespace GeoRelationSample.Pages.LanguagesInCountries
{
    public class EditModel : PageModel
    {
        private readonly GeoRelationSample.Data.GeoDbContext _context;

        public EditModel(GeoRelationSample.Data.GeoDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LanguageInCountry LanguageInCountry { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.LanguagesInCountry == null)
            {
                return NotFound();
            }

            var languageincountry =  await _context.LanguagesInCountry.FirstOrDefaultAsync(m => m.Id == id);
            if (languageincountry == null)
            {
                return NotFound();
            }
            LanguageInCountry = languageincountry;
           ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id");
           ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LanguageInCountry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguageInCountryExists(LanguageInCountry.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LanguageInCountryExists(int id)
        {
          return _context.LanguagesInCountry.Any(e => e.Id == id);
        }
    }
}
