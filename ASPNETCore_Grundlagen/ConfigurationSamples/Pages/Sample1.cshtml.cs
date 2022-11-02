using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConfigurationSamples.Pages
{
    //https://learn.microsoft.com/de-de/aspnet/core/fundamentals/configuration/options?view=aspnetcore-6.0
    public class Sample1Model : PageModel
    {
        private readonly IConfiguration configuration;
        
        //ctor + tab + tab -> Constructor 

        //Konstrutkor Injection -> lesen aus IOC Container -> IConfiguration heraus
        public Sample1Model(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
        //Ergebnis werden wir ohne HTML Markup anzeigen -> einfache String-Ausgabe
        public ContentResult OnGet()
        {
            string myKeyValue = configuration["MyKey"];

            string title = configuration["Position:Title"];

            string name = configuration["Position:Name"];

            string defaultLogging = configuration["Logging:LogLevel:Default"];


            return Content($"MyKey value: {myKeyValue} \n" +
                $"Title: {title} \n" +
                $"Name: {name} \n" +
                $"Log-Level: {defaultLogging}");
        }
    }
}
