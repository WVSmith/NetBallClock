using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests.ClockTests
{
    [TestClass]
    public class IncrementMinuteTests
    {
        [TestMethod]
        public void CanIncrement1Minute()
        {
            IClock clock = new Clock(27);
            clock.IncrementMinute();

            Assert.AreEqual(1, clock.Hours);
            Assert.AreEqual(1, clock.Minutes);
        }

        [TestMethod]
        public void FifthIncrementAdds1FiveMinute()
        {
            IClock clock = new Clock(27);
            for (int i = 0; i < 5; ++i )
                clock.IncrementMinute();

            Assert.AreEqual(1, clock.Hours);
            Assert.AreEqual(5, clock.Minutes);
        }

        [TestMethod]
        public void CanIncrement60Times()
        {
            IClock clock = new Clock(27);
            for (int i = 0; i < 60; ++i)
                clock.IncrementMinute();

            Assert.AreEqual(2, clock.Hours);
            Assert.AreEqual(0, clock.Minutes);
        }

        [TestMethod]
        public void CanIncrement11Hours59Minutes()
        {
            IClock clock = new Clock(27);
            for (int i = 0; i < ((60*11)+59); ++i)
                clock.IncrementMinute();

            Assert.AreEqual(12, clock.Hours);
            Assert.AreEqual(59, clock.Minutes);
        }

        [TestMethod]
        public void CanIncrement12Hours()
        {
            IClock clock = new Clock(27);
            for (int i = 0; i < (60 * 12); ++i)
                clock.IncrementMinute();

            Assert.AreEqual(1, clock.Hours);
            Assert.AreEqual(0, clock.Minutes);
        }
    }
}
