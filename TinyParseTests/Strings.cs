﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyParse;

namespace TinyParseTests
{
    public static class Strings
    {
        public static string Text => "hello, world";
        public static string Text2 => "helloworld";
        public static string Integer => "388";
        public static string Float => "-3.88";
        public static string Digits => "1234567890";
        public static string Sign => "+-";
        public static string Whitespace => @" \t\n\l";
    
        public static ISourceText Source(this string str)
        {
            return new SourceText(str);
        }
    }
}