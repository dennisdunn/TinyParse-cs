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
            var p = Builders.Chr('h');
            Assert.IsInstanceOfType(p, typeof(Parser));
        }

        [TestMethod]
        public void RunChrParser()
        {
            var input = new InputReader(Constants.Hello);
            var p = Builders.Chr('h');
            var c = p(input);
            Assert.IsNotNull(c);
            Assert.AreEqual("h", c.ToString());
        }

        [TestMethod]
        public void RunAnyOfParser()
        {
            var input = new InputReader(Constants.Hello);
            var p = Builders.AnyOf("efghijk");
            var c = p(input);
            Assert.IsNotNull(c);
            Assert.AreEqual("h", c.ToString());
        }
    }
}
