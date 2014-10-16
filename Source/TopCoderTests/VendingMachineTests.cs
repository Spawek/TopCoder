//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using TopCoder;

//namespace TopCoderTests
//{
//    [TestClass]
//    public class VendingMachineTests
//    {
//        [TestMethod]
//        public void TestMethod0()
//        {
//            VendingMachine vm = new VendingMachine();

//            string [] prices = new string[]{"100 100 100"};
//            string[] purchases = new string[] { "0,0:0", "0,2:5", "0,1:10" };
//            int actual = vm.motorUse(prices, purchases);
//            int expected = 4;

//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void TestMethod1()
//        {
//            VendingMachine vm = new VendingMachine();

//            string[] prices = new string[] { "100 200 300 400 500 600" };
//            string[] purchases = new string[] { "0,2:0", "0,3:5", "0,1:10", "0,4:15" };
//            int actual = vm.motorUse(prices, purchases);
//            int expected = 17;

//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void TestMethod2()
//        {
//            VendingMachine vm = new VendingMachine();

//            string[] prices = new string[] { "100 200 300 400 500 600" };
//            string[] purchases = new string[] { "0,2:0", "0,3:4", "0,1:8", "0,4:12" };
//            int actual = vm.motorUse(prices, purchases);
//            int expected = 11;

//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void TestMethod3()
//        {
//            VendingMachine vm = new VendingMachine();

//            string[] prices = new string[] { "100 100 100" };
//            string[] purchases = new string[] { "0,0:10", "0,0:11" };
//            int actual = vm.motorUse(prices, purchases);
//            int expected = -1;

//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void TestMethod4()
//        {
//            VendingMachine vm = new VendingMachine();

//            string[] prices = new string[] {"100 200 300", "600 500 400"};
//            string[] purchases = new string[] {"0,0:0", "1,1:10", "1,2:20", "0,1:21", "1,0:22", "0,2:35"};
//            int actual = vm.motorUse(prices, purchases);
//            int expected = 6;

//            Assert.AreEqual(expected, actual);
//        }
//    }
//}
