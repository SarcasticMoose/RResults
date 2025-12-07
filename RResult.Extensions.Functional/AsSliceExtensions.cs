using System.Collections;
using System.Runtime.InteropServices;
using RResult.Shared.Options;
using RResult.Shared.Options.Ref;

namespace RResult.Extensions.Functional;

public static class AsSliceExtensions
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
    {
        return !opt.IsSome() ? ReadOnlySpan<T>.Empty : MemoryMarshal.CreateReadOnlySpan(ref opt._value, 1);
    }
    
    public static ReadOnlySpan<T> AsSlice<T>(this ref Option<T[]> opt)
    {
        return !opt.IsSome() ? ReadOnlySpan<T>.Empty : opt._value.AsSpan();
    }
    
    public static ReadOnlySpan<char> AsSlice(this ref Option<string> opt)
    {
        return !opt.IsSome() ? ReadOnlySpan<char>.Empty : opt._value.AsSpan();
    }
}