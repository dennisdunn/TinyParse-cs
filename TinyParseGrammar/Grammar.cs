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
    public partial class Grammar : BaseGrammar
    {
        //Terminals

        public Parser SumOp => IgnoreWs(AnyOf("+-"));
        public Parser ProductOp => IgnoreWs(AnyOf("*/"));
        public Parser OpenParen => IgnoreWs(Str("("));
        public Parser CloseParen => IgnoreWs(Str(")"));
        public Parser Number => IgnoreWs(Signed);

        // Non-Terminals

        //public Parser Expr => Sequence(Term, Expr_Prime);
        //public Parser Expr_Prime => Optional(Sequence(sum, Term, Expr_Prime));
        //public Parser Term => Sequence(Factor, Term_Prime);
        //public Parser Term_Prime => Optional(Sequence(product, Factor, Term_Prime));
        //public Parser Factor => Any(number, Sequence(open, Expr, close));
    }
}
