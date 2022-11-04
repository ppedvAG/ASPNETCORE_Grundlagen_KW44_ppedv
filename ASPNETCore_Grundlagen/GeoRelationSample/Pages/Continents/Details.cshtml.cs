using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GeoRelationSample.Data;
using GeoRelationSample.Models;

namespace GeoRelationSample.Pages.Continents
{
    public class DetailsModel : PageModel
    {
        private readonly GeoRelationSample.Data.GeoDbContext _context;

        public DetailsModel(GeoRelationSample.Data.GeoDbContext context)
        {
            _context = context;
        }

      public Continent Continent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Continents == null)
            {
                return NotFound();
            }

            var continent = await _context.Continents.FirstOrDefaultAsync(m => m.Id == id);
            if (continent == null)
            {
                return NotFound();
            }
            else 
            {
                Continent = continent;
            }
            return Page();
        }
    }
}
