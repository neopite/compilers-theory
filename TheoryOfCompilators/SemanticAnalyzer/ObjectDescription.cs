using System;
using System.Collections.Generic;
using TheoryOfCompilators.Lexer;
using TheoryOfCompilators.Syntaxer.Token;

namespace TheoryOfCompilators.SemanticalAnalyzer
{
    public class ObjectDescription
    {
        public VarType ObjectType { get; private set; }
        public List<ObjectField> ObjectsFields { get; private set; }
        
        public ObjectDescription(VarType objectType, List<ObjectField> objectsFields)
        {
            ObjectType = objectType;
            ObjectsFields = objectsFields;
        }
        
        private static Lazy<List<ObjectDescription>> _objectDescription = new Lazy<List<ObjectDescription>>(
            () => new List<ObjectDescription>()
            {
                new ObjectDescription(VarType.Node,new List<ObjectField>()
                {
                  new ObjectField("type",VarType.String),
                  new ObjectField("drawColor",VarType.String),
                  new ObjectField("fillColor",VarType.String),
                  new ObjectField("units",VarType.Number)
                }) ,
                new ObjectDescription(VarType.Line , new List<ObjectField>()
                {
                    new ObjectField("width",VarType.Number),
                    new ObjectField("color",VarType.String),
                    new ObjectField("arrow",VarType.String),
                })
            });

        public static List<ObjectDescription> Descriptions => _objectDescription.Value;

    }
}