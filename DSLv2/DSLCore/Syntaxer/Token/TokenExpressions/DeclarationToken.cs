using TheoryOfCompilators.Lexer;

namespace TheoryOfCompilators.Syntaxer.Token
{
    public class DeclarationToken: AbstractTokenParser<DeclarationToken>
    {
        public static readonly string KEYWORD = "val";
        public static readonly char EQUAL = '=';
        public IdentifierToken IdentifierToken { get; private set; }
        public ValueToken ValueToken { get; private set; }

        public DeclarationToken(IdentifierToken identifierToken, ValueToken valueToken)
        {
            IdentifierToken = identifierToken;
            ValueToken = valueToken;
        }
        
        public DeclarationToken()
        {
        }

        public DeclarationToken CreateToken()
        {
            SyntaxParser.Parse(KEYWORD, LexType.KEYWORD);
            var id = new IdentifierToken("null").CreateToken();
            SyntaxParser.Parse("=", LexType.DELIMETER);
            VarType varType;
            ObjectToken obj = null;
            if (SyntaxParser.GetCurrentLex().Value == "new")
            {
                obj = new ObjectToken(null).CreateToken();
            }

            return new DeclarationToken(id,obj);
        }
    }
}