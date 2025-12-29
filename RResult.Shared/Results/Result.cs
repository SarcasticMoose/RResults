using RResult.Shared.Options;
using RResult.Shared.Results.Errors;

namespace RResult.Shared.Results;

/// <summary>
/// Represents the result of an operation, which can either be a success or a failure.
/// </summary>
/// <typeparam name="T">The type of the value returned on success.</typeparam>
/// <typeparam name="TError">The type of the error returned on failure (must implement <see cref="IError"/>).</typeparam>
public sealed record Result<T, TError> : IResult
    where TError : IError
    where T : notnull
{
    /// <summary>
    /// Indicates whether the result is a success.
    /// </summary>
    public bool IsOk => _isOk;

    /// <summary>
    /// Indicates whether the result is a failure.
    /// </summary>
    public bool IsError => !IsOk;

    internal readonly T? _value;
    internal readonly TError? _error;
    private readonly bool _isOk;

    /// <summary>
    /// Creates a result representing success.
    /// </summary>
    public static Result<T, TError> Ok(T value) => new(value);

    /// <summary>
    /// Creates a result representing failure.
    /// </summary>
    public static Result<T, TError> Error(TError error) => new(error);

    private Result(T value)
    {
        _value = value;
        _isOk = true;
    }

    private Result(TError error)
    {
        _error = error;
    }

    public Option<T> OkOption() => IsOk ? Option<T>.Some(_value!) : Option<T>.None;
    public Option<TError> ErrorOption() => IsError ? Option<TError>.Some(_error!) : Option<TError>.None;
}

