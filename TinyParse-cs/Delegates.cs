using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyParse
{
    public delegate string Parser(IText text);
    public delegate Parser Combinator(Parser parser);
    //public delegate Parser Combinator(params Parser[] parsers);
}
