using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageSamples.Pages
{
    public class AspPageHandlerSampleModel : PageModel
    {
        public int Ergebnis { get; set; } = 0;

        public void OnGet()
        {
        }

        public void OnPostAdd()
        {
            int a, b = 0;
            int.TryParse(Request.Form["eins"].FirstOrDefault(), out a);
            int.TryParse(Request.Form["zwei"].FirstOrDefault(), out b);
            Ergebnis = a + b;
        }

        public void OnPostSub()
        {
            int a, b = 0;
            int.TryParse(Request.Form["eins"].FirstOrDefault(), out a);
            int.TryParse(Request.Form["zwei"].FirstOrDefault(), out b);
            Ergebnis = a - b;
        }


        public void OnPostMult()
        {

        }

        public void OnPostDiv()
        {

        }
    }
}
