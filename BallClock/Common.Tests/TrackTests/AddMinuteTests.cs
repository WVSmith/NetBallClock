using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests.MinutesTests
{
    [TestClass]
    public class AddMinuteTests
    {
        [TestMethod]
        public void TryAddIncreasesCount()
        {
            ITrack minutes = new Track(5);

            minutes.Add(1);
            Assert.AreEqual(1, minutes.Count);
        }
    }
}
