using TinyParse;

namespace TinyParseGrammar
{
    [TestClass]
    public class GrammarTests
    {
        [TestMethod]
        public void ParseDigits()
        {
            var result = Grammar.Digits("388".Source());
            Assert.AreEqual("388", result);
        }

        [TestMethod]
        public void ParseDecimal()
        {
            var result = Grammar.Decimal(".388".Source());
            Assert.AreEqual(".388", result);
        }

        [TestMethod]
        public void ParseInteger()
        {
            var source = "388".Source();
            var result = Grammar.Signed(source);
            Assert.AreEqual("388", result);
        }

        [TestMethod]
        public void ParsePosFloat()
        {
            var result = Grammar.Signed("3.88".Source());
            Assert.AreEqual("3.88", result);
        }

        [TestMethod]
        public void ParseNegFloat()
        {
            var result = Grammar.Signed("-3.88".Source());
            Assert.AreEqual("-3.88", result);
        }

        [TestMethod]
        public void ParseNumberInt()
        {
            var result = Grammar.number("388".Source());
            Assert.AreEqual("388", result);
        }

        [TestMethod]
        public void ParseNumberIntWS()
        {
            var result = Grammar.number("    388".Source());
            Assert.AreEqual("388", result);
        }

        [TestMethod]
        public void ParseNumberFloat()
        {
            var result = Grammar.number("    3.88".Source());
            Assert.AreEqual("3.88", result);
        }

        [TestMethod]
        public void ParseSign()
        {
            var source = "+-".Source();
            var result = Grammar.Sign(source);
            Assert.AreEqual("+", result);
        }

        [TestMethod]
        public void ParseOptionalSign()
        {
            var source = "388".Source();
            var result = Grammar.Sign.Optional()(source);
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void ParseTheSignedComponents()
        {
            var source = "-388.9".Source();
            var s = Grammar.Sign.Optional()(source);
            var d = Grammar.Digits(source);
            var f = Grammar.Decimal.Optional()(source);
        }

        [TestMethod]
        public void ParseGrammaarTerminalComponents()
        {
            var source = "1 + 1".Source();
            var a0 = Grammar.number(source);
            var op = Grammar.sum(source);
            var a1 = Grammar.number(source);
        }

        [TestMethod]
        public void ParseGrammaarTerminalComponentsSequence()
        {
            var source = "1 + 1".Source();
            var parser = new[] { Grammar.number, Grammar.sum, Grammar.number }.Sequence();
            var result = parser(source);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("+", result[1]);
        }

        [TestMethod]
        public void ParseFactor()
        {
            var source = "1 + 1".Source();
            var parser = Grammar.Factor;
            var result = parser(source);
            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public void ParseGrammarNonterminalComponent()
        {
            var source = "1 + 1".Source();
            var a0 = Grammar.Factor(source);
            var op = Grammar.Expr_Prime(source);
            var a1 = Grammar.Factor(source);
            Assert.AreEqual("+", op);
        }

        [TestMethod]
        public void ParseGrammar()
        {
            var source = "1 + 1".Source();
            var result =  Grammar.Start(source);
        }
    }
}