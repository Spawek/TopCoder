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
        public List<string> inputs = new List<string>();
        public string expectedOutput;
        public string comment = String.Empty;

        public TopCoderExample(string str)
        {
            str = str.Replace("The example from above.", String.Empty);
            string[] splittedStr = str.Split(new string[]{"\r\n"}, StringSplitOptions.RemoveEmptyEntries);

            testCaseNo = Convert.ToInt32(splittedStr[0].Substring(0, splittedStr[0].Length - 1));

            int currLine = 2;
            while (!splittedStr[currLine].Contains("Returns"))
            {
                inputs.Add(splittedStr[currLine]);
                currLine++;
            }
            expectedOutput = splittedStr[currLine].Replace("Returns: ", String.Empty);
            currLine++;

            while (currLine != splittedStr.Length)
            {
                comment += splittedStr[currLine];
                currLine++;
            }
        }
    }
}
