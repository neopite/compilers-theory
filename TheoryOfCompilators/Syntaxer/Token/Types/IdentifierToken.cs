using TheoryOfCompilators.Lexer;

namespace TheoryOfCompilators.Syntaxer.Token
{
    public class IdentifierToken : AbstractTokenParser<IdentifierToken>
    {
        public string Value { get; private set; }

        public IdentifierToken(string value)
        {
            Value = value;
        }

        public IdentifierToken CreateToken()
        {
            var token = SyntaxParser.Parse(null, LexType.IDENTIFIER);
            return new IdentifierToken(token.Value);
        }
    }
}