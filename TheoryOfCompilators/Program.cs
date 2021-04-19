using System;
using System.Collections.Generic;
using System.IO;
using TheoryOfCompilators.Lexer;
using TheoryOfCompilators.SemanticalAnalyzer;
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
            SyntaxParser syntaxParser = new SyntaxParser(lexer.AllLexes);
            List<StatementToken> listOfStatement = new List<StatementToken>();
            while (SyntaxParser._currentLex < lexer.AllLexes.Count)
            {
                listOfStatement.Add(new StatementToken().CreateToken());
            }
            
           SemanticalAnalyzer.SemanticAnalyzer.CheckDeclarationSemantic(listOfStatement);
           List<MyVariable> vars =ProgramContextHolder.GetInstance().Variables;
           List<MyFunction> fun =ProgramContextHolder.GetInstance().Functions;
            Console.Write(listOfStatement);
            /*ObjectField objectField = new ObjectField("type", VarType.Number);
            ObjectField objectField1 = new ObjectField("type", VarType.String);
            Console.Write(objectField.Equals(objectField1));*/
        }
    }
}