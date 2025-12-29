using RResult.Extensions.Functional.Option;
using RResult.Shared.Options;

namespace RResult.Tests.OptionTests.Extensions;

public class AsMutExtensionTests
{
    [Fact]
    public void AsMut_OnSomeOption_AllowsModifyingUnderlyingValue()
    {
        var option = Option<int>.Some(1);
        ref var mutable = ref option.AsMut().UnwrapOrThrow();
        mutable = 2;
        Assert.Equal(2, option.UnwrapOrThrow());
    }
}