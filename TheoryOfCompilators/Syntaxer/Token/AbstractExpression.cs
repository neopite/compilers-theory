using TheoryOfCompilators.Lexer;

namespace TheoryOfCompilators.Syntaxer.Token
{
    public abstract class AbstractExpression
    {
        public abstract AbstractExpression Parse(string value, LexType lexType);
    }
}