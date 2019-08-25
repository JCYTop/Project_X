using UnityEngine;

public static class ColorExtension
{
    /// <summary>
    /// #C5563CFF -> 197.0f / 255,86.0f / 255,60.0f / 255
    /// </summary>
    /// <param name="htmlString"></param>
    /// <returns></returns>
    public static Color HtmlStringToColor(this string htmlString)
    {
        Color retColor;
        var parseSucceed = ColorUtility.TryParseHtmlString(htmlString, out retColor);
        return parseSucceed ? retColor : Color.black;
    }
}