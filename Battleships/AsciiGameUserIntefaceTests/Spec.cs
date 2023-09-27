using NUnit.Framework;

namespace AsciiGameUserIntefaceTests;

public abstract class Spec
{
    public Stubber GiveMe { get; private set; } = default!;
    public Mocker MockMe { get; private set; } = default!;

    [SetUp]
    public virtual void SetUp()
    {
        GiveMe = new Stubber(this);
        MockMe = new Mocker(this);
    }

    public sealed record Stubber(Spec Spec);
    public sealed record Mocker(Spec Spec);
}
