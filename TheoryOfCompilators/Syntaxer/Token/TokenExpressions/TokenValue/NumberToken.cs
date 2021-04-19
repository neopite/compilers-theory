using System;
using TheoryOfCompilators.Lexer;

namespace TheoryOfCompilators.Syntaxer.Token
{
    public class NumberToken :  ValueToken,AbstractTokenParser<NumberToken>
    {
        public override VarType Type => VarType.Number;

        public NumberToken(object value) : base(value)
        {
        }

        public NumberToken()
        {
        }

        public NumberToken CreateToken()
        {
            var token = SyntaxParser.Parse(null, LexType.NUMBER);
            return new NumberToken(Int32.Parse(token.Value));
        }

        public override string ToString()
        {
            return ((int) Value).ToString();
        }
    }
}