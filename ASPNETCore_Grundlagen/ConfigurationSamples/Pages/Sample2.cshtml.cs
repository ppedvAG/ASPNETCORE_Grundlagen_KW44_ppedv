using ConfigurationSamples.Configurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace ConfigurationSamples.Pages
{
    //https://learn.microsoft.com/de-de/aspnet/core/fundamentals/configuration/options?view=aspnetcore-6.0
    public class Sample2Model : PageModel
    {
        public readonly GameSettings GameConfigSettings;

        public Sample2Model(IOptionsSnapshot<GameSettings> gameSettings)
        {
            GameConfigSettings = gameSettings.Value;
        }
        public void OnGet()
        {
        }
    }
}
