using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StateManagementSample.Pages.TempDataSample
{

    //Im Default kann TempData nur einmalige Nachrichten �bertragen.
    //-> Mit weiteren Methoden kann man auch mehrfach eine Nachricht �bertragen

    //Wir k�nnen RazorPage �bergreifen Informationen via TempData �bermitteln (1x Nachrichten oder bei mehr Aufwand auch mehrmals)



    public class TempDataSampleStartModel : PageModel
    {
        public void OnGet()
        {
            
            TempData.Add("Email", "KevinW@ppedv.de");
        }
    }
}
