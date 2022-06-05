using System.Collections.Generic;
using TheoryOfCompilators.DiagramDrawer;
using TheoryOfCompilators.SemanticalAnalyzer;

namespace TheoryOfCompilators.Translator
{
    public class Translator
    {
        public static void Translate(ProgramContextHolder contextHolder)
        {
            Optimize(contextHolder.Variables);
        }

        private static void Optimize(List<MyVariable> variables)
        {
            for (int i = variables.Count - 1; i >= 0; i--)
            {
                if(variables[i].usageCount == 0) variables.Remove(variables[i]);
            }

            ProgramContextHolder.GetInstance().Variables = variables;
        }
    }
}