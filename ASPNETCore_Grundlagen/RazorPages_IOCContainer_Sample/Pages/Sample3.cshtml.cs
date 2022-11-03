using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages_IOCContainer_Sample.Services;

namespace RazorPages_IOCContainer_Sample.Pages
{
    public class Sample3Model : PageModel
    {
        public string CurrentTime { get; set; }

        //Zugriff via HttpContext 
        public void OnGet()
        {
            //Use Case -> Wenn z.b Files als Download vorhanden sind, können wir ein ICompressFileService hinzufügen

            //Kann mit gut verwenden, wenn gewisse Bedingungen vorhanden sind
            ITimeService? timeService = this.HttpContext.RequestServices.GetService<ITimeService>();

            ITimeService timeService2 = this.HttpContext.RequestServices.GetRequiredService<ITimeService>();
        }
    }
}
