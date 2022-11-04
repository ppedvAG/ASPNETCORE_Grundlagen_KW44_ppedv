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
    public class IndexModel : PageModel
    {
        private readonly GeoRelationSample.Data.GeoDbContext _context;

        public IndexModel(GeoRelationSample.Data.GeoDbContext context)
        {
            _context = context;
        }

        public IList<Language> Language { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Languages != null)
            {
                Language = await _context.Languages.ToListAsync();
            }
        }
    }
}
