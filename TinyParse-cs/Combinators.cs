using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyParse
{
    public partial class BaseGrammar
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
                foreach (Parser parser in parsers)
                {
                    var position = text.Position;
                    try
                    {
                        return parser(text);
                    }
                    catch (Error)
                    {
                        text.Seek(position);
                    }
                }
                throw new SyntaxError { Position = text.Position };
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
                var position = text.Position;
                try
                {
                    var result = new StringBuilder();

                    foreach (Parser parser in parsers)
                    {
                        result.Append(parser(text));
                    }

                    return result.ToString();
                }
                catch (SyntaxError)
                {
                    text.Seek(position);
                }
                throw new SyntaxError { Position = text.Position };
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
                    catch (Error)
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
        /// If the parser doesn't match then return "" instead throwing an Error.
        /// </returns>
        public static Parser Optional(Parser parser)
        {
            return text =>
            {
                try
                {
                    return parser(text);
                }
                catch (Error)
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
                try
                {
                    parser(text);
                }
                catch (SyntaxError) { }

                return string.Empty;
            };
        }

        ///// <summary>
        ///// Build a list (possibly nested) of the results from the parsers.
        ///// </summary>
        ///// <param name="parsers"></param>
        ///// <returns</returns>
        public static Parser Sequence(params Parser[] parsers)
        {
            return text =>
            {
                List<string> result = new();

                foreach (Parser parser in parsers)
                {
                    var parse = parser(text);
                    if (parse != string.Empty) result.Add(parse);
                }

                return "[" + string.Join(",", result.ToArray()) + "]";
            };
        }

        /// <summary>
        /// Apply the function to the result of the parser.
        /// </summary>
        /// <param name="parser"></param>
        /// <param name="fn"></param>
        /// <returns></returns>
        public static Parser Apply(Parser parser, Func<string, string> fn)
        {
            return text =>
            {
                var result = parser(text);
                return fn(result);
            };
        }
    }
}