using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyParse
{
    public static class Combinators
    {
        /// <summary>
        /// Return the first parser to succeed.
        /// </summary>
        /// <param name="parsers"></param>
        /// <returns></returns>
        public static Parser Any(params Parser[] parsers)
        {
            return text =>
            {
                string? result = null;
                foreach (Parser parser in parsers)
                {
                    result = parser(text);
                    if (result != null) break;
                }
                return result;
            };
        }

        /// <summary>
        /// All of the parsers must succeed.
        /// </summary>
        /// <param name="parsers"></param>
        /// <returns></returns>
        public static Parser All(params Parser[] parsers)
        {
            return text =>
            {
                var pos = text.Offset;
                var result = new StringBuilder();

                foreach (Parser parser in parsers)
                {
                    var str = parser(text);
                    if (str == null)
                    {
                        text.Seek(pos);
                        return null;
                    }
                    else
                    {
                        result.Append(str);
                    }
                }
                return result.ToString();
            };
        }

        /// <summary>
        /// One or more.
        /// </summary>
        /// <param name="parsers"></param>
        /// <returns></returns>
        public static Parser Many(Parser parser)
        {
            return text =>
            {
                var result = new StringBuilder();
                string? str = null;
                while ((str = parser(text)) != null)
                {
                    result.Append(str);
                }
                return result.Length > 0
                ? result.ToString()
                : null;
            };
        }

        /// <summary>
        /// Zero or one.
        /// </summary>
        /// <param name="parser"></param>
        /// <returns>
        /// If the parser doesn't match then return "" instead of null.
        /// </returns>
        public static Parser Optional(Parser parser)
        {
            return text =>
            {
                var result = parser(text);
                return result != null
                ? result
                : string.Empty;
            };
        }
        /// <summary>
        /// Zero or more
        /// </summary>
        /// <param name="parser"></param>
        /// <returns></returns>
        public static Parser Maybe(Parser parser)
        {
            return Optional(Many(parser));
        }
    }
}
