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
    public class DetailsModel : PageModel
    {
        private readonly GeoRelationSample.Data.GeoDbContext _context;

        public DetailsModel(GeoRelationSample.Data.GeoDbContext context)
        {
            _context = context;
        }

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
    }
}
