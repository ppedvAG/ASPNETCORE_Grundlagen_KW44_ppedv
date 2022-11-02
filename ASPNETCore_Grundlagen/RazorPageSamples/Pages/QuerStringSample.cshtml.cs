using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageSamples.Pages
{
    public class QuerStringSampleModel : PageModel
    {
        public int Id { get; set; }


        //https://localhost:7053/QuerStringSample?id=123
        public void OnGet(int id)
        {
            Id = id;
        }

        
    }
}
