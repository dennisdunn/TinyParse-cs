using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyParse
{
    public abstract class TinyParseError : Exception
    {
        public TinyParseError() { }
        public TinyParseError(Exception inner) : base(null, inner) { }
        public TinyParseError(string msg, Exception inner) : base(msg, inner) { }
    }

    public class SyntaxError : TinyParseError
    {
        public int? Position { get; init; }
        public string? Expected { get; init; }
        public SyntaxError() { }
        public SyntaxError(Exception inner) : base(inner)
        {
        }
        public SyntaxError(string msg, Exception inner) : base(msg, inner)
        {
        }
    }

    public class EotError : TinyParseError
    {
        public EotError()
        { }
        public EotError(Exception inner) : base(inner)
        { }
    }

    public class SeekError : TinyParseError
    {
        public SeekError()
        { }
        public SeekError(Exception inner) : base(inner)
        { }
    }
}
