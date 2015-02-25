using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests.MinutesTests
{
    [TestClass]
    public class DumpTests
    {
        [TestMethod]
        public void DumpReturnsReverseOrderedBalls()
        {
            ITrack minutes = new Track(5);

            for (int i = 0; i < 5; ++i)
                minutes.Add(i);

            var balls = minutes.Dump();
            Assert.AreEqual(5, balls.Count);
            
            for(int i = 4; i >= 0 && balls.Count > 0; --i)
            {
                int ball = balls.Dequeue();
                Assert.AreEqual(i, ball);
            }
        }
    }
}
