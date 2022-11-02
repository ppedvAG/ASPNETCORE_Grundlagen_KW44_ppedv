using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageSamples.Pages
{
    public class PageHandlerModel : PageModel
    {
        public string Einstieg { get; set; }

        //https://localhost:7053/PageHandler
        public void OnGet()
        {
            Einstieg = "OnGet wird aufgerufen";
        }

        //https://localhost:7053/PageHandler?handler=demo
        public void OnGetDemo()
        {
            Einstieg = "OnGetDemo";
        }

        //https://localhost:7053/PageHandler?handler=demowithparam&param=hello
        public void OnGetDemoWithParam(string param)
        {
            Einstieg = $"Page Handler with param {param}";
        }
    }
}
