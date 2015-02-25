using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests.ClockTests
{
    [TestClass]
    public class ReserveSizeTests
    {
        [TestMethod]
        public void CanGetReserveSize()
        {
            IClock clock = new Clock(27);

            Assert.AreEqual(27, clock.ReserveSize);
        }
    }
}
