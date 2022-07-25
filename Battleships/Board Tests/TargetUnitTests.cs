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
            var actualTarget = new Target(1, Direction.North, "denizalti");

            Assert.AreEqual(actualTarget.Size, 1, "Size Yanlış");
        }
    }
}

