using RResult.Extensions.Functional.Option;
using RResult.Options;

namespace RResult.Tests.OptionTests.Extensions;

public class AsSliceExtensionsTests
{
    [Fact]
    public void AsSlice_OnNoneOption_ReturnsEmptySpan()
    {
        var option = Option<int>.None;
        var slice = option.AsSlice();

        Assert.Equal(0, slice.Length);
    }
    
    [Fact]
    public void AsSlice_OnSomeArrayOption_ReturnsSpanWithAllElements()
    {
        var option = Option<int[]>.Some(new[] { 1, 2, 3, 4 });
        var slice = option.AsSlice();

        Assert.Equal(4, slice.Length);
        Assert.Equal(new[] { 1, 2, 3, 4 }, slice.ToArray());
    }
    
    [Fact]
    public void AsSlice_OnSomeSingleValueOption_ReturnsSpanWithOneElement()
    {
        var option = Option<int>.Some(1);
        var slice = option.AsSlice();

        Assert.Equal(1, slice.Length);
        Assert.Equal(1, slice[0]);
    }
    
    [Fact]
    public void AsSlice_OnSomeStringOption_ReturnsSpanOfChars()
    {
        var option = Option<string>.Some("VALUE");
        var slice = option.AsSlice();

        Assert.Equal(5, slice.Length);
        Assert.Equal(new[] { 'V', 'A', 'L', 'U', 'E' }, slice.ToArray());
    }
}