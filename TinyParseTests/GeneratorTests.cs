using TinyParse;

namespace TinyParseTests
{
    [TestClass]
    public class GeneratorTests
    {
        [TestMethod]
        public void SyntaxErrorTest()
        {
            Assert.ThrowsException<SyntaxError>(() => Combinators.Str("world")(Strings.Text.ToInput()));
        }

        [TestMethod]
        public void ChrParser()
        {
            var p = Combinators.Str("h");
            Assert.IsInstanceOfType(p, typeof(Parser));
        }

        [TestMethod]
        public void RunStrParser()
        {

            var p = Combinators.Str("h");
            var c = p(Strings.Text.ToInput());
            Assert.IsNotNull(c);
            Assert.AreEqual("h", c.ToString());
        }

        [TestMethod]
        public void RunAnyOfParser()
        {
            var source = Strings.Text.ToInput();
            var p = Combinators.AnyOf("efghijk");
            var c = p(source);
            Assert.IsNotNull(c);
            Assert.AreEqual("h", c.ToString());
            Assert.AreEqual(1, source.Position);
        }
    }
}
