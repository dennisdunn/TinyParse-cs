using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyParse
{
    public abstract class Error : Exception
    {
        public Error() { }
        public Error(Exception e) : base(null, e) { }
    }

    public class SyntaxError : Error
    {
        public int? Position { get; init; }
        public string? Expected { get; init; }
        public SyntaxError() { }
        public SyntaxError(IText text, string expected)
        {
            Position = text.Position;
            Expected = expected;
        }
        public SyntaxError(Exception e) : base(e){ }
    }

    public class BoundsError : Error
    {
        public BoundsError() { }
        public BoundsError(Exception e) : base(e) { }
    }
}
