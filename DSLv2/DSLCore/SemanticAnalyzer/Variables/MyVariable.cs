using TheoryOfCompilators.Lexer;
using TheoryOfCompilators.Syntaxer.Token;

namespace TheoryOfCompilators.SemanticalAnalyzer
{
    public class MyVariable
    {
        public string Name { get; private set; }
        public VarType Type { get; private set; }
        public ValueToken Value { get; private set; }
        public int usageCount;
        
        public MyVariable(string name, VarType type, ValueToken value)
        {
            Name = name;
            Type = type;
            Value = value;
        }

        public MyVariable()
        {
        }
    }
}