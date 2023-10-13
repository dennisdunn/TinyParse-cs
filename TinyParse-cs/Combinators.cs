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
                var position = text.Position;
                foreach (Parser parser in parsers)
                {
                    try
                    {
                        return parser(text);
                    }
                    catch (SyntaxError)
                    {
                        text.Seek(position);
                    }
                }
                throw new SyntaxError();
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
                var result = new StringBuilder();

                foreach (Parser parser in parsers)
                {
                    result.Append(parser(text));
                }

                return result.ToString();
            };
        }

        /// <summary>
        /// One or more.
        /// </summary>
        /// <param name="parser"></param>
        /// <returns></returns>
        public static Parser Many(Parser parser)
        {
            return text =>
            {
                var result = new StringBuilder(parser(text));

                while (true)
                {
                    try
                    {
                        result.Append(parser(text));
                    }
                    catch (TinyParseError)
                    {
                        break;
                    }
                }
                return result.ToString();
            };
        }

        /// <summary>
        /// Zero or one.
        /// </summary>
        /// <param name="parser"></param>
        /// <returns>
        /// If the parser doesn't match then return "" instead throwing an exception.
        /// </returns>
        public static Parser Optional(Parser parser)
        {
            return text =>
            {
                try
                {
                    return parser(text);
                }
                catch (TinyParseError)
                {
                    return string.Empty;
                }
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

        /// <summary>
        /// Ignore the results of the parser.
        /// </summary>
        /// <param name="parser"></param>
        /// <returns>string.Empty</returns>
        public static Parser Ignore(Parser parser)
        {
            return text =>
            {
                parser(text);

                return string.Empty;
            };
        }

        /// <summary>
        /// Return the result of middle parser iff all parsers matched.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="mid"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Parser Between(Parser left, Parser mid, Parser right)
        {
            return text =>
            {
                left(text);
                var result = mid(text);
                right(text);

                return result;
            };

        }

        /// <summary>
        /// Build a list (possibly nested) of the results from the parsers.
        /// </summary>
        /// <param name="parsers"></param>
        /// <returns</returns>
        public static Parser Sequence(params Parser[] parsers)
        {
            return text =>
            {
                var result = new List<dynamic>();

                foreach (Parser parser in parsers)
                {
                    result.Add(parser(text));
                }

                return result;
            };
        }
    }
}