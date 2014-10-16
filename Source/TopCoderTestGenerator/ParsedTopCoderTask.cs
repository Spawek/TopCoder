using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopCoderTestGenerator
{
    class ParsedTopCoderTask
    {
        public string ProblemStatement = "";
        public string ClassName = "";
        public string MethodSignature = "";
        public string Method = "";
        public string TimeLimit = "";
        public string MemoryLimit = "";
        public string Constraints = "";
        public List<TopCoderExample> Examples = new List<TopCoderExample>();
    }
}
