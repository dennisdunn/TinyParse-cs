using TinyParse;

namespace TinyParseTests
{
    [TestClass]
    public class CombinatorTests
    {

        [TestMethod]
        public void ParseAString()
        {
            var parser = Combinators.Str("hello");
            dynamic? result = parser(Strings.Text.Source());
            Assert.AreEqual("hello", result);
        }

        [TestMethod]
        public void ParseNumber()
        {
            var digits = Combinators.Many(Combinators.AnyOf(Strings.Digits));
            var sign = Combinators.Optional(Combinators.AnyOf(Strings.Sign));
            var fractional = Combinators.Optional(Combinators.All(Combinators.Str("."), digits));
            var number = Combinators.All(sign, digits, fractional);

            var result = number(Strings.Float.Source());
            Assert.AreEqual(Strings.Float, result);
        }

        [TestMethod]
        public void ParseDigit()
        {
            var digit = Combinators.AnyOf(Strings.Digits);

            var result = digit(Strings.Integer.Source());
            Assert.AreEqual("3", result);
        }

        [TestMethod]
        public void ParseDigits()
        {
            var digits = Combinators.Many(Combinators.AnyOf(Strings.Digits));

            var result = digits(Strings.Integer.Source());
            Assert.AreEqual(Strings.Integer, result);
        }

        [TestMethod]
        public void ParseOneOrTheOther()
        {
            // Tests whether the first failed parse resets the position of the input.
            var digit = Combinators.Any(Combinators.Str("8"), Combinators.Str("3"));
            var source = Strings.Integer.Source();
            var result = digit(source);
            Assert.AreEqual("3", result);
            Assert.AreEqual(1, source.Position);
        }

        [TestMethod]
        public void ParseASequence()
        {
            var parser = Combinators.Sequence(Combinators.Str("hello"), Combinators.Str("world"));
            var result = parser(Strings.Text2.Source());
            Assert.AreEqual("hello", result[0]);
            Assert.AreEqual("world", result[1]);
        }

        [TestMethod]
        public void ParseAndApply()
        {
            var parser = Combinators.Apply(Combinators.Str("hello"), s => s.ToUpper());
            var result = parser(Strings.Text.Source());
            Assert.AreEqual("HELLO", result);
        }

        [TestMethod]
        public void SyntaxErrorDoesntChangePosition()
        {
            var source = Strings.Text.Source();
            var parser = Combinators.Str("world");
            Assert.ThrowsException<SyntaxError>(() => parser(source));
            Assert.AreEqual(0, source.Position);
        }

        [TestMethod]
        public void ParseOptional()
        {
            var source = Strings.Text.Source();
            var parser = Combinators.Optional(Combinators.Str("0"));
            var result = parser(source);
            Assert.AreEqual(0, source.Position);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ParseOptionalMany()
        {
            var source = Strings.Text.Source();
            var parser = Combinators.Optional(Combinators.Many(Combinators.AnyOf(Strings.Lower)));
            var result = parser(source);
            Assert.AreEqual(5, source.Position);
            Assert.AreEqual("hello", result);
        }

        [TestMethod]
        public void ParseOptionalManyFails()
        {
            var source = Strings.Integer.Source();
            var parser = Combinators.Optional(Combinators.Many(Combinators.AnyOf(Strings.Lower)));
            var result = parser(source);
            Assert.AreEqual(0, source.Position);
            Assert.IsNull(result);
        }
    }
}
