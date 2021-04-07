namespace TheoryOfCompilators.Syntaxer.Token
{
    public class IdentifierToken
    {
        public string Value { get; private set; }

        public IdentifierToken(string value)
        {
            Value = value;
        }
    }
}