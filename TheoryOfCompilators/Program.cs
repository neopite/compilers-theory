using System;
using System.IO;

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
        }
    }
}