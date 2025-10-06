using System.Web;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Strings;

namespace Webwonders.Framework.Extensions;

public class StringExtensions
{

    private readonly Dictionary<string, string> _replacements;

    public StringExtensions(IOptions<HtmlTagReplacementOptions> options)
    {
        _replacements = options.Value.Replacements;
    }
    
    public virtual IHtmlEncodedString StripParagraphs(IHtmlEncodedString htmlString)
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

    public virtual IHtmlEncodedString StripTags(IHtmlEncodedString htmlString)
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

        foreach (var pair in _replacements)
        {
            input = input.Replace(pair.Key, pair.Value);
        }

        return new HtmlEncodedString(input);
    }
}