using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StateManagementSample.Models;
using System.Text.Json;

namespace StateManagementSample.Pages.SessionSample
{
    public class SessionStartModel : PageModel
    {
        public void OnGet()
        {
            this.HttpContext.Session.SetInt32("lottozahlen", 1234567);


            Movie movie = new Movie { Id = 123, Title = "Coda", Description = "Film einer Musikerin in einer Familie mit Hörproblem", Price = 19.99m, Genre = GenreTyp.Drama };

            string jsonString = JsonSerializer.Serialize(movie);
            HttpContext.Session.SetString("MovieDesMonats", jsonString);
        }
    }
}
