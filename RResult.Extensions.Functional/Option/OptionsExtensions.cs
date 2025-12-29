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
        => opt.IsSome ? opt._value : throw new InvalidOperationException(message);
    
    /// <summary>
    /// Performs pattern matching on an <see cref="Option{T}"/> instance,
    /// executing one of the provided functions depending on whether the option contains a value.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the option.</typeparam>
    /// <typeparam name="TResult">The return type of the matching functions.</typeparam>
    /// <param name="option">The option to match on.</param>
    /// <param name="some">The function to execute if the option contains a value (`Some`).</param>
    /// <param name="none">The function to execute if the option contains no value (`None`).</param>
    public static TResult Match<T, TResult>(
        this Option<T> option,
        Func<T, TResult> some,
        Func<TResult> none)
            => option._isSome ? some(option._value) : none();
}