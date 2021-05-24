using System.Collections.Generic;
using System.Linq;

namespace TheoryOfCompilators.SemanticalAnalyzer
{
    public class ProgramContextHolder
    {
        public static ProgramContextHolder Instance { get; private set; }
        
        public List<MyVariable> Variables { get; set; }
        public List<MyFunction> Functions { get; private set; }

        private ProgramContextHolder()
        {
            Variables = new List<MyVariable>();
            Functions = new List<MyFunction>();
        }

        public static ProgramContextHolder GetInstance()
        {
            if (Instance == null) Instance = new ProgramContextHolder();
            return Instance;
        }

        public static bool IsVariableInContext(string varName)
        {
            return GetInstance().Variables.Exists(value => string.Equals(value.Name, varName));
        }

        public static MyVariable GetVariableFromContextByName(string varName)
        {
            return GetInstance().Variables.Find(value => string.Equals(value.Name, varName));
        }
    }
}