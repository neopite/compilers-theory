using System.Collections.Generic;

namespace TheoryOfCompilators.SemanticalAnalyzer
{
    public class MyFunction
    {
        public string MethodName { get; private set; }
        public List<string> VarsParameters { get; private set; }

        public MyFunction(string methodName, List<string> varsParameters)
        {
            MethodName = methodName;
            VarsParameters = varsParameters;
        }
    }
}