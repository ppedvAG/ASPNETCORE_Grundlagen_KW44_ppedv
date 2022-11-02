using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageSamples.Pages
{
    public class QueryStringSample2Model : PageModel
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }

        public void OnGet(string name, int year, int month)
        {
            Name = name;
            Year = year;
            Month = month;
        }
    }
}
