namespace TheoryOfCompilators.Syntaxer.Token
{
    public class DeclarationToken
    {
        public static readonly string KEYWORD = "val";
        public static readonly char EQUAL = '=';
        public IdentifierToken IdentifierToken { get; private set; }
        public ValueToken ValueToken { get; private set; }
    }
}