using System;
using System.Collections.Generic;
using System.Linq;
using TheoryOfCompilators.Lexer;
using TheoryOfCompilators.Syntaxer.Token;

namespace TheoryOfCompilators.SemanticalAnalyzer
{
    public class SemanticAnalyzer
    {
        public static bool CheckDeclarationSemantic(List<StatementToken> listOfStatementTokens)
        {
            List<ObjectDescription> descriptions = ObjectDescription.Descriptions;
            List<MethodDescription> methodDescriptions = MethodDescription.MethodDescriptions;

            foreach (StatementToken statement in listOfStatementTokens)
            {
                if (statement.DeclarationToken == null)
                {
                    MethodToken currentMethod = statement.MethodToken;
                    List<string> parametersNames = currentMethod.MethodParameters;
                    
                    for (int param = 0; param < parametersNames.Count; param++)
                    {
                        MyVariable methodVar = ProgramContextHolder.GetVariableFromContextByName(parametersNames[param]);
                        if (methodVar == null)
                        {
                            Console.WriteLine(param + "param in method not exist in current variable context");
                        }else if (methodVar.Type == GetFunctionByName(currentMethod.MethodName, methodDescriptions)
                            .Parameters[param])
                        {
                            
                        }else Console.WriteLine("Not suitable variable type at : " + param + " function parameter");
                    }
                    ProgramContextHolder.GetInstance().Functions.Add(new MyFunction(currentMethod.MethodName,parametersNames));

                }
                else
                {
                    ValueToken valueToken = statement.DeclarationToken.ValueToken;
                    List<ObjectPropertyToken> properties = (List<ObjectPropertyToken>) valueToken.Value;
                    VarType objectType = valueToken.Type;
                    if (ProgramContextHolder.GetInstance().Variables.Where(p =>
                        string.Equals(p.Name, statement.DeclarationToken.IdentifierToken.Value)).ToList().Count == 0)
                    {
                        MyVariable variable = new MyVariable(statement.DeclarationToken.IdentifierToken.Value,
                            objectType, valueToken, statement.DeclarationToken);
                        ProgramContextHolder.GetInstance().Variables.Add(variable);
                    }
                    else
                    {
                        throw new Exception("VARIABLE WITH NAME : " + "\" " +
                                            statement.DeclarationToken.IdentifierToken.Value + " \" WAS DECLARED");
                    }

                    for (int field = 0; field < descriptions.Count; field++)
                    {
                        if (descriptions[field].ObjectType == objectType)
                        {
                            ObjectDescription objectDescription = descriptions[field];
                            for (int i = 0; i < properties.Count; i++)
                            {
                                ObjectField objectField =
                                    new ObjectField(properties[i].IdentifierToken.Value, properties[i].Value.Type);
                                if (objectDescription.ObjectsFields.Contains(objectField))
                                {
                                    Console.WriteLine(properties[i].IdentifierToken.Value + " " +
                                                      properties[i].Value.Type +
                                                      " correct field");
                                }
                                else
                                    throw new Exception("Not existed variable according to the :" +
                                                        objectDescription.ObjectType.ToString() + " structure");

                            }
                            break;
                        }
                    }
                }
            }
            return false;
        }

        /*public bool CheckMethodSemantic(List<StatementToken> tokens)
        {
            
        }*/
        

        private VarType GetPropertyType(ObjectPropertyToken propertyToken)
        {
            return propertyToken.Type;
        }

        private string GetPropertyName(ObjectPropertyToken propertyToken)
        {
            return propertyToken.IdentifierToken.Value;
        }

        private static MethodDescription GetFunctionByName(string name , List<MethodDescription> methodDescriptions)
        {
            return methodDescriptions.First(x => string.Equals(x.MethodName, name));
        }
    }
}