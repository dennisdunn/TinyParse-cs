using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyParse;
using C = TinyParse.Combinators;
using P = TinyParse.Parsers;

namespace TinyParseGrammar
{
    public static class Parsers
    {
        public static Parser Whitespace => @" \n\l\t".AnyOf();
        public static Parser Digit => "1234567890".AnyOf();
        public static Parser HexDigit => new[] { Digit, "abcdefABCDEF".Str() }.Any();
        public static Parser Digits => Digit.Many();
        public static Parser DecimalPart => new[] { ".".Str(), Digits }.All().Optional();
        public static Parser Sign => "-+".AnyOf().Optional();
        public static Parser Upper => "ABCDEFGHIJKLMNOPQRSTUVWXYZ".AnyOf();
        public static Parser Lower => "abcdeghijklmnopqrstuvwxyz".AnyOf();
        public static Parser AlphaNumeric => new[] { Upper, Lower, Digit }.Any();
        public static Parser Number => new[] { Sign, Digits, DecimalPart }.All();
    }

    public static class ParsersHelpers
    {
        public static Parser AnyOf(this string text)
        {
            return P.AnyOf(text);
        }

        public static Parser Str(this string text)
        {
            return P.Str(text);
        }

        public static Parser Optional(this Parser parser)
        {
            return C.Optional(parser);
        }

        public static Parser Any(this IEnumerable<Parser> parsers)
        {
            return C.Any(parsers.ToArray<Parser>());
        }

        public static Parser All(this IEnumerable<Parser> parsers)
        {
            return C.All(parsers.ToArray<Parser>());
        }

        public static Parser Many(this Parser parser)
        {
            return C.Many(parser);
        }

        public static Parser Ignore(this Parser parser)
        {
            return C.Ignore(parser);
        }

        public static Parser Maybe(this Parser parser)
        {
            return C.Maybe(parser);
        }

        public static ISourceText AsSrc(this string text)
        {
            return new SourceText(text);
        }
    }
}
