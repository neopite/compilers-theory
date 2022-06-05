namespace TheoryOfCompilators.Lexer
{
    public class Lex
    {
        public int Id { get; private set; }
        public LexType LexType { get; private set; }
        public string Value { get; private set; }

        public Lex(int id, LexType lexType, string value)
        {
            Id = id;
            LexType = lexType;
            Value = value;
        }
    }
}