using System;
using System.Collections.Generic;
using System.Linq;
using TheoryOfCompilators.DiagramDrawer.Entitys;
using TheoryOfCompilators.Lexer;
using TheoryOfCompilators.SemanticalAnalyzer;

namespace TheoryOfCompilators.DiagramDrawer
{
    public class EntityHolder
    {
        public static EntityHolder Instance { get; private set; }
        public List<DiagramNode> DiagramNodes { get; private set; }
        public List<DiagramLine> DiagramLines { get; private set; }
        public List<DiagramFunction> Functions { get; private set; }

        private EntityHolder()
        {
            DiagramNodes = new List<DiagramNode>();
            DiagramLines = new List<DiagramLine>();
            Functions = new List<DiagramFunction>();
            FillEntityFolder(ProgramContextHolder.GetInstance());
        }

        public static EntityHolder GetInstance()
        {
            if (Instance == null)
            {
                Instance = new EntityHolder();
            }
        
        return Instance;
        }

        private void FillEntityFolder(ProgramContextHolder contextHolder)
        { 
            ExtractVariables(contextHolder.Variables);
            ExtractFunction(contextHolder.Functions);
        }

        private  void ExtractVariables(List<MyVariable> variables)
        {
            List<DiagramNode> listOfNodes = new List<DiagramNode>();
            List<DiagramLine> diagramLinesList = new List<DiagramLine>();
            for (int val = 0; val < variables.Count; val++)
            {
                switch (variables[val].Type)
                {
                 case   VarType.Node : listOfNodes.Add(DiagramNode.ExtractFromMyVariable(variables[val])); break;
                 case   VarType.Line : diagramLinesList.Add(DiagramLine.ExtractFromMyVariable(variables[val])); break;
                }
            }

            DiagramNodes = listOfNodes;
            DiagramLines = diagramLinesList;
        }

        private void ExtractFunction(List<MyFunction> functions)
        {
            List<DiagramFunction> listOfFunctions = new List<DiagramFunction>();
            for (int i = 0; i < functions.Count; i++)
            {
                MyFunction currentFunc = functions[i];
                listOfFunctions.Add(new DiagramFunction(currentFunc.MethodName,currentFunc.VarsParameters));
            }

            Functions = listOfFunctions;
        }

    }
}