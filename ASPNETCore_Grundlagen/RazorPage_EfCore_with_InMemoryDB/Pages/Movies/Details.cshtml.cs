using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPage_EfCore_with_InMemoryDB.Data;
using RazorPage_EfCore_with_InMemoryDB.Models;

namespace RazorPage_EfCore_with_InMemoryDB.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly MovieDbContext context;


        public Movie Movie { get; set; }

        public DetailsModel(MovieDbContext context)
        {
            this.context = context;
        }




        /// <summary>
        /// Asynchrone OnGet Methode 
        /// </summary>
        /// <returns>Task<IActionResult> kann Http Fehlercodes zusätzlich ausgeben</returns>
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
                return NotFound();

            Movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == id);

            if (Movie == null)
                return NotFound();

            return Page(); //Explizierter Befehl für IActionResult -> Zeige mir die Page an
        }
    }
}
