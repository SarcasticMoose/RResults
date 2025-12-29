using System.Collections.Frozen;
using System.Collections.Immutable;
using RResult.Results.Errors.Extensions;

namespace RResult.Results.Errors;

public abstract class BaseError : IError
{
#if NET8_0_OR_GREATER
    private FrozenSet<IError> _errors;
    private readonly FrozenDictionary<string, object> _arguments;
#else
    private readonly ImmutableDictionary<string,object> _arguments;
    private readonly ImmutableHashSet<IError> _errors;
#endif
    
    public string Message { get; }
    public IReadOnlyDictionary<string, object> Arguments => _arguments.ToFrozenDictionary();
    public IReadOnlyCollection<IError> Errors => _errors.ToImmutableHashSet();

    public BaseError()
    {
        Message = string.Empty;
#if NET8_0_OR_GREATER
        _arguments = FrozenDictionary<string, object>.Empty;
        _errors = FrozenSet<IError>.Empty;
#else
        _errors = ImmutableHashSet<IError>.Empty;
        _arguments = ImmutableDictionary<string, object>.Empty;
#endif
    }
    
    public BaseError(string message)
    {
        Message = message;
#if NET8_0_OR_GREATER
        _arguments = FrozenDictionary<string, object>.Empty;
        _errors = FrozenSet<IError>.Empty;
#else
        _errors = ImmutableHashSet<IError>.Empty;
        _arguments = ImmutableDictionary<string, object>.Empty;
#endif
    }

    public BaseError(string message, IReadOnlyDictionary<string, object> arguments)
    {
        Message = message;
#if NET8_0_OR_GREATER
        _arguments = arguments.ToFrozenDictionary();
        _errors = FrozenSet<IError>.Empty;
#else
        _errors = ImmutableHashSet<IError>.Empty;
        _arguments = arguments.ToImmutableDictionary();
#endif
    }
    
    public BaseError(string message,
        IReadOnlyDictionary<string, object>? arguments = null,
        IEnumerable<IError>? nestedErrors = null)
    {
        Message = message;

#if NET8_0_OR_GREATER
        _arguments = arguments?.ToFrozenDictionary() ?? FrozenDictionary<string, object>.Empty;
        _errors = nestedErrors != null ? nestedErrors.ToFrozenSet() : FrozenSet<IError>.Empty;
#else
        _arguments = arguments?.ToImmutableDictionary() ?? ImmutableDictionary<string, object>.Empty;
        _errors = nestedErrors != null ? nestedErrors.ToImmutableHashSet() : ImmutableHashSet<IError>.Empty;
#endif
    }
    
    public override string ToString()
    {
        return this.ToReadableString();
    }
}