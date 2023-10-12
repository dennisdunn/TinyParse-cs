using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyParse;

namespace TinyParseTests
{
    [TestClass]
    public class CombinatorTests
    {
        [TestMethod]
        public void ParseNumber()
        {
            var digits = Combinators.Many(Parsers.AnyOf(Strings.Digits));
            var sign = Combinators.Optional(Parsers.AnyOf(Strings.Sign));
            var fractional = Combinators.Optional(Combinators.All(Parsers.Str("."), digits));
            var number = Combinators.All(sign, digits, fractional);

            var result = number(Strings.Float.Source());
            Assert.AreEqual(Strings.Float, result);
        }

        [TestMethod]
        public void ParseDigit()
        {
            var digit = Parsers.AnyOf(Strings.Digits);

            var result = digit(Strings.Integer.Source());
            Assert.AreEqual("3", result);
        }

        [TestMethod]
        public void ParseDigits()
        {
            var digits = Combinators.Many(Parsers.AnyOf(Strings.Digits));

            var result = digits(Strings.Integer.Source());
            Assert.AreEqual(Strings.Integer, result);
        }

        [TestMethod]
        public void ParseOneOrTheOther()
        {
            // Tests whether the first failed parse resets the position of the input.
            var digit = Combinators.Any(Parsers.Str("8"), Parsers.Str("3"));

            var result = digit(Strings.Integer.Source());
            Assert.AreEqual("3", result);
        }

        [TestMethod]
        public void ParseASequence()
        {
            var parser = Combinators.Sequence(Parsers.Str("hello"),Parsers.Str("world"));
            dynamic result = parser(Strings.Text2.Source());
            Assert.AreEqual("hello", result[0]);
            Assert.AreEqual("world", result[1]);
        }
    }
}
