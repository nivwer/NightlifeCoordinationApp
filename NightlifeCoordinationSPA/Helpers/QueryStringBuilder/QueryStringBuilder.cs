using System.Text;

namespace NightlifeCoordinationSPA.Helpers.QueryStringBuilder;

/// <summary>
/// Helper class for building query strings for URLs.
/// </summary>
public class QueryStringBuilder
{
    private StringBuilder Query { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="QueryStringBuilder"/> class.
    /// </summary>
    public QueryStringBuilder()
    {
        Query = new StringBuilder();
    }

    /// <summary>
    /// Gets the constructed query string.
    /// </summary>
    /// <returns>The constructed query string.</returns>
    public string Get()
    {
        return Query.ToString();
    }

    /// <summary>
    /// Appends a parameter with a string value to the query string.
    /// </summary>
    /// <param name="parameter">The parameter name.</param>
    /// <param name="s">The string value.</param>
    public void AppendParam(string parameter, string? s)
    {
        char separator = GetSeparator();

        if (!string.IsNullOrWhiteSpace(s))
            Query.Append($"{separator}{parameter}={Uri.EscapeDataString(s)}");
    }

    /// <summary>
    /// Appends a parameter with a value of a struct type to the query string.
    /// </summary>
    /// <param name="parameter">The parameter name.</param>
    /// <param name="value">The value of the parameter.</param>
    /// <typeparam name="T">The type of the value.</typeparam>
    public void AppendParam<T>(string parameter, T value)
    where T : struct
    {
        char separator = GetSeparator();
        Query.Append($"{separator}{parameter}={value}");
    }

    /// <summary>
    /// Appends a parameter with a nullable value of a struct type to the query string.
    /// </summary>
    /// <param name="parameter">The parameter name.</param>
    /// <param name="value">The nullable value of the parameter.</param>
    /// <typeparam name="T">The type of the value.</typeparam>
    public void AppendParam<T>(string parameter, T? value)
    where T : struct
    {
        char separator = GetSeparator();

        if (value != null)
            Query.Append($"{separator}{parameter}={value}");
    }

    /// <summary>
    /// Appends a parameter with a collection of string values to the query string.
    /// </summary>
    /// <param name="parameter">The parameter name.</param>
    /// <param name="enumerable">The collection of string values.</param>
    /// <param name="useMultipleValues">Specifies whether to use multiple keys for the same parameter.</param>
    public void AppendParam(string parameter, IEnumerable<string>? enumerable, bool useMultipleValues = true)
    {
        if (enumerable != null && enumerable.Any())
        {
            if (useMultipleValues)
            {
                foreach (var s in enumerable)
                {
                    AppendParam(parameter, s);
                }
            }
            else
            {
                char separator = GetSeparator();
                string sArray = string.Join(",", enumerable.Select(Uri.EscapeDataString));
                Query.Append($"{separator}{parameter}={sArray}");
            }
        }
    }

    /// <summary>
    /// Appends a parameter with a collection of values of a struct type to the query string.
    /// </summary>
    /// <param name="parameter">The parameter name.</param>
    /// <param name="enumerable">The collection of values of the struct type.</param>
    /// <param name="useMultipleValues">Specifies whether to use multiple keys for the same parameter.</param>
    /// <typeparam name="T">The type of the value.</typeparam>
    public void AppendParam<T>(string parameter, IEnumerable<T>? enumerable, bool useMultipleValues = true)
    where T : struct
    {
        if (enumerable != null && enumerable.Any())
        {
            if (useMultipleValues)
            {
                foreach (var v in enumerable)
                {
                    AppendParam(parameter, v);
                }
            }
            else
            {
                char separator = GetSeparator();
                string sArray = string.Join(",", enumerable.Select(x => x.ToString()));
                Query.Append($"{separator}{parameter}={sArray}");
            }
        }
    }

    /// <summary>
    /// Gets the separator character based on the current state of the query string.
    /// </summary>
    /// <returns>The separator character.</returns>
    private char GetSeparator()
    {
        return Query.Length > 0 ? '&' : '?';
    }
}
