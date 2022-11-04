using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PictureUploadAndGallery.Pages
{
    public class Gallery2Model : PageModel
    {
        public List<string> Bilder { get; set; }

        public void OnGet()
        {
            //wwwroot\Images
            string pfad = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images";

            string[] allFiles = Directory.GetFiles(pfad);

            if (Bilder == null)
                Bilder = new List<string>();

            Bilder.AddRange(allFiles);
        }
    }
}
