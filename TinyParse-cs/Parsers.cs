using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Predicate = TinyParse.Predicate;

namespace TinyParse
{
    public static class Parsers
    {
        internal static dynamic Parse(ISourceText text, string expected, int length, Predicate fn)
        {
            var str = text.Peek(length);
            if (fn(str, expected))
            {
                return text.Read(length);
            }
            else
            {
                throw new SyntaxError()
                {
                    Position = text.Position,
                    Expected = expected
                };
            }
        }


        public static Parser Str(string expected)
        {
            return text =>
            {
                return Parse(text, expected, expected.Length, (str, exp) => str == exp);
            };
        }

        public static Parser AnyOf(string expected)
        {
            return text =>
            {
                return Parse(text, expected, 1, (str, exp) => exp.Contains(str));
            };
        }
    }
}
