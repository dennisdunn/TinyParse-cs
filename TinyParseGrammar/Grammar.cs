using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TinyParse;
using C = TinyParse.Combinators;
using G = TinyParse.Generators;

namespace TinyParseGrammar
{
    public static class Grammar
    {
        public static Parser Start => Expr;
        public static Parser Whitespace = @" \n\l\t".AnyOf().Many();
        public static Parser Sign = "-+".AnyOf();
        public static Parser Digits = "1234567890".AnyOf().Many();
        public static Parser Decimal = new[] { ".".Str(), Digits }.All();
        public static Parser Signed = new[] { Sign.Optional(), Digits, Decimal.Optional() }.All();

        public static Parser IgnoreWs(this Parser parser)
        {
            return new[] { Whitespace.Ignore(), parser }.All();
        }

        // Terminals

        public static readonly Parser sum = IgnoreWs("+-".AnyOf());
        public static readonly Parser product = IgnoreWs("*/".AnyOf());
        public static readonly Parser open = IgnoreWs("(".Str());
        public static readonly Parser close = IgnoreWs(")".Str());
        public static readonly Parser number = IgnoreWs(Signed);

        // Non-Terminals

        public static readonly Parser Expr = C.Sequence(Term, Expr_Prime);
        public static readonly Parser Expr_Prime = C.Optional(C.Sequence(sum, Term, Expr_Prime));
        public static readonly Parser Term = C.Sequence(Factor, Term_Prime);
        public static readonly Parser Term_Prime = C.Optional(C.Sequence(product, Factor, Term_Prime));
        public static readonly Parser Factor = C.Any(number, C.Sequence(open, Expr, close));
    }
}
