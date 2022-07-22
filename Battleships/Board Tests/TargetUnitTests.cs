using Battleships;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Board_Tests
{
    [TestClass]
    public class TargetUnitTests
    {
        [TestMethod]
        public void Dogru_bir_sekilde_Target_olusturur()
        {
            int expectedXPos = 0;
            int expectedYPos = 0;

            Target actualTarget = new Target(1, Direction.North,"denizalti");

            Assert.AreEqual(expectedYPos, actualTarget.Origin.XPos, "X pozisyonu yanlış");
            Assert.AreEqual(expectedXPos, actualTarget.Origin.YPos, "Y pozisyonu yanlış");
        }
    }
}

