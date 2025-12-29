using RResult.Options;
using RResult.Results.Errors;

namespace RResult.Results;

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