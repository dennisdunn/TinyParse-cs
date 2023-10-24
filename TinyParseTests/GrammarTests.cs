using TinyParse;

namespace TinyParseTests
{
    [TestClass]
    public class GrammarTests
    {
        Grammar G { get; init; } = new Grammar();

        [TestMethod]
        public void ParseDigits()
        {
            var result = G.Digits("388".Source());
            Assert.AreEqual("388", result);
        }

        [TestMethod]
        public void ParseDecimal()
        {
            var result = G.Decimal(".388".Source());
            Assert.AreEqual(".388", result);
        }

        [TestMethod]
        public void ParseInteger()
        {
            var source = "388".Source();
            var result = G.Signed(source);
            Assert.AreEqual("388", result);
        }

        [TestMethod]
        public void ParsePosFloat()
        {
            var result = G.Signed("3.88".Source());
            Assert.AreEqual("3.88", result);
        }

        [TestMethod]
        public void ParseNegFloat()
        {
            var result = G.Signed("-3.88".Source());
            Assert.AreEqual("-3.88", result);
        }

        [TestMethod]
        public void ParseNumberInt()
        {
            var result = G.Number("388".Source());
            Assert.AreEqual("388", result);
        }

        [TestMethod]
        public void ParseNumberIntWS()
        {
            var result = G.Number("    388".Source());
            Assert.AreEqual("388", result);
        }

        [TestMethod]
        public void ParseNumberFloat()
        {
            var result = G.Number("    3.88".Source());
            Assert.AreEqual("3.88", result);
        }

        [TestMethod]
        public void ParseSign()
        {
            var source = "+-".Source();
            var result = G.Sign(source);
            Assert.AreEqual("+", result);
        }

        [TestMethod]
        public void ParseOptionalSign()
        {
            var source = "388".Source();
            var result = Combinators.Optional(G.Sign)(source);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ParseTheSignedComponents()
        {
            var source = "-388.9".Source();
            var s = Combinators.Optional(G.Sign)(source);
            var d = G.Digits(source);
            var f = Combinators.Optional(G.Decimal)(source);
            Assert.AreEqual("-", s);
            Assert.AreEqual("388", d);
            Assert.AreEqual(".9", f);
        }

        [TestMethod]
        public void ParseGrammaarTerminalComponents()
        {
            var source = "1 + 1".Source();
            var a0 = G.Number(source);
            var op = G.SumOp(source);
            var a1 = G.Number(source);
            Assert.AreEqual("1", a0);
            Assert.AreEqual("+", op);
            Assert.AreEqual("1", a1);
        }

        [TestMethod]
        public void ParseGrammaarTerminalComponentsSequence()
        {
            var source = "1 + 1".Source();
            var parser = Combinators.Sequence(G.Number, G.SumOp, G.Number);
            var result = parser(source);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("+", result[1]);
        }

        [TestMethod]
        public void ParseFactor()
        {
            var source = "1 + 1".Source();
            var parser = G.Factor;
            var result = parser(source);
            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public void ParseGrammarNonterminalComponent()
        {
            var source = "1 + 1".Source();
            var a0 = G.Factor(source);
            var op = G.SumOp(source);
            var a1 = G.Factor(source);
            Assert.AreEqual("+", op);
        }

        [TestMethod]
        public void ParseGrammar()
        {
            var source = "1 + 1".Source();
            var result = G.Expr(source);
            Assert.IsNotNull(result);
            Assert.AreEqual("1", result[0][0]);
            Assert.AreEqual("+", result[1][0]);
        }

        [TestMethod]
        public void ParseAnumericalNumber()
        {
            var parser = Combinators.Apply(G.Signed, value => float.Parse(value));
            var result = parser("-3.88".Source());
            Assert.AreEqual(-3.88, result, 0.001);
        }
    }
}