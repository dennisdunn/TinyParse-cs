using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyParse;

namespace TinyParseTests
{
    [TestClass]
    public class BuilderTests
    {
        [TestMethod]
        public void ChrParser()
        {
            var p = Parsers.Str("h");
            Assert.IsInstanceOfType(p, typeof(Parser));
        }

        [TestMethod]
        public void RunCStrParser()
        {
            var input = new Text(Constants.Hello);
            var p = Parsers.Str("h");
            var c = p(input);
            Assert.IsNotNull(c);
            Assert.AreEqual("h", c.ToString());
        }

        [TestMethod]
        public void RunAnyOfParser()
        {
            var input = new Text(Constants.Hello);
            var p = Parsers.AnyOf("efghijk");
            var c = p(input);
            Assert.IsNotNull(c);
            Assert.AreEqual("h", c.ToString());
            Assert.AreEqual(1, input.Offset);
        }
    }
}
