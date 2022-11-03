using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPage_EfCore_with_InMemoryDB.Data;
using RazorPage_EfCore_with_InMemoryDB.Models;

namespace RazorPage_EfCore_with_InMemoryDB.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MovieDbContext movieDbContext;


        public IList<Movie> Movies { get; set; }

        public IndexModel(MovieDbContext movieDbContext)
        {
            this.movieDbContext = movieDbContext;
        }

        public void OnGet()
        {
            Movies = movieDbContext.Movies.ToList(); //Gebe mir alle Filme aus der Tabelle Movies aus. 
        }
    }
}
