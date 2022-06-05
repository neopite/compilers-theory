using System.Collections.Generic;

namespace TheoryOfCompilators.DiagramDrawer.Entitys
{
    public class DiagramFunction
    {
        public string FunctionName { get; private set; }
        public List<string> ParametersNames { get; private set; }

        public DiagramFunction(string functionName, List<string> parametersNames)
        {
            FunctionName = functionName;
            ParametersNames = parametersNames;
        }
    }
}