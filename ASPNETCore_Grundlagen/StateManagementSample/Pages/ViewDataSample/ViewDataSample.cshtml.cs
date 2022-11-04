using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StateManagementSample.Pages.ViewDataSample
{
    public class ViewDataSampleModel : PageModel
    {
        
        public void OnGet()
        {
            //Dictionary<int, string> dict = new Dictionary<int, string>();

            //IDictionary<int, string> dict1 = new Dictionary<int, string>();

            ViewData.Add("Email", "KevinW@ppedv");
            ViewData["Name"] = "Scott Hanselmann";


        }
    }
}
