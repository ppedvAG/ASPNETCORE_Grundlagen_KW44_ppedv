using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PictureUploadAndGallery.Pages
{
    public class UploadFileModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost(IFormFile datei)
        {
            FileInfo fileInfo = new FileInfo(datei.FileName);

            string absoluteSavePath = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images\" + fileInfo.Name;

            using (FileStream fs = new FileStream(absoluteSavePath, FileMode.Create))
            {
                datei.CopyTo(fs);
            }

            return RedirectToPage("UploadFile");
        }
    }
}
