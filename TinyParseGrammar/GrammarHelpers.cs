using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TinyParse;

namespace TinyParseGrammar
{
    public partial class Grammar : Combinators
    {
        public Parser Whitespace => Many(AnyOf(@" \n\l\t"));
        public Parser Sign => AnyOf("+-");
        public Parser Digits => Many(AnyOf("1234567890"));
        public Parser Decimal => All(new[] { Str("."), Digits });
        public Parser Signed => All(new[] { Optional(Sign), Digits, Optional(Decimal) });
        public Parser IgnoreWs (Parser parser) => All(new[] { Ignore(Whitespace), parser });
    }
}
