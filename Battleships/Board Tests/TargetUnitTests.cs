using Battleships;
using NUnit.Framework;

namespace Board_Tests;

[TestFixture]
public class TargetUnitTests : Spec
{
    [Test]
    public void Creates_target_with_correct_size()
    {
        ITarget actualTarget = GiveMe.ATarget(shipType: "denizalti");

        Assert.AreEqual(1, actualTarget.Size);
    }
}
