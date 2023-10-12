using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyParse;

namespace TinyParseTests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void SyntaxErrorTest()
        {
            Assert.ThrowsException<SyntaxError>(() => Parsers.Str("world")(Strings.Text.Source()));
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
            var c = p(Strings.Text.Source());
            Assert.IsNotNull(c);
            Assert.AreEqual("h", c.ToString());
        }

        [TestMethod]
        public void RunAnyOfParser()
        {
            var source = Strings.Text.Source();
            var p = Parsers.AnyOf("efghijk");
            var c = p(source);
            Assert.IsNotNull(c);
            Assert.AreEqual("h", c.ToString());
            Assert.AreEqual(1, source.Position);
        }
    }
}
