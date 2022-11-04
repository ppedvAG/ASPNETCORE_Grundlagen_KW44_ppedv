using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StateManagementSample.Pages
{
    public class CachingSampleModel : PageModel
    {
        
        public DateTime CurrentTime { get; set; }

        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        public void OnGet()
        {
            CurrentTime = DateTime.Now;
        }
    }
}
