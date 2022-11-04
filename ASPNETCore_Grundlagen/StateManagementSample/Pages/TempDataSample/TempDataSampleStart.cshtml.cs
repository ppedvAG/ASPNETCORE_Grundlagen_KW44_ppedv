using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StateManagementSample.Pages.TempDataSample
{

    //Im Default kann TempData nur einmalige Nachrichten übertragen.
    //-> Mit weiteren Methoden kann man auch mehrfach eine Nachricht übertragen

    //Wir können RazorPage übergreifen Informationen via TempData übermitteln (1x Nachrichten oder bei mehr Aufwand auch mehrmals)



    public class TempDataSampleStartModel : PageModel
    {
        public void OnGet()
        {
            
            TempData.Add("Email", "KevinW@ppedv.de");
        }
    }
}
