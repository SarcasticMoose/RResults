using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using RResults.Core.Options.Ref;

namespace RResults.Core.Options;

/// <summary>
/// Represents an optional value: every <see cref="Option{T}"/> is either <c>Some</c> and contains a value,
/// or <c>None</c> and contains no value.
/// </summary>
/// <typeparam name="T">The type of the contained value.</typeparam>
public struct Option<T>
{
    internal T _value;
    internal readonly bool _isSome;
    
    /// <summary>
    /// Creates an <see cref="Option{T}"/> that contains a value.
    /// This represents the <c>Some</c> variant, meaning the option has a value.
    /// </summary>
    /// <param name="value">The value to wrap in the option.</param>
    /// <returns>An <see cref="Option{T}"/> containing the given value.</returns>
    public static Option<T> Some(T value) => new(value);
    
    /// <summary>
    /// Returns an <see cref="Option{T}"/> representing the <c>None</c> variant,
    /// meaning the option has no value.
    /// </summary>
    /// <returns>An <see cref="Option{T}"/> with no value.</returns>
    public static Option<T> None => default;
    
    internal Option(T value)
    {
        _value = value;
        _isSome = true;
    }
    
    /// <inheritdoc cref="OptionLogic.IsSome"/>
    public bool IsSome() => OptionLogic.IsSome(_isSome);

    /// <inheritdoc cref="OptionLogic.IsNone"/>
    public bool IsNone() => OptionLogic.IsNone(_isSome);
    
    /// <inheritdoc cref="OptionLogic.UnwrapOrPanic"/>
    public T UnwrapOrPanic() => OptionLogic.UnwrapOrPanic(_isSome, _value);
    
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
    public ReadOnlySpan<T> AsSlice()
        => IsSome()
            ? MemoryMarshal.CreateReadOnlySpan(ref _value, 1)
            : ReadOnlySpan<T>.Empty;
    
    /// <summary>
    /// Returns an <see cref="ImmutableOptionRef{T}"/> wrapper around the contained value.
    /// The wrapper provides read-only access to the value if <c>Some</c>;
    /// returns <c>default</c> if the option is <c>None</c>.
    /// </summary>
    public ImmutableOptionRef<T> AsRef()
        => IsSome() ? ImmutableOptionRef<T>.Create(ref Unsafe.AsRef(ref _value)) : default;

    /// <summary>
    /// Returns a <see cref="MutableOptionRef{T}"/> wrapper around the contained value.
    /// The wrapper provides mutable access to the value if <c>Some</c>;
    /// returns <c>default</c> if the option is <c>None</c>.
    /// </summary>
    public MutableOptionRef<T> AsMut()
        => IsSome() ? MutableOptionRef<T>.Create(ref Unsafe.AsRef(ref _value)) : default;

}