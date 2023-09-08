using Battleships;
using NUnit.Framework;
using Shouldly;

namespace Board_Tests;

[TestFixture]
public class TargetUnitTests : Spec
{
    [TestCase("denizalti", 1)]
    [TestCase("mayingemisi", 2)]
    [TestCase("kruvazor", 3)]
    [TestCase("amiralgemisi", 4)]
    [Test]
    public void Creates_target_with_correct_size(string shipType, int size)
    {
        ITarget actualTarget = GiveMe.ATarget(shipType: shipType);

        actualTarget.Size.ShouldBe(size);
    }
}
