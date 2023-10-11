using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyParse;

namespace TinyParseTests
{
    [TestClass]
    public class CombinatorTests : BaseTest
    {
        [TestMethod]
        public void ParseNumber()
        {
            var digits = Combinators.Many(Parsers.AnyOf(Constants.Digits));
            var sign = Combinators.Optional(Parsers.AnyOf(Constants.Sign));
            var fractional = Combinators.Optional(Combinators.All(Parsers.Str("."), digits));
            var number = Combinators.All(sign, digits, fractional);

            var result = number(FloatInput);
            Assert.AreEqual(Constants.Float, result);
        }

        [TestMethod]
        public void ParseDigit()
        {
            var digit = Parsers.AnyOf(Constants.Digits);

            var result = digit(IntegerInput);
            Assert.AreEqual("3", result);
        }

        [TestMethod]
        public void ParseDigits()
        {
            var digits = Combinators.Many(Parsers.AnyOf(Constants.Digits));

            var result = digits(IntegerInput);
            Assert.AreEqual(Constants.Integer, result);
        }
    }
}
