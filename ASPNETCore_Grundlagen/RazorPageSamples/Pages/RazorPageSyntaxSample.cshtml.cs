using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageSamples.Models;

namespace RazorPageSamples.Pages
{
    public class RazorPageSyntaxSampleModel : PageModel
    {
        public string Username { get; set; }
        public Person[] Peoples { get; set; }   


        public void OnGet()
        {
            Username = "Max Muster";
            Peoples = new Person[]
            {
                new Person("Max", 21),
                new Person("Sandra", 31),
                new Person("Otto Walkes", 52)
            };
        }
    }
}
