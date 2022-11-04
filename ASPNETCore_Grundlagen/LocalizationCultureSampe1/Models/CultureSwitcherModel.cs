using System.Globalization;

namespace LocalizationCultureSampe1.Models
{
    public class CultureSwitcherModel
    {
        //Aktuell selektierte Culture
        public CultureInfo CurrentUICulture { get; set; }

        public List<CultureInfo> SupportedCultures { get; set; }
    }
}
