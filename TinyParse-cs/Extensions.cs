using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyParse
{
    public static class Extensions
    {
        public static Parser AnyOf(this string text)
        {
            return Generators.AnyOf(text);
        }

        public static Parser Str(this string text)
        {
            return Generators.Str(text);
        }

        public static Parser Optional(this Parser parser)
        {
            return Combinators.Optional(parser);
        }

        public static Parser Any(this IEnumerable<Parser> parsers)
        {
            return Combinators.Any(parsers.ToArray());
        }

        public static Parser All(this IEnumerable<Parser> parsers)
        {
            return Combinators.All(parsers.ToArray());
        }

        public static Parser Many(this Parser parser)
        {
            return Combinators.Many(parser);
        }

        public static Parser Ignore(this Parser parser)
        {
            return Combinators.Ignore(parser);
        }

        public static Parser Maybe(this Parser parser)
        {
            return Combinators.Maybe(parser);
        }

        public static Parser Sequence(this IEnumerable<Parser> parsers)
        {
            return Combinators.Sequence(parsers.ToArray());
        }

        public static ISource Source(this string text)
        {
            return new Source(text);
        }
    }
}
