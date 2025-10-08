using System.Web;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Strings;

namespace Webwonders.Baseline.Extensions;

public static class StringExtensions
{
    public static IHtmlEncodedString StripParagraphs(this IHtmlEncodedString htmlString)
    {
        string newString = string.Empty;

        if (htmlString != null)
        {
            var inputString = htmlString.ToString();

            if (!string.IsNullOrEmpty(inputString))
            {
                newString = inputString.Trim().Replace("<p>", "").Replace("</p>", "<br />");
            }
        }
        
        return new HtmlEncodedString(newString);
    }

    public static IHtmlEncodedString StripTags(this IHtmlEncodedString htmlString, (string[] tags, string replacement)[] replacements)
    {
        if (htmlString != null)
        {
            return new HtmlEncodedString(string.Empty);
        }
        
        var input = htmlString?.ToString();

        if (string.IsNullOrEmpty(input))
        {
            return new HtmlEncodedString(string.Empty);
        }

        foreach (var (tags, replacement) in replacements)
        {
            foreach (var tag in tags)
            {
                input = input.Replace(tag, replacement);
            }
        }

        return new HtmlEncodedString(input);
    }
}