using RResult.Shared.Options;

namespace RResult.Tests.OptionTests;

public class OptionLogicTests
{
    [Theory]
    [InlineData(true, true)]
    [InlineData(false, false)]
    public void IsSome_ReturnsCorrectValue(bool isSome, bool expected)
    {
        bool result = OptionLogic.IsSome(isSome);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(true, false)]
    [InlineData(false, true)]
    public void IsNone_ReturnsCorrectValue(bool isSome, bool expected)
    {
        bool result = OptionLogic.IsNone(isSome);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void UnwrapOrThrow_OnSome_ReturnsValue()
    {
        int value = 42;
        int result = OptionLogic.UnwrapOrThrow(true, value);

        Assert.Equal(value, result);
    }

    [Fact]
    public void UnwrapOrThrow_OnNone_ThrowsInvalidOperationException()
    {
        int value = 42;

        var ex = Assert.Throws<InvalidOperationException>(() => OptionLogic.UnwrapOrThrow(false, value));
        Assert.Equal("Option is None", ex.Message);
    }

    [Fact]
    public void UnwrapOrThrowRef_OnSome_ReturnsReference()
    {
        int value = 100;
        ref int result = ref OptionLogic.UnwrapOrThrowRef(true, ref value);
        result = 200;
        Assert.Equal(200, value);
    }

    [Fact]
    public void UnwrapOrThrowRef_OnNone_ThrowsInvalidOperationException()
    {
        int value = 0;

        var ex = Assert.Throws<InvalidOperationException>(() => OptionLogic.UnwrapOrThrowRef(false, ref value));
        Assert.Equal("Option is None", ex.Message);
    }
}