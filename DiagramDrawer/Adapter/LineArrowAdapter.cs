using System;
using Microsoft.Msagl.Drawing;

namespace DiagramDrawer
{
    public class LineArrowAdapter : IAdapter<ArrowStyle , string>
    {
        public ArrowStyle Adapt(string value)
        {
            return (ArrowStyle) Enum.Parse(typeof(ArrowStyle),Util.ToUpperFirstLetter(value));
        }
    }
}