using TheoryOfCompilators.Lexer;

namespace TheoryOfCompilators.Syntaxer.Token
{
    public class NumberToken : ValueToken
    {
        public int Value { get; private set; }

        public NumberToken(int value)
        {
            Value = value;
        }

      
    }
}