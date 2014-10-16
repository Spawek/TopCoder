using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TopCoderTestGenerator;

namespace TopCoderTestGeneratorTests
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void ExampleParserTest()
        {
            string input = "0)\r\n    \r\n\"123210122\"\r\nReturns: { \"011100011\",  \"NONE\" }\r\nThe example from above.\r\n";
            TopCoderExample example = new TopCoderExample(input);

            Assert.AreEqual(0, example.testCaseNo);
            Assert.AreEqual("\"123210122\"", example.input);
            Assert.AreEqual("{ \"011100011\",  \"NONE\" },", example.expectedOutput);
        }
    }
}
