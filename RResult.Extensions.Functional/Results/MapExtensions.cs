using RResult.Results;
using RResult.Results.Errors;

namespace RResult.Extensions.Functional.Results;

public static class CastExtensions
{
    public static Result<T, TNewError> MapError<T, TOldError, TNewError>(
        this Result<T, TOldError> result,
        Func<TOldError, TNewError> map)
        where T : notnull
        where TOldError : IError
        where TNewError : IError
    {
        return result.Match(
            Result<T, TNewError>.Ok,
            err => Result<T, TNewError>.Error(map(err))
        );
    }
    
    public static Result<T, BaseError> ToError<T, TError>(
        this Result<T, TError> result)
        where T : notnull
        where TError : BaseError
    {
        return result.MapError<T, TError, BaseError>(e => e);
    }
}