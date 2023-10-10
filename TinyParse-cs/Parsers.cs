using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyParse
{
    public static class Parsers
    {
        public static Parser Str(string target)
        {
            return text =>
            {
                var c = text.Peek(target.Length);
                return c != null && c == target
                ? text.Read(target.Length)
                : null;
            };
        }
        public static Parser AnyOf(string target)
        {
            return text =>
            {
                var c = text.Peek();
                return c != null && target.Contains(c)
                ? text.Read()
                : null;
            };
        }
    }
}
