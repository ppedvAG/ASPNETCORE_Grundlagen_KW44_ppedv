using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages_IOCContainer_Sample.Services;

namespace RazorPages_IOCContainer_Sample.Pages
{
    public class Sample1Model : PageModel
    {

        public string CurrentTime { get; set; }

        //Constructor Injection - > IOC Container gibt eine Instanz von TimeService
        public Sample1Model(ITimeService timeService) 
        {
            CurrentTime = timeService.GetCurrentTime();
        }


        public void OnGet()
        {
        }
    }
}
