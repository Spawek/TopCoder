using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TopCoderTestGenerator
{
    class TopCoderTaskParser
    {
        public ParsedTopCoderTask Parse(string bareTask)
        {
            ParsedTopCoderTask parsed = new ParsedTopCoderTask();
            string[] lines = bareTask.Split(new string[]{"\r\n", "\r", "\n"}, StringSplitOptions.RemoveEmptyEntries);

            int currLine = 0;

            while (lines[currLine] != "Problem Statement") currLine++;
            currLine += 2;
            while (lines[currLine] != "Definition")
            {
                parsed.ProblemStatement += lines[currLine] + "\r\n";
                currLine++;
            }

            while (lines[currLine] != "Class:") currLine++;
            currLine++;
            parsed.ClassName = lines[currLine];

            while (lines[currLine] != "Method:") currLine++;
            currLine++;
            parsed.Method = lines[currLine];

            while (lines[currLine] != "Parameters:") currLine++;
            currLine++;
            parsed.Parameters = lines[currLine].Split(new string[]{", "}, StringSplitOptions.RemoveEmptyEntries);

            while (lines[currLine] != "Method signature:") currLine++;
            currLine++;
            parsed.MethodSignature = lines[currLine];

            while (lines[currLine] != "Time limit (s):") currLine++;
            currLine++;
            parsed.TimeLimit = lines[currLine] + "s";

            while (lines[currLine] != "Memory limit (MB):") currLine++;
            currLine++;
            parsed.MemoryLimit = lines[currLine] + "MB";

            while (lines[currLine] != "Constraints") currLine++;
            while (lines[currLine] != "Examples")
            {
                parsed.Constraints += lines[currLine];
                currLine++;
            }

            string currExample = "";
            bool insideExample = false;
            while (currLine < lines.Length)
            {
                if (insideExample && Regex.IsMatch(lines[currLine], "[0-9]*\\)") ||
                    Regex.IsMatch(lines[currLine], "This problem statement.*"))
                {
                    parsed.Examples.Add(new TopCoderExample(currExample));
                    insideExample = false;
                }
                if (!insideExample && Regex.IsMatch(lines[currLine], "[0-9]*\\)"))
                {
                    currExample = "";
                    insideExample = true;
                }
                if (insideExample)
                {
                    currExample += lines[currLine] + "\r\n";
                }
                currLine++;
            }

            return parsed;
        }
    }
}
