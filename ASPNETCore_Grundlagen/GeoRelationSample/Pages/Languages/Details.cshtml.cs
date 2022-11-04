using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GeoRelationSample.Data;
using GeoRelationSample.Models;

namespace GeoRelationSample.Pages.Languages
{
    public class DetailsModel : PageModel
    {
        private readonly GeoRelationSample.Data.GeoDbContext _context;

        public DetailsModel(GeoRelationSample.Data.GeoDbContext context)
        {
            _context = context;
        }

      public Language Language { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Languages == null)
            {
                return NotFound();
            }

            var language = await _context.Languages.FirstOrDefaultAsync(m => m.Id == id);
            if (language == null)
            {
                return NotFound();
            }
            else 
            {
                Language = language;
            }
            return Page();
        }
    }
}
