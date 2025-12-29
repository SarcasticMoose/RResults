using RResult.Results;
using RResult.Results.Errors;

namespace RResult.Tests.ResultTests;

public class TestBaseError(string? message = null) : BaseError(message ?? "Operation Failed");

public class MatchTests
{
    [Fact]
    public void Match_ShouldGetOkResult()
    {
        var result = Result<int, TestBaseError>.Ok(1);
        var returned = result.Match(
            ok => ok,
            fail => 0);
        
        Assert.Equal(1, returned);
    }
    
    [Fact]
    public void Match_ShouldGetFailResult()
    {
        var result = Result<int, TestBaseError>.Error(new TestBaseError());
        var returned = result.Match(
            ok => ok,
            fail => 0);
        
        Assert.Equal(0, returned);
    }
}