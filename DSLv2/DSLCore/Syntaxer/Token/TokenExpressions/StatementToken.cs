using System.Collections.Generic;
using TheoryOfCompilators.Lexer;

namespace TheoryOfCompilators.Syntaxer.Token
{
    public class StatementToken : AbstractTokenParser<StatementToken>
    {
        public DeclarationToken DeclarationToken { get; private set; }
        public MethodToken MethodToken { get; private set; }

        public StatementToken(DeclarationToken declarationToken)
        {
            DeclarationToken = declarationToken;
        }

        public StatementToken(MethodToken methodToken)
        {
            MethodToken = methodToken;
        }

        public StatementToken()
        {
        }

        public StatementToken CreateToken()
        {
            var currToken = SyntaxParser.GetCurrentLex();
            DeclarationToken declarationToken = null;
            MethodToken methodToken = null;
            if (currToken.Value == "val")
            {
                declarationToken= new DeclarationToken().CreateToken();
                SyntaxParser.Parse(";", LexType.DELIMETER);
                return new StatementToken(declarationToken);

            }else if (SyntaxParser.GetCurrentLex().LexType == LexType.IDENTIFIER)
            {
                methodToken = new MethodToken().CreateToken();
                SyntaxParser.Parse(";", LexType.DELIMETER);
                return new StatementToken(methodToken);
            }

            return null;
        }
    }
}