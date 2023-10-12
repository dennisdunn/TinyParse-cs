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
        /// Wrap the result of the parser in a list.
        /// </summary>
        /// <param name="parser"></param>
        /// <returns></returns>
        public static Sequencer One(Parser parser)
        {
            return text =>
            {
                return new List<string> { parser(text) };
            };
        }

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
                    result.Add(parser(text));
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
                var result = new List<string> { parser(text) };

                while (true)
                {
                    try
                    {
                        result.Add(parser(text));
                    }
                    catch (TinyParseError)
                    {
                        break;
                    }
                }
                return result;
            };
        }

        /// <summary>
        /// Combine the results of all of the sequencers into a single list.
        /// </summary>
        /// <param name="sequencers"></param>
        /// <returns></returns>
        public static Sequencer Combine(params Sequencer[] sequencers)
        {
            return text =>
            {
                var result = new List<string>();

                foreach(Sequencer sequencer in sequencers)
                {
                    result.AddRange(sequencer(text));
                }

                return result;
            };
        }
    }
}
