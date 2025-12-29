using RResult.Extensions.Functional.Option;
using RResult.Shared.Options;

namespace RResult.Tests.OptionTests.Extensions;

public class OptionExpectTests
{
    [Fact]
    public void Expect_OnSomeOption_ReturnsValue()
    {
        var option = Option<int>.Some(42);
        int value = option.Expect("Should not throw");

        Assert.Equal(42, value);
        Assert.True(option.IsSome());
    }

    [Fact]
    public void Expect_OnNoneOption_ThrowsInvalidOperationException()
    {
        var option = Option<int>.None;

        var ex = Assert.Throws<InvalidOperationException>(() => option.Expect("Custom error message"));

        Assert.Equal("Custom error message", ex.Message);
        Assert.True(option.IsNone());
    }
}