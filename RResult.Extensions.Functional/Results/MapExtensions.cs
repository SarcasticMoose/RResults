using RResult.Results;
using RResult.Results.Errors;

namespace RResult.Extensions.Functional.Results;

public static class MapExtensions
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
}