using System;
using System.Collections.Generic;
using System.IO;
using TheoryOfCompilators.DiagramDrawer;
using TheoryOfCompilators.DiagramDrawer.Entitys;
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
           List<DiagramFunction> myFunctions = EntityHolder.GetInstance().Functions;
           List<DiagramNode> myNodes = EntityHolder.GetInstance().DiagramNodes;
           List<DiagramLine> myLines = EntityHolder.GetInstance().DiagramLines;
           EntityHolder entityHolder = EntityHolder.GetInstance();
            Console.Write(listOfStatement);
            
        }
    }
}