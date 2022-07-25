using Battleships;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Board_Tests
{
    [TestClass]
    public class TargetUnitTests
    {
        [TestMethod]
        public void Dogru_Target_Olusturur()
        {
            var actualTarget = new Target(1, "north", "denizalti");

            Assert.AreEqual(actualTarget.Direction, "north", "Direction yanlış");
            Assert.AreEqual(actualTarget.Size, 1, "Size Yanlış");
            Assert.AreEqual(actualTarget.Name, "denizalti", "TypeYanlış");
        }
    }
}

