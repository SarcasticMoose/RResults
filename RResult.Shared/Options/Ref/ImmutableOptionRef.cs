namespace RResult.Shared.Options.Ref;

public readonly ref struct ImmutableOptionRef<T>
{
    internal readonly ref T _value;
    internal readonly bool _isSome;

    private ImmutableOptionRef(in T value)
    {
        _value = value;
        _isSome = true;
    }
    
    public static ImmutableOptionRef<T> Create(in T value) => new(in value);
    
    /// <inheritdoc cref="OptionLogic.IsSome"/>
    public bool IsSome() => OptionLogic.IsSome(_isSome);

    /// <inheritdoc cref="OptionLogic.IsNone"/>
    public bool IsNone() => OptionLogic.IsNone(_isSome);
    
    /// <inheritdoc cref="OptionLogic.UnwrapOrThrowRef{T}"/>
    public ref readonly T UnwrapOrThrow() => ref OptionLogic.UnwrapOrThrowRef(_isSome, ref _value);
}
