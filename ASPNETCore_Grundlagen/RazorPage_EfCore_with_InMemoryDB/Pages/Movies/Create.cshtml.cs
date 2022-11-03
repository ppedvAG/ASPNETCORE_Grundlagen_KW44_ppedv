using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPage_EfCore_with_InMemoryDB.Data;
using RazorPage_EfCore_with_InMemoryDB.Models;

namespace RazorPage_EfCore_with_InMemoryDB.Pages.Movies
{
    public class CreateModel : PageModel
    {

        private readonly MovieDbContext context;

        public CreateModel(MovieDbContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        /// <summary>
        /// IActionResult kann Http-Codes zurück gegeben
        /// </summary>
        /// <returns></returns>
        public IActionResult OnGet()
        {
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            //Regel 

            if (Movie.Title == "The Crow")
            {
                //Durch AddModelError wird mein ModelState.IsValid auf false gesetzt
                ModelState.AddModelError("Movie.Title", "Dieser Film steht auf dem Index");
            }


            if(!ModelState.IsValid)
            {
                return Page(); //Der Datensatz wird wieder angezeigt, mit den Fehlermeldungen 
            }

            context.Movies.Add(Movie);

            //SavaChange wirft auf Fehler, wenn Datensatz laut DataAnnotations nicht valide ist
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


    }
}
