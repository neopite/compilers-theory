using System.Collections.Generic;

namespace TheoryOfCompilators.DiagramDrawer.Entitys
{
    public class Function
    {
        public string FunctionName { get; private set; }
        public List<string> ParametersNames { get; private set; }

        public Function(string functionName, List<string> parametersNames)
        {
            FunctionName = functionName;
            ParametersNames = parametersNames;
        }
    }
}