namespace RResult.Shared.Options;

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
}
