using RResult.Extensions.Functional.Option;
using RResult.Options;

namespace RResult.Tests.OptionTests.Extensions;

public class MatchTests
{
    [Fact]
    public void Match_OnSomeOption_ReturnsSomePredicate()
    {
        var option = Option<int>.Some(42);
        string value = option.Match(
            ok => ok.ToString(),
            () => "Nothing");

        Assert.True(option.IsSome);
        Assert.Equal("42", value);
    }

    [Fact]
    public void Match_OnNoneOption_ReturnsNonePredicate()
    {
        var option = Option<int>.None;
        var value = option
            .Match(
                ok => ok.ToString(),
                () => "Nothing");

        Assert.True(option.IsNone);
        Assert.Equal("Nothing", value);
    }
}