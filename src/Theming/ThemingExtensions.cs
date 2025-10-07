using System.Drawing;
using Umbraco.Extensions;
using Webwonders.Baseline.Extensions.Helpers;
namespace Webwonders.Baseline.Extensions.Theming;

public class ThemingExtensions
{
    public static string ConvertHexToHsl(string? hexColor, string? hexColorOverwrite, string cssVariable)
    {
        if (hexColorOverwrite != null && !hexColorOverwrite.IsNullOrWhiteSpace())
        {
            var aHSLcode = ColorHelpers.HexToHsl(new HEX(hexColorOverwrite)).ToString().Replace("°", "");
            var cssString = cssVariable + ":" + aHSLcode;
            return cssString;
        }
        else if (hexColor != null && !hexColor.IsNullOrWhiteSpace())
        {
            var aHSLcode = ColorHelpers.HexToHsl(new HEX(hexColor)).ToString().Replace("°", "");
            var cssString = cssVariable + ":" + aHSLcode;
            return cssString;
        }
        else
        {
            return string.Empty;
        }
    }

    public static string SetThemeVariables(string defaultSetting, string overwriteSetting, string cssVariable)
    {
        if (!overwriteSetting.IsNullOrWhiteSpace())
        {
            var cssString = cssVariable + ":" + overwriteSetting;
            return cssString;
        }
        else if (defaultSetting != null && !defaultSetting.IsNullOrWhiteSpace())
        {
            var cssString = cssVariable + ":" + defaultSetting;
            return cssString;
        }
        else
        {
            return string.Empty;
        }
    }
}