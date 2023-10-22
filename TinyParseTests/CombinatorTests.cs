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
        public void ParseAString()
        {
            var parser =
                BaseGrammar.Str("hello");
            dynamic result = parser(Strings.Text.Source());
            Assert.AreEqual("hello", result);
        }

        [TestMethod]
        public void ParseNumber()
        {
            var digits = BaseGrammar.Many(BaseGrammar.AnyOf(Strings.Digits));
            var sign = BaseGrammar.Optional(BaseGrammar.AnyOf(Strings.Sign));
            var fractional = BaseGrammar.Optional(BaseGrammar.All(BaseGrammar.Str("."), digits));
            var number = BaseGrammar.All(sign, digits, fractional);

            var result = number(Strings.Float.Source());
            Assert.AreEqual(Strings.Float, result);
        }

        [TestMethod]
        public void ParseDigit()
        {
            var digit = BaseGrammar.AnyOf(Strings.Digits);

            var result = digit(Strings.Integer.Source());
            Assert.AreEqual("3", result);
        }

        [TestMethod]
        public void ParseDigits()
        {
            var digits = BaseGrammar.Many(BaseGrammar.AnyOf(Strings.Digits));

            var result = digits(Strings.Integer.Source());
            Assert.AreEqual(Strings.Integer, result);
        }

        [TestMethod]
        public void ParseOneOrTheOther()
        {
            // Tests whether the first failed parse resets the position of the input.
            var digit = BaseGrammar.Any(BaseGrammar.Str("8"), BaseGrammar.Str("3"));
            var source = Strings.Integer.Source();
            var result = digit(source);
            Assert.AreEqual("3", result);
            Assert.AreEqual(1, source.Position);
        }

        [TestMethod]
        public void ParseASequence()
        {
            var parser = BaseGrammar.Sequence(BaseGrammar.Str("hello"), BaseGrammar.Str("world"));
            var result = (List<object>)parser(Strings.Text2.Source());
            Assert.AreEqual("hello", result[0]);
            Assert.AreEqual("world", result[1]);
        }

        [TestMethod]
        public void ParseAndApply()
        {
            var parser = BaseGrammar.Apply(BaseGrammar.Str("hello"), s => ((string)s).ToUpper());
            var result = (string)parser(Strings.Text.Source());
            Assert.AreEqual("HELLO", result);
        }

        [TestMethod]
        public void SyntaxErrorDoesntChangePosition()
        {
            var source = Strings.Text.Source();
            var parser = BaseGrammar.Str("world");
            Assert.ThrowsException<SyntaxError>(() => parser(source));
            Assert.AreEqual(0, source.Position);
        }

        [TestMethod]
        public void ParseOptional()
        {
            var source = Strings.Text.Source();
            var parser = BaseGrammar.Optional(BaseGrammar.Str("0"));
            var result = parser(source);
            Assert.AreEqual(0, source.Position);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ParseOptionalMany()
        {
            var source = Strings.Text.Source();
            var parser = BaseGrammar.Optional(BaseGrammar.Many(BaseGrammar.AnyOf(Strings.Lower)));
            var result = parser(source);
            Assert.AreEqual(5, source.Position);
            Assert.AreEqual("hello", result);
        }

        [TestMethod]
        public void ParseOptionalManyFails()
        {
            var source = Strings.Integer.Source();
            var parser = BaseGrammar.Optional(BaseGrammar.Many(BaseGrammar.AnyOf(Strings.Lower)));
            var result = parser(source);
            Assert.AreEqual(0, source.Position);
            Assert.IsNull(result);
        }
    }
}
