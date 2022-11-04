using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GeoRelationSample.Data;
using GeoRelationSample.Models;

namespace GeoRelationSample.Pages.LanguagesInCountries
{
    public class DeleteModel : PageModel
    {
        private readonly GeoRelationSample.Data.GeoDbContext _context;

        public DeleteModel(GeoRelationSample.Data.GeoDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public LanguageInCountry LanguageInCountry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.LanguagesInCountry == null)
            {
                return NotFound();
            }

            var languageincountry = await _context.LanguagesInCountry.FirstOrDefaultAsync(m => m.Id == id);

            if (languageincountry == null)
            {
                return NotFound();
            }
            else 
            {
                LanguageInCountry = languageincountry;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.LanguagesInCountry == null)
            {
                return NotFound();
            }
            var languageincountry = await _context.LanguagesInCountry.FindAsync(id);

            if (languageincountry != null)
            {
                LanguageInCountry = languageincountry;
                _context.LanguagesInCountry.Remove(LanguageInCountry);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
