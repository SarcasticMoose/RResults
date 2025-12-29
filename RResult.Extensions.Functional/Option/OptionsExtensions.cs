using RResult.Shared.Options;

namespace RResult.Extensions.Functional.Option;

public static class OptionsExtensions
{
    /// <summary>
    /// Returns the contained value if the <see cref="Option{T}"/> is <c>Some</c>.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the option.</typeparam>
    /// <param name="opt">The option instance to extract the value from.</param>
    /// <param name="message">The error message used if the option is <c>None</c>.</param>
    /// <returns>The contained value if <c>Some</c>.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the option is <c>None</c>.</exception>
    public static T Expect<T>(this Option<T> opt, string message)
        => opt.IsSome() ? opt._value : throw new InvalidOperationException(message);
}