using RResult.Shared.Options;
using RResult.Shared.Options.Ref;

namespace RResult.Extensions.Functional.Option;

public static class AsRefExtensions
{
    /// <summary>
    /// Returns an <see cref="ImmutableOptionRef{T}"/> wrapper around the contained value.
    /// The wrapper provides read-only access to the value if <c>Some</c>;
    /// returns <c>default</c> if the option is <c>None</c>.
    /// </summary>
    public static ImmutableOptionRef<T> AsRef<T>(ref this Option<T> opt)
        where T : struct
        => opt.IsSome() ? ImmutableOptionRef<T>.Create(ref opt._value) : default;
}