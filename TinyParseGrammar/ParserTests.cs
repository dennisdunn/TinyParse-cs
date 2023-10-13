using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyParse;

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
    }
}