using System.Runtime.InteropServices;
using RResult.Shared.Options;

namespace RResult.Extensions.Functional.Option;

public static class AsSliceExtensions
{
    /// <summary>
    /// Returns a <see cref="ReadOnlySpan{T}"/> containing the value when the option
    /// is <c>Some</c>; otherwise returns an empty span.
    /// </summary>
    /// <typeparam name="T">The type of the value stored inside the option.</typeparam>
    /// <param name="opt">The option instance to convert.</param>
    /// <returns>
    /// A <see cref="ReadOnlySpan{T}"/> of length 1 containing the value if the option is <c>Some</c>;
    /// otherwise, an empty <see cref="ReadOnlySpan{T}"/>.
    /// </returns>
    public static ReadOnlySpan<T> AsSlice<T>(this ref Option<T> opt)
    {
        return !opt.IsSome
            ? ReadOnlySpan<T>.Empty
            : MemoryMarshal.CreateReadOnlySpan(ref opt._value, 1);
    }

    /// <summary>
    /// Returns a <see cref="ReadOnlySpan{T}"/> over the array contained in the option
    /// if the option is <c>Some</c>; otherwise returns an empty span.
    /// </summary>
    /// <typeparam name="T">The element type of the array stored inside the option.</typeparam>
    /// <param name="opt">The option instance containing an array.</param>
    /// <returns>
    /// A <see cref="ReadOnlySpan{T}"/> spanning all elements of the array if the option is <c>Some</c>;
    /// otherwise, an empty <see cref="ReadOnlySpan{T}"/>.
    /// </returns>
    public static ReadOnlySpan<T> AsSlice<T>(this ref Option<T[]> opt)
    {
        return !opt.IsSome ? ReadOnlySpan<T>.Empty : opt._value.AsSpan();
    }

    /// <summary>
    /// Returns a <see cref="ReadOnlySpan{char}"/> over the string contained in the option
    /// if the option is <c>Some</c>; otherwise returns an empty span.
    /// </summary>
    /// <param name="opt">The option instance containing a string.</param>
    /// <returns>
    /// A <see cref="ReadOnlySpan{char}"/> over the string if the option is <c>Some</c>;
    /// otherwise, an empty <see cref="ReadOnlySpan{char}"/>.
    /// </returns>
    public static ReadOnlySpan<char> AsSlice(this ref Option<string> opt)
    {
        return !opt.IsSome ? ReadOnlySpan<char>.Empty : opt._value.AsSpan();
    }
}