using RResult.Extensions.Functional.Results;
using RResult.Results;
using RResult.Results.Errors;

namespace RResult.Tests.ResultTests;

public class NewTypeError() : BaseError() {}

public class MapErrorTests
{
    [Fact]
    public void MapError()
    {
        var result = Result<int, BaseError>.Error(new TestBaseError("Message"));
        var newTypeError = result.MapError(x => new NewTypeError());
        
        Assert.True(newTypeError.IsError);
        Assert.IsType<NewTypeError>(newTypeError._error);
        Assert.Equal("Message", newTypeError._error.Message);
    }
}