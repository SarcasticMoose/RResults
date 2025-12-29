using RResult.Shared.Options;
using RResult.Shared.Results.Errors;

namespace RResult.Shared.Results;

public interface IResult
{
    bool IsOk { get; }
    bool IsError { get; }
}

public interface IResult<T, TError> : IResult
    where TError : IError
{
    public Option<T> Ok();
    public Option<TError> Error();
}