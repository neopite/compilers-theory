namespace TheoryOfCompilators.Syntaxer.Token
{
    public class DeclarationToken: AbstractTokenParser<DeclarationToken>
    {
        public static readonly string KEYWORD = "val";
        public static readonly char EQUAL = '=';
        public IdentifierToken IdentifierToken { get; private set; }
        public ValueToken ValueToken { get; private set; }

        public DeclarationToken CreateToken()
        {
            throw new System.NotImplementedException();
        }
    }
}