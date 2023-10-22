using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TinyParse
{
    public partial class BaseGrammar
    {
        public static Parser Str(string expected)
        {
            return text =>
            {
                var str = text.Peek(expected.Length);

                return str == expected
                ? text.Read(expected.Length)
                : throw new SyntaxError(text, expected);
            };
        }

        public static Parser AnyOf(string expected)
        {
            return text =>
            {
                var str = text.Peek();

                return expected.Contains(str)
                ? text.Read()
                : throw new SyntaxError(text, expected);
            };
        }
    }
}