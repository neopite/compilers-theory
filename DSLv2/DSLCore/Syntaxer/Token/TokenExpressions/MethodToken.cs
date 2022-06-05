using System.Collections.Generic;
using TheoryOfCompilators.Lexer;

namespace TheoryOfCompilators.Syntaxer.Token
{
    public class MethodToken  : AbstractTokenParser<MethodToken>
    {
        public string MethodName { get; private set; }
        public List<string> MethodParameters { get; private set; }
        
        public MethodToken(string methodName,List<string> methodParameters)
        {
            MethodParameters = methodParameters;
            MethodName = methodName;
        }

        public MethodToken()
        {
        }

        public MethodToken CreateToken()
        {
            string methodName = SyntaxParser.Parse(null, LexType.IDENTIFIER).Value;
            List<string> parameters = new List<string>();
            SyntaxParser.Parse("(", LexType.DELIMETER);
            while (true)
            {
                Lex identifier = SyntaxParser.Parse(null,LexType.IDENTIFIER);
                parameters.Add(identifier.Value);
                if (identifier.LexType == LexType.IDENTIFIER && SyntaxParser.GetCurrentLex().Value == ")")
                {
                    SyntaxParser.Parse(")", LexType.DELIMETER);
                    break;
                }else if(SyntaxParser.Parse(",",LexType.DELIMETER).Value==",")
                {
                    continue;
                }
            }

            return new MethodToken(methodName, parameters);
        }
    }
}