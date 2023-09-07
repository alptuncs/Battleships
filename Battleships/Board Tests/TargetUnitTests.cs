using Battleships;
using NUnit.Framework;
using Shouldly;

namespace Board_Tests;

[TestFixture]
public class TargetUnitTests : Spec
{
    [Test]
    public void Creates_target_with_correct_size()
    {
        ITarget actualTarget = GiveMe.ATarget(shipType: "denizalti");

        actualTarget.Size.ShouldBe(1);
    }
}
