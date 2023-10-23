using TinyParse;

namespace TinyParseGrammar
{
    public partial class Grammar : Combinators
    {
        //Terminals

        public dynamic? SumOp(IText src) => IgnoreWs(AnyOf("+-"))(src);
        public dynamic? ProductOp(IText src) => IgnoreWs(AnyOf("*/"))(src);
        public dynamic? OpenParen(IText src) => IgnoreWs(Str("("))(src);
        public dynamic? CloseParen(IText src) => IgnoreWs(Str(")"))(src);
        public dynamic? Number(IText src) => IgnoreWs(Signed)(src);

        // Non-Terminals

        public dynamic? Expr(IText src) => Sequence(Term, Expr_Prime)(src);
        public dynamic? Expr_Prime(IText src) => Optional(Sequence(SumOp, Term, Expr_Prime))(src);
        public dynamic? Term(IText src) => Sequence(Factor, Term_Prime)(src);
        public dynamic? Term_Prime(IText src) => Optional(Sequence(ProductOp, Factor, Term_Prime))(src);
        public dynamic? Factor(IText src) => Any(Number, Sequence(OpenParen, Expr, CloseParen))(src);
    }
}
