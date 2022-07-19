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

            Target actualTarget = new Target(1, "north","denizalti");

            Assert.AreEqual(expectedYPos, actualTarget.XPos, "X pozisyonu yanlış");
            Assert.AreEqual(expectedXPos, actualTarget.YPos, "Y pozisyonu yanlış");
        }
    }


}
