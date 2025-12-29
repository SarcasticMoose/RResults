using System.Text;
using System.Text.Json;

namespace RResult.Shared.Results.Errors.Extensions;

public static class ErrorExtensions
{
    /// <summary>
    /// Returns a human-readable string representation of the <see cref="BaseError"/>,
    /// including its message, arguments, and any nested errors.
    /// </summary>
    /// <param name="error">The error instance to convert to string.</param>
    /// <returns>A string representation of the error.</returns>
    internal static string ToReadableString(this IError? error)
    {
        return error == null ? string.Empty : JsonSerializer.Serialize(error, new JsonSerializerOptions { WriteIndented = true });
    }
}