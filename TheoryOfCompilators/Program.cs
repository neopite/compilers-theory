using System;
using System.Collections.Generic;
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
            SyntaxParser syntaxParser = new SyntaxParser(lexer.AllLexes);
            List<StatementToken> listOfStatement = new List<StatementToken>();
            while (SyntaxParser._currentLex < lexer.AllLexes.Count)
            {
                listOfStatement.Add(new StatementToken().CreateToken());
            }
            Console.Write(listOfStatement);
        }
    }
}