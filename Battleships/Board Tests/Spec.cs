using NUnit.Framework;

namespace Board_Tests;

public abstract class Spec
{
    public Stubber GiveMe { get; private set;    } = default!;
    public Mocker MockMe { get; private set; } = default!;

    [SetUp]
    public virtual void SetUp()
    {
        GiveMe = new Stubber();
        MockMe = new Mocker();
    }

    public sealed record Stubber();
    public sealed record Mocker();
}
