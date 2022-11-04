using LocalizationCultureSampe1.Ressources;
using Microsoft.Extensions.Localization;
using System.Reflection;

namespace LocalizationCultureSampe1.Services
{
    public class CommonLocalizationService
    {
        private readonly IStringLocalizer localizer;

        public CommonLocalizationService(IStringLocalizerFactory factory)
        {
            AssemblyName assemblyName = new AssemblyName(typeof(CommonResources).GetTypeInfo().Assembly.FullName);
            localizer = factory.Create(nameof(CommonResources), assemblyName.Name);
        }

        /// <summary>
        ///Verwenden Ressource-Files und lesen die jeweilige Sprachtext aus. 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            return localizer[key];
        }
    }
}
