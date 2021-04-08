using TheoryOfCompilators.Lexer;

namespace TheoryOfCompilators.Syntaxer.Token
{
    public class StringToken :  ValueToken,AbstractTokenParser<StringToken>
    {
        public StringToken(object value) : base(value)
        {
        }

        public StringToken()
        {
        }

        public StringToken CreateToken()
        {
            Lex lex= SyntaxParser.Parse(null, LexType.STRING);
            return new StringToken(lex.Value);
        }
    }
}