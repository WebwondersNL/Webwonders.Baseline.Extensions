namespace Webwonders.Framework.Extensions;

public class HtmlTagReplacementOptions
{
    public Dictionary<string, string> Replacements { get; set; } = new Dictionary<string, string>
    {
        { "<p>", "" },
        { "</p>", "<br />" },
        { "<br>", "" },
        { "<br/>", "" },
        { "<br />", "" },
        { "<div>", "" },
        { "</div>", "" },
        { "<span>", "" },
        { "</span>", "" }
    };
}