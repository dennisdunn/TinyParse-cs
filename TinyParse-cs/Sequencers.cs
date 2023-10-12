using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyParse
{
    public static class Sequencers
    {
        /// <summary>
        /// All of the parsers must succeed.
        /// </summary>
        /// <param name="parsers"></param>
        /// <returns>Returns a list of all the matched strings.</returns>
        public static Sequencer All(params Parser[] parsers)
        {
            return text =>
            {
                var result = new List<string>();

                foreach (Parser parser in parsers)
                {
                    var str = parser(text);
                    if (str != string.Empty)
                    {
                        result.Add(str);
                    }
                }

                return result;
            };
        }

        /// <summary>
        /// One or more.
        /// </summary>
        /// <param name="parsers"></param>
        /// <returns>Returns a list of all the matched strings.</returns>
        public static Sequencer Many(Parser parser)
        {
            return text =>
            {
                var result = new List<string>();

                while (true)
                {
                    try
                    {
                        var str = parser(text);
                        if (str != string.Empty)
                        {
                            result.Add(str);
                        }
                    }
                    catch (TinyParseError)
                    {
                        break;
                    }
                }
                return result;
            };
        }
    }
}
