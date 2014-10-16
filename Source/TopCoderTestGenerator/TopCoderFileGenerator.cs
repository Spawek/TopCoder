using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* start time: 15:55 */
/* tests done: 16:00 */
/* all basic test passed: 17:14 */
/* 109.9 / 300 pts on submit */
//but how it works??? //im not sure what was the resoult
/* 90.0 on second sumbmit (all tests passed) -10% - after adding BULLSHIT code (but not chaning time complexity from linear) */

namespace TopCoderTestGenerator
{
    class TopCoderFileGenerator
    {
        public string generate(ParsedTopCoderTask task)
        {
            List<string> output = new List<string>();

            appendUnitTestUsing(output);
            appendTimeComments(output);
            appendProblemStatement(output, task);
            appendLimits(output, task);
            appendConstraints(output, task);
            appendUsings(output);
            appendClass(output, task);
            appendTests(output, task);

            return output.Aggregate((curr, next) => curr += "\r\n" + next);
        }

        private void appendUnitTestUsing(List<string> output)
        {
            output.Add("using Microsoft.VisualStudio.TestTools.UnitTesting;");
        }

        private void appendTests(List<string> output, ParsedTopCoderTask task)
        {
            output.Add(String.Empty);
            output.Add("[TestClass]");
            output.Add("public class " + task.ClassName + "Tests");
            output.Add("{");
            foreach (TopCoderExample example in task.Examples)
            {
                appendTest(output, example, task);
            }
            output.Add("}");
        }

        private void appendTest(List<string> output, TopCoderExample example, ParsedTopCoderTask task)
        {
            string objName = task.ClassName.ToLower();

            output.Add(String.Empty);
            output.Add("\t[TestMethod]");
            output.Add("\t public void TestCase" + example.testCaseNo.ToString() + "()");
            output.Add("\t{");
            output.Add("\t\t" + task.ClassName + " " + objName + " = new " + task.ClassName + "();");

            string assertLine = String.Empty;
            assertLine += "\t\tAssert.AreEqual(" + example.expectedOutput + ", " + objName + "." + task.Method + "(";
            for (int i = 0; i < example.inputs.Count; i++)
			{
                if (i != 0) assertLine += ", ";
                if (task.Parameters[i].Contains("[]"))
                {
                    assertLine += "new " + task.Parameters[i] + example.inputs[i];
                }
                else
                {
                    assertLine += example.inputs[i];
                }
	        }
            assertLine += "));";

            output.Add(assertLine);
            output.Add("\t}");
        }

        private void appendConstraints(List<string> output, ParsedTopCoderTask task)
        {
            output.Add(String.Empty);
            output.Add("/**");
            output.Add(" * CONSTRAINTS: ");
            output.Add(" * " + task.Constraints.Replace("\r\n", "\r\n * ")); //add cutting lines?
            output.Add(" */");
        }

        private void appendProblemStatement(List<string> output, ParsedTopCoderTask task)
        {
            output.Add(String.Empty);
            output.Add("/**");
            output.Add(" * PROBLEM STATEMENT: ");
            output.Add(task.ProblemStatement.Replace("\r\n", "\r\n * "));
            output.Add(" */");
        }

        private void appendLimits(List<string> output, ParsedTopCoderTask task)
        {
            output.Add(String.Empty);
            output.Add("/**");
            output.Add(" * LIMITS:");
            output.Add(" * time limit: " + task.TimeLimit);
            output.Add(" * memory limit: " + task.MemoryLimit);
            output.Add(" */");
        }

        private void appendClass(List<string> output, ParsedTopCoderTask task)
        {
            output.Add(String.Empty);
            output.Add("public class " + task.ClassName);
            output.Add("{");
            output.Add("\tpublic " + task.MethodSignature);
            output.Add("\t{");
            output.Add("\t\t");
            output.Add("\t}");
            output.Add("}");
        }

        private void appendUsings(List<string> output)
        {
            output.Add(String.Empty);
            output.Add("using System;");
            output.Add("using System.Collections.Generic;");
            output.Add("using System.Linq;");
            output.Add("using System.Text;");
            output.Add("using System.Threading.Tasks;");
        }

        private void appendTimeComments(List<string> output)
        {
            output.Add(String.Empty);
            output.Add("/* start time: " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + " */");
            output.Add("/* all basic test passed: xx:xx */");
            output.Add("/* xxx / xxx pts on submit */");
        }


    }
}
