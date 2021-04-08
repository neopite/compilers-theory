using System;
using System.IO;
using TheoryOfCompilators.Syntaxer.Token;

namespace TheoryOfCompilators
{
    class Program
    {
        static void Main(string[] args)
        {
            Lexer.Lexer lexer = new Lexer.Lexer();
            char[] chars = File.ReadAllText("D:\\Study\\Compilators\\TheoryOfCompilators\\TheoryOfCompilators\\code.txt").ToCharArray();
            lexer.FindLex(chars);
            lexer.PrintLexems();
            DeclarationToken declarationToken = new DeclarationToken();
            ValueToken valueToken = new ValueToken();
        }
    }
}