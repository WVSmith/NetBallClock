using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests.ClockTests
{
    [TestClass]
    public class SerializeTests
    {
        [TestMethod]
        public void CanSerializeInitalClock()
        {
            IClock clock = new Clock(27);
            string result = clock.Serialize();

            Assert.AreEqual(@"{""Min"":[],""FiveMin"":[],""Hour"":[],""Main"":[1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27]}", result);
        }

        [TestMethod]
        public void SerializeAfter1Minute()
        {
            IClock clock = new Clock(27);
            clock.IncrementMinute();
            string result = clock.Serialize();

            Assert.AreEqual(@"{""Min"":[1],""FiveMin"":[],""Hour"":[],""Main"":[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27]}", result);
        }
    }
}
