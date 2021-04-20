using System.Collections.Generic;
using TheoryOfCompilators.DiagramDrawer.Builder;
using TheoryOfCompilators.SemanticalAnalyzer;
using TheoryOfCompilators.Syntaxer.Token;

namespace TheoryOfCompilators.DiagramDrawer.Entitys
{
    public class DiagramLine
    {
        public string Name { get; private set; }
        public uint Width { get; private set; }
        public string DrawColor { get; private set; }
        public string Arrow { get; private set; }

        public DiagramLine(string name, uint width, string drawColor, string arrow)
        {
            Name = name;
            Width = width;
            DrawColor = drawColor;
            Arrow = arrow;
        }

        public DiagramLine(string name)
        {
            Name = name;
        }

        public DiagramLine()
        {
        }
        
        public static DiagramLine ExtractFromMyVariable(MyVariable variable)
        {
            ObjectToken body = (ObjectToken) variable.Value;
            List<ObjectPropertyToken> propertirs = body.Value as List<ObjectPropertyToken>;
            DiagramNodeBuilder nodeBuilder = new DiagramNodeBuilder(variable.Name);
            for (int i = 0; i < propertirs.Count; i++)
            {
                switch (propertirs[i].IdentifierToken.Value)
                {
                    case  "width" : nodeBuilder.BuildWidth((int) propertirs[i].Value.Value); break;
                    case  "color" : nodeBuilder.BuildDrawColor((string) propertirs[i].Value.Value); break;
                    case  "arrow" : nodeBuilder.BuildArrow((string) propertirs[i].Value.Value); break;
                }
            }
            return nodeBuilder.Build();
        }
        

        public class DiagramNodeBuilder : IBuilder<DiagramLine>
        {
            private DiagramLine Entity { get;set; }

            public DiagramNodeBuilder(string name)
            {
                Entity = new DiagramLine(name);
            }

            public void Reset()
            {
                Entity = new DiagramLine();
            }

            public DiagramLine Build()
            {
                DiagramLine diagramNode = Entity;
                Reset();
                return diagramNode;
            }

            public DiagramNodeBuilder BuildWidth(int width)
            {
                Entity.Width = (uint) width;
                return this;
            }

            public DiagramNodeBuilder BuildDrawColor(string drawColor)
            {
                Entity.DrawColor = drawColor;
                return this;
            }

            public DiagramNodeBuilder BuildArrow(string arrow)
            {
                Entity.Arrow = arrow;
                return this;
            }
            
        }
        
    }
}