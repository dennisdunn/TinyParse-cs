namespace TinyParseGrammar
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void ParseInteger()
        {
            var result = Parsers.Number("388".AsSrc());
            Assert.AreEqual("388", result);
        }

        [TestMethod]
        public void ParseFloat()
        {
            var result = Parsers.Number("3.88".AsSrc());
            Assert.AreEqual("3.88", result);
        }
        [TestMethod]
        public void IgnoreWsAndParseInteger()
        {
            var parser = Parsers.Number.IgnoreWsBefore();
            var result = parser("388".AsSrc());
            Assert.AreEqual("388", result);
        }
    }
}