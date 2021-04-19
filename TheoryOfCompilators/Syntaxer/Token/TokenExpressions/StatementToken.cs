using System.Collections.Generic;
using TheoryOfCompilators.Lexer;

namespace TheoryOfCompilators.Syntaxer.Token
{
    public class StatementToken : AbstractTokenParser<StatementToken>
    {
        public DeclarationToken DeclarationToken { get; private set; }

        public StatementToken(DeclarationToken declarationToken)
        {
            DeclarationToken = declarationToken;
        }

        public StatementToken()
        {
        }

        public StatementToken CreateToken()
        {
            var currToken = SyntaxParser.GetCurrentLex();
            DeclarationToken declarationToken = null;
            if (currToken.Value == "val")
            {
                declarationToken= new DeclarationToken().CreateToken();
            }
            SyntaxParser.Parse(";", LexType.DELIMETER);
            
            return new StatementToken(declarationToken);
        }
        
        
    }
}