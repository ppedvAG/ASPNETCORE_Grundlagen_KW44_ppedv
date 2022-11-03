using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPage_Scaffolded_PartialViews_HTMLHelper_TagHelper.TagHelpers
{
    //HTML-TagHelper wird mit Extention-Methoden erweitert
    public static class MyHtmlTagHelper
    {
        public static IHtmlContent HelloWorldHtmlString(this IHtmlHelper htmlHelper)
            => new HtmlString("<strong>Hello World</strong>");

        public static string HelloWorldString(this IHtmlHelper htmlHelper)
        {
            return "<strong>Hello World</strong>";
        }

        public static IHtmlContent HelloWorld(this IHtmlHelper htmlHelper, string name)
        {
            TagBuilder span = new TagBuilder("span");

            span.InnerHtml.Append("Hello " + name);

            TagBuilder br = new TagBuilder("br") { TagRenderMode = TagRenderMode.SelfClosing }; // <br/>

            string result;

            using (StringWriter writer = new StringWriter())
            {
                span.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                br.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);

                result = writer.ToString();
            }

            return new HtmlString(result);
        }

    }
}
