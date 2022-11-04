using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelperSample.TagHelpers
{
    //Wird benötigt -> @addTagHelper *, ASPNETCore_RazorPages
    public class WebsiteInformationTagHelper : TagHelper
    {
        public WebsiteContext Info { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "section";

            output.Content.SetHtmlContent(
             $@"<ul><li><strong>Version:</strong> {Info.Version}</li>
                <li><strong>Copyright Year:</strong> {Info.CopyrigthYear}</li>
                <li><strong>Approved:</strong> {Info.Approved}</li>
                <li><strong>Number of tags to show:</strong> {Info.TagsToShow}</li></ul>");

            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }

    ////Kein Zugriff auf IOC
    //public class LockArroundTagHelper : TagHelper
    //{
    //    private readonly SecondMovieDbContext _dbContext;


    //    public LockArroundTagHelper(SecondMovieDbContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //    }


    //    public override void Process(TagHelperContext context, TagHelperOutput output)
    //    {

    //    }
    //}


    public class WebsiteContext
    {
        public Version Version { get; set; }
        public int CopyrigthYear { get; set; }

        public bool Approved { get; set; }

        public int TagsToShow { get; set; }
    }
}
