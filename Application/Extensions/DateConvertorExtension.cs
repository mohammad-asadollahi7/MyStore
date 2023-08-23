
namespace Application.Extensions;

public static class DateConvertorExtension
{
    public static string DateConvertor(this string date)
    {
        var year = date.Substring(0, 4);
        var month = date.Substring(4, 2);
        var day = date.Substring(6, 2);
        var result = string.Concat(year, "/", month, "/",day);
        return result;
    }
}
