using System.Collections.Generic;
using TheoryOfCompilators.Lexer;

namespace TheoryOfCompilators.Syntaxer.Token
{
    public class ObjectPropertyToken : ValueToken,AbstractTokenParser<ObjectPropertyToken>
    {
        public override VarType Type => VarType.Property;

        public IdentifierToken IdentifierToken { get; private set; }
        public ValueToken Value { get; private set; }

        public ObjectPropertyToken()
        {
        }

        public ObjectPropertyToken(IdentifierToken identifierToken, ValueToken value)
        {
            IdentifierToken = identifierToken;
            Value = value;
        }

        public ObjectPropertyToken CreateToken()
        {
            var identifierToken = new IdentifierToken(null).CreateToken();
            SyntaxParser.Parse(":", LexType.DELIMETER); 
            var value = new ValueToken().CreateToken();
            return new ObjectPropertyToken(identifierToken, value);
        }

        public override string ToString()
        {
            return IdentifierToken.ToString() + "/n" + Value.ToString();
        }
    }
}