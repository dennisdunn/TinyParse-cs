﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyParse
{
    public delegate dynamic Parser(ISourceText text);
    public delegate bool Predicate(string str, string expected);
}
