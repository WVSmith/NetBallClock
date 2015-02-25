using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests.ClockTests
{
    [TestClass]
    public class InitalStateTests
    {
        [TestMethod]
        public void InitialStateFalseIfMinutesOrSeconds()
        {
            IClock clock = new Clock(27);
            clock.IncrementMinute();

            Assert.IsFalse(clock.IsInitialState);
        }

        [TestMethod]
        public void MainQueueMustBeInOrder()
        {
            IClock clock = new Clock(30);
            for (int i = 0; i < (60 * 12); ++i)
                clock.IncrementMinute();

            Assert.IsFalse(clock.IsInitialState);

        }

        [TestMethod]
        public void MainQueueMustBeInOrder30()
        {
            IClock clock = new Clock(30);
            for (int i = 0; i < (60 * 12 * 2 * 15); ++i)
                clock.IncrementMinute();

            Assert.IsTrue(clock.IsInitialState);

        }

        [TestMethod]
        public void MainQueueMustBeInOrder45()
        {
            IClock clock = new Clock(45);
            for (int i = 0; i < (60 * 12 * 2 * 378); ++i)
                clock.IncrementMinute();

            Assert.IsTrue(clock.IsInitialState);
        }
    }
}
