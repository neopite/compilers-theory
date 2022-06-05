
using System;
using TheoryOfCompilators.Lexer;

namespace TheoryOfCompilators.SemanticalAnalyzer
{
    public class ObjectField
    {
        public string Name { get;  set; }
        public VarType FieldType { get;  set; }

        public ObjectField(string name, VarType fieldType)
        {
            Name = name;
            FieldType = fieldType;
        }

        public ObjectField()
        {
        }

        public override bool Equals(object? obj)
        {
            ObjectField objectField = (ObjectField) obj;
            return obj != null && Name.Equals(objectField.Name) && FieldType == objectField.FieldType;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + FieldType.GetHashCode();
        }
    }
}