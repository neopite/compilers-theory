using TheoryOfCompilators.Lexer;
using TheoryOfCompilators.Syntaxer.Token;

namespace TheoryOfCompilators.SemanticalAnalyzer
{
    public class MyVariable
    {
        public string Name { get; private set; }
        public VarType Type { get; private set; }
        public ValueToken Value { get; private set; }
        public DeclarationToken DeclarationToken { get; private set; }

        public MyVariable(string name, VarType type, ValueToken value, DeclarationToken declarationToken)
        {
            Name = name;
            Type = type;
            Value = value;
            DeclarationToken = declarationToken;
        }

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