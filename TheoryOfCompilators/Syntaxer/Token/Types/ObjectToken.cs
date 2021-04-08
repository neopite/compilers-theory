using System.Collections.Generic;
using TheoryOfCompilators.Lexer;

namespace TheoryOfCompilators.Syntaxer.Token
{
    public class ObjectToken : ValueToken, AbstractTokenParser<ObjectToken>
    {
        public ObjectToken(object value) : base(value)
        {
        }

        public ObjectToken()
        {
        }

        public ObjectToken CreateToken()
        {
            List<ObjectPropertyToken> objectPropertyTokens = new List<ObjectPropertyToken>();
            SyntaxParser.Parse("{", LexType.DELIMETER);
            while (SyntaxParser.GetCurrentLex().Value != "}")
            {
                objectPropertyTokens.Add(new ObjectPropertyToken().CreateToken());
                if (SyntaxParser.GetCurrentLex().Value != "}")
                {
                    SyntaxParser.Parse(",", LexType.DELIMETER);
                }
            }

            SyntaxParser.Parse("}", LexType.DELIMETER);
            return new ObjectToken(objectPropertyTokens);
        }
    }
}