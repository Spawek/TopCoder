using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TopCoder;

namespace TopCoderTests
{
    [TestClass]
    public class TimeTests
    {
        [TestMethod]
        public void Time0()
        {
            Time t = new Time();
            Assert.AreEqual("0:0:0", t.whatTime(0));
        }

        [TestMethod]
        public void Time1()
        {
            Time t = new Time();
            Assert.AreEqual("1:1:1", t.whatTime(3661));
        }

        [TestMethod]
        public void Time2()
        {
            Time t = new Time();
            Assert.AreEqual("1:30:36", t.whatTime(5436));
        }

        [TestMethod]
        public void Time3()
        {
            Time t = new Time();
            Assert.AreEqual("23:59:59", t.whatTime(86399));
        }
    }
}
