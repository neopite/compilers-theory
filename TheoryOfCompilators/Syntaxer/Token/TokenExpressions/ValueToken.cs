using System;
using System.Collections.Generic;
using TheoryOfCompilators.Lexer;

namespace TheoryOfCompilators.Syntaxer.Token
{
    public class ValueToken : AbstractTokenParser<ValueToken> 
    {
        public virtual VarType Type { get; private set; }
        public object Value { get; private set; }

        public ValueToken(VarType type, object value)
        {
            Type = type;
            Value = value;
        }

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