//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TinyParse;

//namespace TinyParseTests
//{
//    [TestClass]
//    public class CombinatorTests
//    {
//        [TestMethod]
//        public void ParseNumber()
//        {
//            var input = new Text("-3.88");

//            var digit = Parsers.AnyOf(Constants.Digits);
//            var digits = Combinators.Many(digit);
//            var sign = Combinators.Optional(Parsers.AnyOf(Constants.Sign));
//            var fractional = Combinators.Optional(Combinators.All(Parsers.Str("."), digits));
//            var number = Combinators.All(sign, digits, fractional);

//            var result = number(input);
//            Assert.AreEqual("-3.88", result);
//        }
//        [TestMethod]
//        public void ParseDigit()
//        {
//            var input = new Text("388");

//            var digit = Parsers.AnyOf(Constants.Digits);

//            var result = digit(input);
//            Assert.AreEqual("3", result);
//        }
//        [TestMethod]
//        public void ParseDigits()
//        {
//            var input = new Text("388");

//            var digits = Combinators.Many(Parsers.AnyOf(Constants.Digits));

//            var result = digits(input);
//            Assert.AreEqual("388", result);
//        }
//    }
//}
