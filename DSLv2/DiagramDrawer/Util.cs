using System.Reflection;
using Microsoft.Msagl.Drawing;

namespace DiagramDrawer
{
    public class Util
    {
        public static Color GetColorByFieldName(string name)
        {
            PropertyInfo fieldsVar = typeof(Color).GetProperty(name,BindingFlags.Public | BindingFlags.Static);
            return ((Color) fieldsVar.GetValue(null));
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