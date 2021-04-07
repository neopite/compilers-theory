using System.Collections.Generic;

namespace TheoryOfCompilators.Syntaxer.Token
{
    public class ObjectToken : ValueToken
    {
        public List<ObjectPropertyToken> ObjectPropertyTokens { get; private set; }

        public ObjectToken(List<ObjectPropertyToken> objectPropertyTokens)
        {
            ObjectPropertyTokens = objectPropertyTokens;
        }
    }
}