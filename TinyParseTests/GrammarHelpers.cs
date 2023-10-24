using TinyParse;

namespace TinyParseTests
{
    public partial class Grammar : Combinators
    {
        public Parser Whitespace => Many(AnyOf(@" \n\l\t"));
        public Parser Sign => AnyOf("+-");
        public Parser Digits => Many(AnyOf("1234567890"));
        public Parser Decimal => All(Str("."), Digits);
        public Parser Signed => All(Optional(Sign), Digits, Optional(Decimal));
    }
}
