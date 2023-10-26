using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TinyParse
{
    public static class Extensions
    {
        public static IText AsText(this string str)
        {
            return new Text(str);
        }

        public static StringBuilder AppendIfNotNullOrWhitespace(this StringBuilder sb, object? item)
        {
            if (item != null && item.GetType() == typeof(string) && !string.IsNullOrWhiteSpace((string)item))
            {
                sb.Append((string)item);
            }
            return sb;
        }
    }
}
