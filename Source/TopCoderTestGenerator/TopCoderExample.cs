using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopCoderTestGenerator
{
    //"0)\r\n    \r\n\"123210122\"\r\nReturns: { \"011100011\",  \"NONE\" }\r\nThe example from above.\r\n"
    public class TopCoderExample
    {
        public int testCaseNo;
        public string input;
        public string expectedOutput;

        public TopCoderExample(string str)
        {
            str = str.Replace("The example from above.", String.Empty);
            string[] splittedStr = str.Split(new string[]{"\r\n"}, StringSplitOptions.RemoveEmptyEntries);

            testCaseNo = Convert.ToInt32(splittedStr[0].Substring(0, splittedStr[0].Length - 1));
            input = splittedStr[2];
            expectedOutput = splittedStr[3].Replace("Returns: ", String.Empty);
        }
    }
}
