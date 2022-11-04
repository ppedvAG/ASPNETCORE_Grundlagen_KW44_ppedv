using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StateManagementSample.Pages.ViewBagSample
{
    public class ViewBagSampleModel : PageModel
    {
        //ViewBag verwenden intern die ViewData
        public void OnGet()
        {
            ViewData["Email"] = "KevinW@ppedv";
        }
    }
}
