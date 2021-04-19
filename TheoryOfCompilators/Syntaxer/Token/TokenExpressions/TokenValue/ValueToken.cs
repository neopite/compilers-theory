using System;
using System.Collections.Generic;
using TheoryOfCompilators.Lexer;

namespace TheoryOfCompilators.Syntaxer.Token
{
    public class ValueToken : AbstractTokenParser<ValueToken> 
    {
        public object Value { get; private set; }

        public ValueToken(object value)
        {
            Value = value;
        }

        public ValueToken()
        {
        }

        public ValueToken CreateToken()
        {
            Lex lex = SyntaxParser.GetCurrentLex();
            switch (lex.LexType)
            {
              case  LexType.NUMBER : return new NumberToken().CreateToken();
              case LexType.STRING : return new StringToken().CreateToken();
            }

            if (lex.Value == "{")
            {
                return new ObjectToken().CreateToken();
            }

            return null;
        }
    }
}