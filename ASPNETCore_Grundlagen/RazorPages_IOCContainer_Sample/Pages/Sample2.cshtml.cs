using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages_IOCContainer_Sample.Services;

namespace RazorPages_IOCContainer_Sample.Pages
{
    public class Sample2Model : PageModel
    {
        public string CurrentTime { get; set; }

        public void OnGet([FromServices] ITimeService timeService)
        {
            CurrentTime = timeService.GetCurrentTime();
        }
    }
}
