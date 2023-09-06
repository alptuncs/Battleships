using Battleships;
using NUnit.Framework;

namespace Board_Tests;

[TestFixture]
public class TargetUnitTests
{
    [Test]
    public void Dogru_Target_Olusturur()
    {
        var targetFactory = new TargetFactory();
        ITarget actualTarget = targetFactory.Create(Direction.North(), "denizalti");

        Assert.AreEqual(1, actualTarget.Size, "Size Yanlış");
    }
}
