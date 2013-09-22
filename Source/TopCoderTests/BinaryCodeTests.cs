using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TopCoder;

namespace TopCoderTests
{
    [TestClass]
    public class BinaryCodeTests
    {
        BinaryCode binaryCode = new BinaryCode();

        [TestMethod]
        public void TestMethod0()
        {
            string input = "123210122";

            string[] actual = binaryCode.decode(input);
            string[] expected = new string[] { "011100011", "NONE" };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod1()
        {
            string input = "11";

            string[] actual = binaryCode.decode(input);
            string[] expected = new string[] { "01", "10" };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string input = "22111";

            string[] actual = binaryCode.decode(input);
            string[] expected = new string[] { "NONE", "11001" };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string input = "123210120";

            string[] actual = binaryCode.decode(input);
            string[] expected = new string[] { "NONE", "NONE" };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            string input = "3";

            string[] actual = binaryCode.decode(input);
            string[] expected = new string[] { "NONE", "NONE" };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod5()
        {
            string input = "12221112222221112221111111112221111";

            string[] actual = binaryCode.decode(input);
            string[] expected = new string[] { "01101001101101001101001001001101001",
                "10110010110110010110010010010110010" };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod6()
        {
            string input = "0";

            string[] actual = binaryCode.decode(input);
            string[] expected = new string[] { "0", "NONE" };

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
