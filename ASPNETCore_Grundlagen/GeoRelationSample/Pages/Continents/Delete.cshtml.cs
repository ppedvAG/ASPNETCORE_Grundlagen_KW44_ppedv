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
    public class DeleteModel : PageModel
    {
        private readonly GeoRelationSample.Data.GeoDbContext _context;

        public DeleteModel(GeoRelationSample.Data.GeoDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Continents == null)
            {
                return NotFound();
            }
            var continent = await _context.Continents.FindAsync(id);

            if (continent != null)
            {
                Continent = continent;
                _context.Continents.Remove(Continent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
