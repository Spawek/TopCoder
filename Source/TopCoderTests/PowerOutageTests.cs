using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoderTests
{
    [TestClass]
    public class PowerOutageTests
    {
        [TestMethod]
        public void TestMethod0()
        {
            PowerOutage po = new PowerOutage();

            int[] fromJunction = new int[] { 0 };
            int[] toJunction = new int[] { 1 };
            int[] ductLength = new int[] { 10 };

            int expected = 10;
            int actual = po.estimateTimeOut(fromJunction, toJunction, ductLength);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod1()
        {
            PowerOutage po = new PowerOutage();

            int[] fromJunction = new int[] { 0, 1, 0 };
            int[] toJunction = new int[] { 1, 2, 3 };
            int[] ductLength = new int[] { 10, 10, 10 };

            int expected = 40;
            int actual = po.estimateTimeOut(fromJunction, toJunction, ductLength);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestMethod2()
        {
            PowerOutage po = new PowerOutage();

            int[] fromJunction = new int[] { 0, 0, 0, 1, 4 };
            int[] toJunction = new int[] { 1, 3, 4, 2, 5 };
            int[] ductLength = new int[] { 10, 10, 100, 10, 5 };

            int expected = 165;
            int actual = po.estimateTimeOut(fromJunction, toJunction, ductLength);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestMethod3()
        {
            PowerOutage po = new PowerOutage();

            int[] fromJunction = new int[] { 0, 0, 0, 1, 4, 4, 6, 7, 7, 7, 20 };
            int[] toJunction = new int[] { 1, 3, 4, 2, 5, 6, 7, 20, 9, 10, 31 };
            int[] ductLength = new int[] { 10, 10, 100, 10, 5, 1, 1, 100, 1, 1, 5 };

            int expected = 281;
            int actual = po.estimateTimeOut(fromJunction, toJunction, ductLength);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            PowerOutage po = new PowerOutage();

            int[] fromJunction = new int[] { 0, 0, 0, 0, 0 };
            int[] toJunction = new int[] { 1, 2, 3, 4, 5 };
            int[] ductLength = new int[] { 100, 200, 300, 400, 500 };

            int expected = 2500;
            int actual = po.estimateTimeOut(fromJunction, toJunction, ductLength);

            Assert.AreEqual(expected, actual);
        }


    }
}
