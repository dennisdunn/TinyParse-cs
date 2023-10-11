using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyParse;

namespace TinyParseTests
{
    [TestClass]
    public class ParserTests : BaseTest
    {
        [TestMethod]
        public void SyntaxErrorTest()
        {
            Assert.ThrowsException<SyntaxError>(() => Parsers.Str("world")(TextInput));
        }

        [TestMethod]
        public void ChrParser()
        {
            var p = Parsers.Str("h");
            Assert.IsInstanceOfType(p, typeof(Parser));
        }

        [TestMethod]
        public void RunStrParser()
        {

            var p = Parsers.Str("h");
            var c = p(TextInput);
            Assert.IsNotNull(c);
            Assert.AreEqual("h", c.ToString());
        }

        [TestMethod]
        public void RunAnyOfParser()
        {

            var p = Parsers.AnyOf("efghijk");
            var c = p(TextInput);
            Assert.IsNotNull(c);
            Assert.AreEqual("h", c.ToString());
            Assert.AreEqual(1, TextInput.Position);
        }
    }
}
