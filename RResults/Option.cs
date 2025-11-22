namespace RResults;

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

    /// <summary>
    /// Returns <c>true</c> if the option contains a value (i.e., is the <c>Some</c> variant).
    /// </summary>
    /// <returns><c>true</c> if this option has a value; otherwise, <c>false</c>.</returns>
    public bool IsSome() => _isSome;
    
    /// <summary>
    /// Returns <c>true</c> if the option contains a value (i.e., is the <c>Some</c> variant).
    /// </summary>
    /// <returns><c>true</c> if this option has a value; otherwise, <c>false</c>.</returns>
    public bool IsNone() => !_isSome;
    
    /// <summary>
    /// Returns the contained value if this <see cref="Option{T}"/> is <c>Some</c>.
    /// Throws an <see cref="InvalidOperationException"/> if the option is <c>None</c>.
    /// </summary>
    /// <returns>The value contained in the option.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the option is <c>None</c>.</exception>
    public T UnwrapOrPanic() => IsSome() ? _value : throw new InvalidOperationException("Option is None");
}