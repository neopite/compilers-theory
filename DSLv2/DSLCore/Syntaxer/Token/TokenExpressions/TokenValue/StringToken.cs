using TheoryOfCompilators.Lexer;

namespace TheoryOfCompilators.Syntaxer.Token
{
    public class StringToken :  ValueToken
    {
        public override VarType Type => VarType.String;

        public StringToken(object value) : base(value)
        {
        }

        public StringToken()
        {
        }

        public StringToken CreateToken()
        {
            Lex lex= SyntaxParser.Parse(null, LexType.STRING);
            return new StringToken(lex.Value);
        }

        public override string ToString()
        {
            return (string)Value;
        }
    }
}