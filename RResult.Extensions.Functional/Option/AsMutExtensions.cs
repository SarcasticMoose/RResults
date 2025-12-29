using RResult.Shared.Options;
using RResult.Shared.Options.Ref;

namespace RResult.Extensions.Functional.Option;

public static class AsMutExtensions
{
    /// <summary>
    /// Returns a <see cref="MutableOptionRef{T}"/> wrapper around the contained value.
    /// The wrapper provides mutable access to the value if <c>Some</c>;
    /// returns <c>default</c> if the option is <c>None</c>.
    /// Only works for value types.
    /// </summary>
    public static MutableOptionRef<T> AsMut<T>(ref this Option<T> opt) 
        where T : struct
        => opt.IsSome() ? MutableOptionRef<T>.Create(ref opt._value) : default;
}