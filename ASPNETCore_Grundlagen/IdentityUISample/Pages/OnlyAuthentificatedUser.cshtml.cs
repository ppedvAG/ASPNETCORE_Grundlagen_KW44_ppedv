using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityUISample.Pages
{
    [Authorize()]
    public class OnlyAuthentificatedUserModel : PageModel
    {
        public void OnGet()
        {
            
        }
    }
}
