using System;
using System.Collections.Generic;
using TheoryOfCompilators.Lexer;

namespace TheoryOfCompilators.Syntaxer.Token
{
    public class ObjectToken : ValueToken
    {

        public ObjectToken(VarType type, object value) : base(type, value)
        {
        }

        public ObjectToken(object value) : base(value)
        {
        }

        public ObjectToken()
        {
        }

        public ObjectToken CreateToken()
        {
            List<ObjectPropertyToken> objectPropertyTokens = new List<ObjectPropertyToken>();
            SyntaxParser.Parse("new", LexType.KEYWORD);
            Lex objectType=SyntaxParser.Parse(null, LexType.TYPE);
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
            VarType varType = (VarType) Enum.Parse(typeof(VarType), objectType.Value);
            return new ObjectToken(varType,objectPropertyTokens);
        }
    }
}