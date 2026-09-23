
using System.Text;
using System.Text.Json;

namespace FingerprintPro.ServerSdk.Api;

public abstract class OperationDefinition
{
    public abstract string Path { get; }

    public abstract string OperationName { get; }

    public abstract string[] PathParams { get; }

    public abstract Dictionary<int, Type> ResponseStatusCodeMap { get; }

    public string GetPath(params string[]? args)
    {
        var path = Path;

        if (args == null) return path;

        for (var i = 0; i < args.Length; i++)
        {
            var placeholder = PathParams[i];

            path = path.Replace("{" + placeholder + "}", EncodePathParam(placeholder, args[i]));
        }

        return path;
    }

    /// <summary>
    /// Encodes a path parameter.
    /// </summary>
    /// <param name="placeholder">Placeholder the value is substituted for, such as <c>request_id</c>.</param>
    /// <param name="value">Path parameter raw value.</param>
    /// <exception cref="ArgumentException">Thrown when the value is empty or is a dot segment.</exception>
    private static string EncodePathParam(string placeholder, string value)
    {
        var name = ArgumentName(placeholder);

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{name} is not set", name);
        }

        if (value == "." || value == "..")
        {
            throw new ArgumentException($"{name} is not valid: {value}", name);
        }

        return Uri.EscapeDataString(value);
    }

    /// <summary>
    /// Maps a placeholder to the argument it comes from, so that errors name what the caller passed.
    /// </summary>
    private static string ArgumentName(string placeholder)
    {
        var name = new StringBuilder(placeholder.Length);

        for (var i = 0; i < placeholder.Length; i++)
        {
            if (placeholder[i] == '_' && i + 1 < placeholder.Length)
            {
                name.Append(char.ToUpperInvariant(placeholder[++i]));
            }
            else
            {
                name.Append(placeholder[i]);
            }
        }

        return name.ToString();
    }
}
