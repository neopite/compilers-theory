using System.Collections.Generic;

namespace TheoryOfCompilators.Lexer
{
    public interface ILexer
    {
        void FindLex(char[] chars);
        void PushLex(Lex lex);
    }
}