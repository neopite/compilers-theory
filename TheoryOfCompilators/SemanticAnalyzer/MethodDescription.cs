using System;
using System.Collections.Generic;
using TheoryOfCompilators.Lexer;

namespace TheoryOfCompilators.SemanticalAnalyzer
{
    public class MethodDescription
    {
        public string MethodName { get; private set; }
        public List<VarType> Parameters { get; private set; }

        public MethodDescription(string methodName, List<VarType> parameters)
        {
            MethodName = methodName;
            Parameters = parameters;
        }
         
        
        private static Lazy<List<MethodDescription>> _methodsDescriptions = new Lazy<List<MethodDescription>>(
            () => new List<MethodDescription>()
            {
               new MethodDescription("drawLine",new List<VarType>() {VarType.Node,
                   VarType.Node,
                   VarType.Line}),
               new MethodDescription("drawNode",new List<VarType>() {VarType.Node})
            });

        public static List<MethodDescription> MethodDescriptions => _methodsDescriptions.Value;

        public static MethodDescription GetMethodDescriptionByName(string methodName)
        {
            return MethodDescriptions.Find(desr => string.Equals(desr, methodName));
        }
        
    }
}