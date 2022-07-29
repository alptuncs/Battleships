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
            var targetFactory = new TargetFactory();
            ITarget actualTarget = targetFactory.Create(Direction.North(), "denizalti");

            Assert.AreEqual(actualTarget.Size, 1, "Size Yanlış");
        }
    }
}

