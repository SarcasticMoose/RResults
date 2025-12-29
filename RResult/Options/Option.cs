namespace RResult.Options;

/// <summary>
/// Represents an optional value: every <see cref="Option{T}"/> is either <c>Some</c> and contains a value,
/// or <c>None</c> and contains no value.
/// </summary>
/// <typeparam name="T">The type of the contained value.</typeparam>
public readonly struct Option<T>
{
    internal readonly T _value;
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
    public static Option<T> None => new();

    private Option(T value)
    {
        _value = value;
        _isSome = value != null;
    }
    
    private Option(bool _)
    {
        _value = default!;
        _isSome = false;
    }
    
    /// <summary>
    /// Returns <c>true</c> if the option contains a value (i.e., is the <c>Some</c> variant).
    /// </summary>
    /// <returns><c>true</c> if this option has a value; otherwise, <c>false</c>.</returns>
    public bool IsSome => _isSome;
    
    /// <summary>
    /// Returns <c>true</c> if the option contains a value (i.e., is the <c>Some</c> variant).
    /// </summary>
    /// <returns><c>true</c> if this option has a value; otherwise, <c>false</c>.</returns>
    public bool IsNone => !IsSome;
    
    /// <summary>
    /// Returns the contained value if this <see cref="Option{T}"/> is <c>Some</c>.
    /// Throws an <see cref="InvalidOperationException"/> if the option is <c>None</c>.
    /// </summary>
    /// <returns>The value contained in the option.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the option is <c>None</c>.</exception>
    public T UnwrapOrThrow()
    {
        OptionExtensions.EnsureSome(IsSome);
        return _value;
    }
    
    public TResult Match<TResult>(
        Func<T, TResult> some,
        Func<TResult> none)
    {
        return IsSome
            ? some(_value!)
            : none();
    }
}
