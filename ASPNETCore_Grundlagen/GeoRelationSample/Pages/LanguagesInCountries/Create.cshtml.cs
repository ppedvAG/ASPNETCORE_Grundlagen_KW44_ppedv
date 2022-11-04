using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GeoRelationSample.Data;
using GeoRelationSample.Models;

namespace GeoRelationSample.Pages.LanguagesInCountries
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
        ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
        ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public LanguageInCountry LanguageInCountry { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("LanguageInCountry.CountryRef");
            ModelState.Remove("LanguageInCountry.LanguageRef");

            List<LanguageInCountry> allLanguagesInCountry = _context.LanguagesInCountry.Where(l => l.CountryId == LanguageInCountry.CountryId).ToList();

            int reservedPercent = 0;

            if (allLanguagesInCountry.Count > 0)
            {
                reservedPercent = allLanguagesInCountry.Sum(l => l.Percent);
            }


            //Wenn wir höher als 100 sind, bekommen wir einen Fehler 
            if (reservedPercent + LanguageInCountry.Percent > 100)
            {
                int available = 100 - reservedPercent;
                ModelState.AddModelError("LanguageInCountry.Percent", $"Alle Sprachanteile dürfen nicht über 100 Prozent liegen. Aktuell Verfügbar: {available}");
            }




            if (!ModelState.IsValid)
            {
                ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
                ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Name");
                return Page();
            }

            _context.LanguagesInCountry.Add(LanguageInCountry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
