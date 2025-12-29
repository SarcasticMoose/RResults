namespace RResult.Shared.Results.Errors;

public interface IError
{
    string Message { get; }
    IReadOnlyDictionary<string, object> Arguments { get; }
    IReadOnlyCollection<IError> Errors { get; }
}