using System;
using Microsoft.Msagl.Drawing;

namespace DiagramDrawer
{
    public class FigureAdapter : IAdapter<Shape,string>
    {
        public Shape Adapt(string value)
        {
            return (Shape) Enum.Parse(typeof(Shape),Util.ToUpperFirstLetter(value));
        }
    }
}