using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.CSharp;
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
           // RoslynCodeDomProvider();
        }
        
//         public static void RoslynCodeDomProvider()
//         {            
//             var provider = CodeDomProvider.CreateProvider("CSharp");
//
//             var parms = new CompilerParameters();
//             parms.ReferencedAssemblies.Add("System.dll");
//             parms.ReferencedAssemblies.Add("System.Core.dll");
//             parms.ReferencedAssemblies.Add("Microsoft.CSharp.dll");
//             parms.GenerateInMemory = true;
//
//             var classCode = @"
// using System;
// namespace MyApp
// {    
//     public class Test1
//     {
//         public string HelloWorld(string name) 
//         {
//              return $@""Hello {name} from Roslyn with CodeDomProvider."";
//         }
//     }
// }
// ";
//
//             CompilerResults result = provider.CompileAssemblyFromSource(parms, classCode);
//
//             if (result.Errors.Count > 0)
//             {
//                 Console.WriteLine("*** Compilation Errors");
//                 foreach (var error in result.Errors)
//                 {
//                     Console.WriteLine("- " + error);
//
//                     return;
//                 }
//             }
//
//             var ass = result.CompiledAssembly;
//
//             dynamic inst = ass.CreateInstance("MyApp.Test1");
//
//             string methResult = inst.HelloWorld("Rick") as string;
//
//             Console.WriteLine(methResult);
//         }

        
    }
}