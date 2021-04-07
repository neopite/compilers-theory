using System.Collections.Generic;

namespace TheoryOfCompilators.Syntaxer.Token
{
    public class StatementToken
    {
        public List<DeclarationToken> DeclarationToken { get; private set; }

        public StatementToken(List<DeclarationToken> declarationToken)
        {
            DeclarationToken = declarationToken;
        }
    }
}