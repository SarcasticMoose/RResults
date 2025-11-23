namespace RResult.Shared.Options.Ref;

public readonly ref struct ImmutableOptionRef<T>
{
    internal readonly ref T _value;
    private readonly bool _isSome;

    private ImmutableOptionRef(ref T value)
    {
        _value = ref value;
        _isSome = true;
    }
    
    public static ImmutableOptionRef<T> Create(ref T value) => new(ref value);
    
    /// <inheritdoc cref="OptionLogic.IsSome"/>
    public bool IsSome() => OptionLogic.IsSome(_isSome);

    /// <inheritdoc cref="OptionLogic.IsNone"/>
    public bool IsNone() => OptionLogic.IsNone(_isSome);
    
    /// <inheritdoc cref="OptionLogic.UnwrapOrPanicRef"/>
    public ref T UnwrapOrPanic() => ref OptionLogic.UnwrapOrPanicRef(_isSome, ref _value);
}
