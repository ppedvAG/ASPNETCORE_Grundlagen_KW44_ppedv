using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageSamples.Pages.Einstieg
{
    public class CalcModel : PageModel
    {
        public int Ergebnis { get; set; }


        //OnGet wird bei einem Seitenaufruf immer aufgerufen
        //Bietet die M�glichkeit Initialisierungen anzugehen oder was man alles f�r einen Seitenaufruf noch ben�tigt 
        public void OnGet()
        {
            Ergebnis = 0;
        }

        public void OnPost()
        {
            int a = 0, b = 0;

            //traditioneller Zugriff ohne Binding 

            
            if (int.TryParse(Request.Form["eins"].FirstOrDefault(), out a) &&
                int.TryParse(Request.Form["zwei"].FirstOrDefault(), out b))
            {
                Ergebnis = a + b;
            }


        }
    }
}
