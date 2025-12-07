namespace RResult.Shared.Options.Ref;

public ref struct MutableOptionRef<T>
{
    internal ref T _value;
    private bool _isSome;

    private MutableOptionRef(ref T value, bool isSome)
    {
        _value = ref value;
        _isSome = isSome;
    }

    public static MutableOptionRef<T> Create(ref T value, bool isSome = true) => new(ref value, isSome);

    /// <inheritdoc cref="OptionLogic.IsSome"/>
    public bool IsSome() => OptionLogic.IsSome(_isSome);

    /// <inheritdoc cref="OptionLogic.IsNone"/>
    public bool IsNone() => OptionLogic.IsNone(_isSome);
    
    /// <inheritdoc cref="OptionLogic.UnwrapOrPanicRef"/>
    public ref T UnwrapOrPanic() => ref OptionLogic.UnwrapOrPanicRef(_isSome, ref _value);
}