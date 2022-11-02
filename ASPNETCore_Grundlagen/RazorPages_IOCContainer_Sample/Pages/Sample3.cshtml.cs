using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages_IOCContainer_Sample.Services;

namespace RazorPages_IOCContainer_Sample.Pages
{
    public class Sample3Model : PageModel
    {
        public string CurrentTime { get; set; }


        public void OnGet()
        {
            ITimeService? timeService = this.HttpContext.RequestServices.GetService<ITimeService>();

            ITimeService timeService2 = this.HttpContext.RequestServices.GetRequiredService<ITimeService>();
        }
    }
}
