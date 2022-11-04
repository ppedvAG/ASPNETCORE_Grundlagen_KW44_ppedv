using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TagHelperSample.TagHelpers
{
    public static class MyHtmlTagHelper
    {
        public static IHtmlContent HelloWorldHTMLString(this IHtmlHelper htmlHelper)
            => new HtmlString("<strong>Hello World</strong>");

        public static string HelloWorldString(this IHtmlHelper htmlHelper)
        {
            return "<strong>Hello World</strong>";
        }

        /// <summary>
        /// Mit Paramter
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IHtmlContent HelloWord(this IHtmlHelper htmlHelper, string name)
        {
            //<span>Hello, Asterix!</span>
            var span = new TagBuilder("span");
            span.InnerHtml.Append("Hello, " + name + "!");

            //<br/>
            var br = new TagBuilder("br")
            {
                TagRenderMode = TagRenderMode.SelfClosing,
            };

            string result = string.Empty;

            using (StringWriter writer = new StringWriter())
            {
                span.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                br.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);

                result = writer.ToString();
            }

            return new HtmlString(result);
        }


        /// <summary>
        /// Mit Paramter
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IHtmlContent HelloWordWithComplexObject(this IHtmlHelper htmlHelper, MyPerson myPersonObject)
        {
            //<span>Hello, Asterix!</span>
            var span = new TagBuilder("span");
            span.InnerHtml.Append("Hello, " + myPersonObject.FirstName + " - " + myPersonObject.LastName + "!");

            //<br/>
            var br = new TagBuilder("br")
            {
                TagRenderMode = TagRenderMode.SelfClosing,
            };

            string result = string.Empty;

            using (var writer = new StringWriter())
            {
                span.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                br.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);

                result = writer.ToString();
            }

            return new HtmlString(result);
        }


        #region IOC Beispiel -> Siehe Methodenkommentar
        /// <summary>
        /// TagHelper mit Zugriff auf IOC Container -> movieContext = scope.ServiceProvider.GetService<SecondMovieDbContext>();
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        //public static IHtmlContent RenderTableWithDbContextService(this IHtmlHelper htmlHelper)
        //{
        //    //SecondMovieDbContext dbContext = htmlHelper.ViewContext.HttpContext.RequestServices.GetService<SecondMovieDbContext>();

        //    SecondMovieDbContext movieContext;
        //    string result = string.Empty;

        //    using (IServiceScope scope = htmlHelper.ViewContext.HttpContext.RequestServices.CreateScope())
        //    {
        //        movieContext = scope.ServiceProvider.GetService<SecondMovieDbContext>();

        //        using (var writer = new StringWriter())
        //        {
        //            foreach (Movie currentMovie in movieContext.Movie)
        //            {
        //                var span = new TagBuilder("span");
        //                span.InnerHtml.Append("Movie :" + currentMovie.Id + " - " + currentMovie.Title + " - " + currentMovie.Description + " - " + Enum.GetName(typeof(GenreTyp), currentMovie.Genre));

        //                //<br/>
        //                var br = new TagBuilder("br")
        //                {
        //                    TagRenderMode = TagRenderMode.SelfClosing,
        //                };


        //                span.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
        //                br.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
        //            }

        //            result = writer.ToString();
        //        }
        //    }
        //    return new HtmlString(result);
        //}
        #endregion
    }

    public class MyPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
