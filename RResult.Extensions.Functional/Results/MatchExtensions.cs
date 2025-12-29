using RResult.Shared.Results;
using RResult.Shared.Results.Errors;

namespace RResult.Extensions.Functional.Results;

public static class MatchExtensions
{
    public static TResult Match<TValue, TError, TResult>(
        this Result<TValue, TError> result,
        Func<TValue, TResult> ok,
        Func<TError, TResult> error)
        where TValue : notnull
        where TError : IError
    {
        return result.IsOk
            ? ok(result._value!)
            : error(result._error!);
    }
}