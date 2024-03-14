using System.Text;

namespace NightlifeCoordinationAPI.Helpers.QueryStringBuilder;

public class QueryStringBuilder
{
    private StringBuilder Query { get; set; }

    public QueryStringBuilder()
    {
        Query = new StringBuilder();
    }

    public string Get()
    {
        return Query.ToString();
    }

    public void AppendParam(string parameter, string? s)
    {
        char separator = GetSeparator();

        if (!string.IsNullOrEmpty(s))
            Query.Append($"{separator}{parameter}={Uri.EscapeDataString(s)}");
    }

    public void AppendParam<T>(string parameter, T? value)
    where T : struct
    {
        char separator = GetSeparator();

        if (value != null)
            Query.Append($"{separator}{parameter}={value}");
    }

    public void AppendParam<T>(string parameter, T[]? array)
    {
        char separator = GetSeparator();

        if (array != null && array.Length > 0)
        {
            string sArray = string.Join(",", array);
            Query.Append($"{separator}{parameter}={Uri.EscapeDataString(sArray)}");
        }
    }

    private char GetSeparator()
    {
        return Query.Length > 0 ? '&' : '?';
    }
}
