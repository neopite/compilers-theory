using System.Collections.Generic;

namespace TheoryOfCompilators.Syntaxer.Token
{
    public class ObjectPropertyToken
    {
        public IdentifierToken IdentifierToken { get; private set; }
        public ValueToken ValueTokens { get; private set; }
        
    }
}