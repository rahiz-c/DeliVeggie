using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace DeliVeggie.UI.Extensions
{
    public static class HtmlHelperExtensions
    {
        private const string Wwwroot = "wwwroot/";
        private static bool _staticFilesLoaded;
        private static IEnumerable<string> _cssFiles;
        private static IEnumerable<string> _jsFiles;

        public static IHtmlContent RenderPreloadScripts(this IHtmlHelper htmlHelper)
        {
            ArgumentNullException.ThrowIfNull(htmlHelper);

            LoadScripts();

            StringBuilder stBuilder = new StringBuilder();
            foreach (string css in _cssFiles) { _ = stBuilder.AppendLine($"<link href=\"/{css}\" rel=\"preload\" as=\"style\">"); }
            foreach (string js in _jsFiles) { _ = stBuilder.AppendLine($"<link href=\"/{js}\" rel=\"preload\" as=\"script\">"); }

            return new HtmlString(stBuilder.ToString());
        }

        public static IHtmlContent RenderCssFiles(this IHtmlHelper htmlHelper)
        {
            ArgumentNullException.ThrowIfNull(htmlHelper);

            LoadScripts();

            StringBuilder stBuilder = new StringBuilder();
            foreach (var css in _cssFiles) { _ = stBuilder.AppendLine($"<link href=\"/{css}\" rel=\"stylesheet\">"); }

            return new HtmlString(stBuilder.ToString());
        }

        public static IHtmlContent RenderJsFiles(this IHtmlHelper htmlHelper)
        {
            ArgumentNullException.ThrowIfNull(htmlHelper);

            LoadScripts();

            StringBuilder stBuilder = new StringBuilder();
            foreach (string js in _jsFiles) { _ = stBuilder.AppendLine($"<script src=\"/{js}\"></script>"); }

            return new HtmlString(stBuilder.ToString());
        }

        private static void LoadScripts()
        {
            if (_staticFilesLoaded) { return; }

            _jsFiles = Directory.GetFiles(Wwwroot, "*.js", SearchOption.AllDirectories).Select(s => s.Substring(Wwwroot.Length).Replace("\\", "/", StringComparison.InvariantCulture));
            _cssFiles = Directory.GetFiles(Wwwroot, "*.css", SearchOption.AllDirectories).Select(s =>  s.Substring(Wwwroot.Length).Replace("\\", "/", StringComparison.InvariantCulture));
            _staticFilesLoaded = true;
        }
    }
}
