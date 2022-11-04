using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityUISample.Pages
{
    [AllowAnonymous]
    public class EveryUserModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
