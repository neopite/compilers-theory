using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiagramDrawer;
using TheoryOfCompilators.DiagramDrawer;
using TheoryOfCompilators.DiagramDrawer.Entitys;
using TheoryOfCompilators.Lexer;
using TheoryOfCompilators.SemanticalAnalyzer;
using TheoryOfCompilators.Syntaxer.Token;

namespace Executer
{
     class Program
    {
        private static DiagramExecutor _diagramExecutor = new DiagramExecutor();

        static void Main(string [] args)
        {
            Lexer lexer = new Lexer();
            char[] chars = File
                .ReadAllText("D:\\Study\\Compilators\\TheoryOfCompilators\\Executer\\code.txt")
                .ToCharArray();
            lexer.FindLex(chars);
            SyntaxParser syntaxParser = new SyntaxParser(lexer.AllLexes);
            List<StatementToken> listOfStatement = new List<StatementToken>();
            while (SyntaxParser._currentLex < lexer.AllLexes.Count)
            {
                listOfStatement.Add(new StatementToken().CreateToken());
            }
            SemanticAnalyzer.CheckDeclarationSemantic(listOfStatement);
            DiagramExecutor.Setup();
            ProccesParsedData(EntityHolder.GetInstance());
            DiagramExecutor.ShowDiagram();
        }

        private static void ProccesParsedData(EntityHolder entityHolder)
        {
            List<DiagramFunction> allFunctions = entityHolder.Functions;
            List<DiagramNode> allNodes = entityHolder.DiagramNodes;
            List<DiagramLine> allLines = entityHolder.DiagramLines;
            for (int itter = 0; itter < allFunctions.Count; itter++)
            {
                if (allFunctions[itter].FunctionName == "drawLine")
                {
                    DiagramExecutor.CreateEdge(entityHolder.GetNodeByName(allFunctions[itter].ParametersNames[0]).Name,
                        entityHolder.GetNodeByName(allFunctions[itter].ParametersNames[1]).Name,
                        entityHolder.GetLineByName(allFunctions[itter].ParametersNames[2]));
                }
                else if (allFunctions[itter].FunctionName == "drawNode")
                {
                    DiagramExecutor.CreateNode(entityHolder.GetNodeByName(allFunctions[itter].ParametersNames[0]));
                }
            }
        }
    }
}