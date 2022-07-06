﻿using Battleships;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Board_Tests
{
    [TestClass]
    public class TargetUnitTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            int expectedXPos = 0;
            int expectedYPos = 0;

            Target actualTarget = new Target(0, 0, 1, "north");

            Assert.AreEqual(expectedYPos, actualTarget.XPos);
            Assert.AreEqual(expectedXPos, actualTarget.YPos);
        }
    }


}
