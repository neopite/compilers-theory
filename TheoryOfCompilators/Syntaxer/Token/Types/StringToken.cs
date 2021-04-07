using TheoryOfCompilators.Lexer;

namespace TheoryOfCompilators.Syntaxer.Token
{
    public class StringToken : ValueToken
    { 
        public string Value { get; private set; }

        public StringToken(string value)
        {
            Value = value;
        }

       
    }
}