using System.Globalization;
using System.Linq;
using TinyPinyin;

namespace Screenbox.Core.Helpers;

public static class MediaGroupingHelpers
{
    public const string GroupHeaders = "&#ABCDEFGHIJKLMNOPQRSTUVWXYZ\u2026";

    public const string OtherGroupSymbol = "\u2026";

    public static string GetFirstLetterGroup(string name)
    {
        if (string.IsNullOrEmpty(name)) return OtherGroupSymbol;
        char letter = char.ToUpper(name[0], CultureInfo.CurrentCulture);
        if ("ABCDEFGHIJKLMNOPQRSTUVWXYZ".Contains(letter))
            return letter.ToString();
        if (PinyinHelper.IsChinese(letter)) return PinyinHelper.GetPinyin(letter)?[0].ToString() ?? OtherGroupSymbol;
        if (char.IsNumber(letter)) return "#";
        if (char.IsSymbol(letter) || char.IsPunctuation(letter) || char.IsSeparator(letter)) return "&";
        return OtherGroupSymbol;
    }
}
