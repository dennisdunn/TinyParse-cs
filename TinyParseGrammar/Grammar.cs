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

        public string SumOp(IText src) => IgnoreWs(AnyOf("+-"))(src);
        public string ProductOp(IText src) => IgnoreWs(AnyOf("*/"))(src);
        public string OpenParen(IText src) => IgnoreWs(Str("("))(src);
        public string CloseParen(IText src) => IgnoreWs(Str(")"))(src);
        public string Number(IText src) => IgnoreWs(Signed)(src);

        // Non-Terminals

        public string Expr(IText src) => Sequence(Term, Expr_Prime)(src);
        public string Expr_Prime(IText src) => Optional(Sequence(SumOp, Term, Expr_Prime))(src);
        public string Term(IText src) => Sequence(Factor, Term_Prime)(src);
        public string Term_Prime(IText src) => Optional(Sequence(ProductOp, Factor, Term_Prime))(src);
        public string Factor(IText src) => Any(Number, Sequence(OpenParen, Expr, CloseParen))(src);
    }
}
