using System;
using Microsoft.Msagl.Drawing;

namespace DiagramDrawer
{
    public class ColorAdapter : IAdapter<Color,string>
    {
        public Color Adapt(string value)
        {
            return Util.GetColorByFieldName(ToUpperFirstLetter(value));
        }

        public static string ToUpperFirstLetter(string colorName)
        {
            colorName = colorName.ToLower();
            char[] letters = colorName.ToCharArray();
            letters[0] = char.ToUpper(letters[0]);
            return new string(letters);
        }
    }
}