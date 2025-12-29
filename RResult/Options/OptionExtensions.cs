namespace RResult.Options;

internal static class OptionExtensions
{
    public static void EnsureSome(bool isSome)
    {
        if (!isSome) throw new InvalidOperationException("Option is None");
    }
}