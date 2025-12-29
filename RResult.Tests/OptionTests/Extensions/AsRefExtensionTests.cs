using RResult.Extensions.Functional.Option;
using RResult.Shared.Options;

namespace RResult.Tests.OptionTests.Extensions;

public class AsRefExtensionTests
{
    [Fact]
    public void AsRef_OnSomeOption_ReturnsReferenceToValue()
    {
        var option = Option<int>.Some(1);
        Assert.Equal(1, option.AsImmutable().UnwrapOrThrow());
    }
}