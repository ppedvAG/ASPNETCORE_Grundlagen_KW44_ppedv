using LocalizationCultureSampe1.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;

namespace LocalizationCultureSampe1.ViewComponents
{

    public class CultureSwitcherViewComponent :ViewComponent
    {
        private readonly IOptions<RequestLocalizationOptions> localizationOptions;

        //ViewComponentes haben die Möglichkeit auf den IOC Container zuzugreifen -> Via Konstruktor-Injection
        //Oder via  HttpContext.RequestServices.GetService
        public CultureSwitcherViewComponent(IOptions<RequestLocalizationOptions> localizationOptions)
        {
            this.localizationOptions = localizationOptions;
        }

        public IViewComponentResult Invoke()
        {
            IRequestCultureFeature cultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();

            CultureSwitcherModel model = new CultureSwitcherModel
            {
                SupportedCultures = localizationOptions.Value.SupportedCultures.ToList(),
                CurrentUICulture = cultureFeature.RequestCulture.UICulture
            };

            return View(model);
        }
    }
}
