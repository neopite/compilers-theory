using System;
using System.Collections.Generic;

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
            return new StringToken();
        }
    }
}