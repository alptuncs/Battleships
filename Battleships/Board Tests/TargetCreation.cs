using NUnit.Framework;
using Shouldly;

namespace Board_Tests;

[TestFixture]
public class TargetCreation : Spec
{
    [TestCase("Submarine", 1)]
    [TestCase("Destroyer", 2)]
    [TestCase("Cruiser", 3)]
    [TestCase("Battleship", 4)]
    [Test]
    public void Creates_target_with_correct_size(string shipType, int size)
    {
        Battleships.Target actualTarget = GiveMe.ATarget(shipType: shipType);

        actualTarget.Size.ShouldBe(size);
    }
}
