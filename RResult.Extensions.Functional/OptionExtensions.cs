using System.Runtime.InteropServices;
using RResult.Shared.Options;
using RResult.Shared.Options.Ref;

namespace RResult.Extensions.Functional;

public static class OptionExtensions
{
    /// <summary>
    /// Returns a <see cref="ReadOnlySpan{T}"/> containing the value when the option
    /// is <c>Some</c>; otherwise returns an empty span.
    /// </summary>
    /// <param name="opt">The option instance to convert.</param>
    /// <typeparam name="T">The value type stored inside the option.</typeparam>
    /// <returns>
    /// A span of length 1 containing the value if <c>Some</c>;
    /// otherwise an empty <see cref="ReadOnlySpan{T}"/>.
    /// </returns>
    public static ReadOnlySpan<T> AsSlice<T>(this ref Option<T> opt)
        => opt.IsSome()
            ? MemoryMarshal.CreateReadOnlySpan(ref opt._value, 1)
            : ReadOnlySpan<T>.Empty;
    
    /// <summary>
    /// Returns an <see cref="ImmutableOptionRef{T}"/> wrapper around the contained value.
    /// The wrapper provides read-only access to the value if <c>Some</c>;
    /// returns <c>default</c> if the option is <c>None</c>.
    /// </summary>
    public static ImmutableOptionRef<T> AsRef<T>(ref this Option<T> opt)
        where T : struct
        => opt.IsSome() ? ImmutableOptionRef<T>.Create(ref opt._value) : default;

    /// <summary>
    /// Returns a <see cref="MutableOptionRef{T}"/> wrapper around the contained value.
    /// The wrapper provides mutable access to the value if <c>Some</c>;
    /// returns <c>default</c> if the option is <c>None</c>.
    /// Only works for value types.
    /// </summary>
    public static MutableOptionRef<T> AsMut<T>(ref this Option<T> opt) 
        where T : struct
        => opt.IsSome() ? MutableOptionRef<T>.Create(ref opt._value) : default;
    
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