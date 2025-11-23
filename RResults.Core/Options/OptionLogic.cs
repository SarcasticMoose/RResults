namespace RResults.Core.Options;

internal static class OptionLogic
{
    /// <summary>
    /// Returns <c>true</c> if the option contains a value (i.e., is the <c>Some</c> variant).
    /// </summary>
    /// <returns><c>true</c> if this option has a value; otherwise, <c>false</c>.</returns>
    public static bool IsSome(bool isSome) => isSome;
    
    /// <summary>
    /// Returns <c>true</c> if the option contains a value (i.e., is the <c>Some</c> variant).
    /// </summary>
    /// <returns><c>true</c> if this option has a value; otherwise, <c>false</c>.</returns>
    public static bool IsNone(bool isSome) => !isSome;

    /// <summary>
    /// Returns the contained value if this <see cref="Option{T}"/> is <c>Some</c>.
    /// Throws an <see cref="InvalidOperationException"/> if the option is <c>None</c>.
    /// </summary>
    /// <returns>The value contained in the option.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the option is <c>None</c>.</exception>
    public static T UnwrapOrPanic<T>(bool isSome, T value)
    {
        EnsureSome(isSome);
        return value;
    }

    /// <summary>
    /// Returns the reference to contained value if this <see cref="Option{T}"/> is <c>Some</c>.
    /// Throws an <see cref="InvalidOperationException"/> if the option is <c>None</c>.
    /// </summary>
    /// <returns>The value contained in the option.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the option is <c>None</c>.</exception>
    public static ref T UnwrapOrPanicRef<T>(bool isSome, ref T value)
    {
        EnsureSome(isSome);
        return ref value;
    }
    
    private static void EnsureSome(bool isSome)
    {
        if (!isSome) throw new InvalidOperationException("Option is None");
    }
}