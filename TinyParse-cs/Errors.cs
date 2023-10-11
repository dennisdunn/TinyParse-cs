using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyParse
{
    public class SyntaxError : Exception
    {
        public int? Position { get; init; }
        public string? Expected { get; init; }
        public SyntaxError() { }
        public SyntaxError(Exception inner) : base(null, inner)
        {
        }
        public SyntaxError(string msg, Exception inner) : base(msg, inner)
        {
        }
    }

    public class EotError : Exception
    {
        public EotError()
        { }
        public EotError(Exception inner) : base(null, inner)
        { }
    }

    public class SeekError : Exception
    {
        public SeekError()
        { }
        public SeekError(Exception inner) : base(null, inner)
        { }
    }
}
