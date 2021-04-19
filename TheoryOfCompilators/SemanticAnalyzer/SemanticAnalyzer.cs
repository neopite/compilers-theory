using System;
using System.Collections.Generic;
using TheoryOfCompilators.Lexer;
using TheoryOfCompilators.Syntaxer.Token;

namespace TheoryOfCompilators.SemanticalAnalyzer
{
    public class SemanticAnalyzer
    {
        public static bool CheckStatementsSemantic(List<StatementToken> listOfStatementTokens)
        {
            List<ObjectDescription> descriptions = ObjectDescription.Descriptions;
            foreach (StatementToken statement in listOfStatementTokens)
            {
                ValueToken valueToken = statement.DeclarationToken.ValueToken;
                List<ObjectPropertyToken> properties = (List<ObjectPropertyToken>)valueToken.Value;
                VarType objectType = valueToken.Type;
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
                                Console.WriteLine(properties[i].IdentifierToken.Value + " " + properties[i].Value.Type +
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

            return false;
        }
        

        private VarType GetPropertyType(ObjectPropertyToken propertyToken)
        {
            return propertyToken.Type;
        }

        private string GetPropertyName(ObjectPropertyToken propertyToken)
        {
            return propertyToken.IdentifierToken.Value;
        }
    }
}