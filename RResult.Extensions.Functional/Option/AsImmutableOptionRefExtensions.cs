using RResult.Extensions.Functional.Option.RefFunc;
using RResult.Shared.Options;
using RResult.Shared.Options.Ref;

namespace RResult.Extensions.Functional.Option;

public static class AsImmutableOptionRefExtensions
{
    /// <summary>
    /// Returns an <see cref="ImmutableOptionRef{T}"/> wrapper around the contained value.
    /// The wrapper provides read-only access to the value if <c>Some</c>;
    /// returns <c>default</c> if the option is <c>None</c>.
    /// </summary>
    public static ImmutableOptionRef<T> AsImmutable<T>(this in Option<T> opt)
        where T : struct
            => opt.IsSome ? ImmutableOptionRef<T>.Create(in opt._value) : default;
    
    /// <summary>
    /// Performs pattern matching on an <see cref="ImmutableOptionRef{T}"/> instance,
    /// executing one of the provided functions depending on whether the option contains a value.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the option.</typeparam>
    /// <typeparam name="TResult">The return type of the matching functions.</typeparam>
    /// <param name="option">The option to match on.</param>
    /// <param name="some">The function to execute if the option contains a value (`Some`).</param>
    /// <param name="none">The function to execute if the option contains no value (`None`).</param>
    public static TResult Match<T, TResult>(
        this ImmutableOptionRef<T> option,
        ImmutableRefFunc<T, TResult> some,
        ImmutableRefFunc<TResult> none)
            =>  option._isSome ? some(in option._value) : none();
}