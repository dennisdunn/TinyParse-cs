using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyParse
{
    public static class Builders
    {
        public static Parser Chr(char target)
        {
            return text =>
            {
                return text.Peek() == target.ToString()
                ? text.Read()
                : null;
            };
        }
        public static Parser Str(string target)
        {
            return text =>
            {

                return text.Peek(target.Length) == target
                ? text.Read(target.Length)
                : null;
            };
        }
        public static Parser AnyOf(string target)
        {
            return text =>
            {

                return target.Contains(text.Peek())
                ? text.Read()
                : null;
            };
        }
    }
}
