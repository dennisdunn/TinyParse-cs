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

        public object? SumOp(IText src) => IgnoreWs(AnyOf("+-"))(src);
        public object? ProductOp(IText src) => IgnoreWs(AnyOf("*/"))(src);
        public object? OpenParen(IText src) => IgnoreWs(Str("("))(src);
        public object? CloseParen(IText src) => IgnoreWs(Str(")"))(src);
        public object? Number(IText src) => IgnoreWs(Signed)(src);

        // Non-Terminals

        public object? Expr(IText src) => Sequence(Term, Expr_Prime)(src);
        public object? Expr_Prime(IText src) => Optional(Sequence(SumOp, Term, Expr_Prime))(src);
        public object? Term(IText src) => Sequence(Factor, Term_Prime)(src);
        public object? Term_Prime(IText src) => Optional(Sequence(ProductOp, Factor, Term_Prime))(src);
        public object? Factor(IText src) => Any(Number, Sequence(OpenParen, Expr, CloseParen))(src);
    }
}
