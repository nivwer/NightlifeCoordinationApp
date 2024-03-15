using System.Text;

namespace NightlifeCoordinationSPA.Helpers.QueryStringBuilder;

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

        if (!string.IsNullOrWhiteSpace(s))
            Query.Append($"{separator}{parameter}={Uri.EscapeDataString(s)}");
    }

    public void AppendParam<T>(string parameter, T value)
    where T : struct
    {
        char separator = GetSeparator();
        Query.Append($"{separator}{parameter}={value}");
    }

    public void AppendParam<T>(string parameter, T? value)
    where T : struct
    {
        char separator = GetSeparator();

        if (value != null)
            Query.Append($"{separator}{parameter}={value}");
    }

    public void AppendParam(string parameter, IEnumerable<string>? enumerable)
    {
        char separator = GetSeparator();

        if (enumerable != null && enumerable.Any())
        {
            string sArray = string.Join(",", enumerable);
            Query.Append($"{separator}{parameter}={Uri.EscapeDataString(sArray)}");
        }
    }

    public void AppendParam<T>(string parameter, IEnumerable<T>? enumerable)
    where T : struct
    {
        char separator = GetSeparator();

        if (enumerable != null && enumerable.Any())
        {
            string sArray = string.Join(",", enumerable);
            Query.Append($"{separator}{parameter}={Uri.EscapeDataString(sArray)}");
        }
    }

    private char GetSeparator()
    {
        return Query.Length > 0 ? '&' : '?';
    }
}
