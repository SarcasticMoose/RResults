using RResult.Results.Errors;
using RResult.Results.Errors.Extensions;

namespace RResult.Tests.ResultTests.Errors;

public class ErrorExtensionsTests
{
    [Fact]
    public void ToReadableString_SimpleError_ShouldContainMessage()
    {
        var error = new TestSimpleBaseError("Simple error");

        string result = error.ToReadableString();

        Assert.Contains("\"Message\": \"Simple error\"", result);
        Assert.Contains("\"Arguments\": {}", result);
        Assert.Contains("\"Errors\": []", result);
    }

    [Fact]
    public void ToReadableString_ErrorWithArgs_ShouldContainArguments()
    {
        var error = new TestFullBaseError(
             args: new Dictionary<string, object> { ["TestArg"] = true },
             nested: Array.Empty<IError>()
        );

        string result = error.ToReadableString();

        Assert.Contains("\"Message\": \"Full test error\"", result);
        Assert.Contains("\"TestArg\": true", result); 
        Assert.Contains("\"Errors\": []", result);
    }

    [Fact]
    public void ToReadableString_ErrorWithNested_ShouldContainNestedMessages()
    {
        var nested1 = new TestSimpleBaseError("Nested 1");
        var nested2 = new TestSimpleBaseError("Nested 2");
        var error = new TestBaseErrorWithNested(nested: new[] { nested1, nested2 });

        string result = error.ToReadableString();

        Assert.Contains("\"Message\": \"Error with nested errors\"", result);
        Assert.Contains("\"Message\": \"Nested 1\"", result);
        Assert.Contains("\"Message\": \"Nested 2\"", result);
    }

    [Fact]
    public void ToReadableString_FullError_ShouldContainEverything()
    {
        var nested = new TestSimpleBaseError("Nested error");
        var error = new TestFullBaseError(
            args: new Dictionary<string, object> { ["TestArg"] = true },
            nested: new[] { nested }
        );

        string result = error.ToReadableString();

        Assert.Contains("\"Message\": \"Full test error\"", result);
        Assert.Contains("\"TestArg\": true", result);
        Assert.Contains("\"Errors\": [", result);
        Assert.Contains("\"Message\": \"Nested error\"", result);
    }

    [Fact]
    public void ToReadableString_NullError_ShouldReturnEmptyString()
    {
        IError? error = null;

        string result = error.ToReadableString();
        Assert.Equal(string.Empty, result);
    }
}

internal sealed class TestSimpleBaseError : BaseError
{
    public TestSimpleBaseError(string message = "Simple test error") : base(message) { }
}

internal sealed class TestBaseErrorWithArgs : BaseError
{
    public TestBaseErrorWithArgs(string message = "Error with arguments")
        : base(message, new Dictionary<string, object>
        {
            ["Arg1"] = 123,
            ["Arg2"] = "Value"
        })
    { }
}

internal sealed class TestBaseErrorWithNested : BaseError
{
    public TestBaseErrorWithNested(string message = "Error with nested errors", IEnumerable<IError>? nested = null)
        : base(message, nestedErrors: nested)
    { }
}

internal sealed class TestFullBaseError : BaseError
{
    public TestFullBaseError(string message = "Full test error",
        IDictionary<string, object>? args = null,
        IEnumerable<IError>? nested = null)
        : base(message, new Dictionary<string, object> { ["TestArg"] = true }, nestedErrors: nested)
    { }
}