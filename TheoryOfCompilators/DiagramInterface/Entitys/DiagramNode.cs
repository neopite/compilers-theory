using System;
using System.Collections.Generic;
using TheoryOfCompilators.DiagramDrawer.Builder;
using TheoryOfCompilators.SemanticalAnalyzer;
using TheoryOfCompilators.Syntaxer.Token;

namespace TheoryOfCompilators.DiagramDrawer.Entitys
{
    public class DiagramNode
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string DrawColor { get; private set; }
        public string FillColor { get; private set; }
        public int Units { get; private set; }

        public DiagramNode(string name, string type, string drawColor, string fillColor, int units)
        {
            Name = name;
            Type = type;
            DrawColor = drawColor;
            FillColor = fillColor;
            Units = units;
        }

        public DiagramNode(string name)
        {
            Name = name;
        }

        public DiagramNode()
        {
        }

        public override string ToString()
        {
            return "Type : " + Type + " , DrawColor : " + DrawColor + ", FillColor : " + FillColor + ", Units : " +
                   Units;
        }

        public static DiagramNode ExtractFromMyVariable(MyVariable variable)
        {
            ObjectToken body = (ObjectToken) variable.Value;
            List<ObjectPropertyToken> propertirs = body.Value as List<ObjectPropertyToken>;
            DiagramNodeBuilder nodeBuilder = new DiagramNodeBuilder(variable.Name);
            for (int i = 0; i < propertirs.Count; i++)
            {
                switch (propertirs[i].IdentifierToken.Value)
                {
                  case  "type" : nodeBuilder.BuildType((string) propertirs[i].Value.Value); break;
                  case  "drawColor" : nodeBuilder.BuildDrawColor((string) propertirs[i].Value.Value); break;
                  case  "fillColor" : nodeBuilder.BuildFillColor((string) propertirs[i].Value.Value); break;
                  case  "units" : nodeBuilder.BuildUnits((int) propertirs[i].Value.Value); break;
                }
            }
            return nodeBuilder.Build();
        }

        public class DiagramNodeBuilder : IBuilder<DiagramNode>
        {
            private DiagramNode Entity { get;set; }

            public DiagramNodeBuilder(string name)
            {
                Entity = new DiagramNode(name);
            }

            public void Reset()
            {
                Entity = new DiagramNode();
            }

            public DiagramNode Build()
            {
                DiagramNode diagramNode = Entity;
                Reset();
                return diagramNode;
            }

            public DiagramNodeBuilder BuildType(string type)
            {
                Entity.Type = type;
                return this;
            }

            public DiagramNodeBuilder BuildDrawColor(string drawColor)
            {
                Entity.DrawColor = drawColor;
                return this;
            }

            public DiagramNodeBuilder BuildFillColor(string fillColor)
            {
                Entity.FillColor = fillColor;
                return this;
            }

            public DiagramNodeBuilder BuildUnits(int units)
            {
                Entity.Units = units;
                return this;
            }
        }
        
    }
}