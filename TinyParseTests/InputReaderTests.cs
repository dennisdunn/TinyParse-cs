using TinyParse;

namespace TinyParseTests
{
    [TestClass]
    public class InputReaderTests
    {
        [TestMethod]
        public void PeekOne()
        {
            var input = new Text(Constants.Hello);
            var s = input.Peek();
            Assert.AreEqual(s, "h");
            s = input.Peek();
            Assert.AreEqual(s, "h");
        }

        [TestMethod]
        public void ReadOne()
        {
            var input = new Text(Constants.Hello);
            var s = input.Read();
            Assert.AreEqual(s, "h");
            s = input.Read();
            Assert.AreEqual(s, "e");
        }

        [TestMethod]
        public void PeekMany()
        {
            var input = new Text(Constants.Hello);
            var s = input.Peek(5);
            Assert.AreEqual(s, "hello");
            s = input.Peek(5);
            Assert.AreEqual(s, "hello");
        }

        [TestMethod]
        public void ReadMany()
        {
            var input = new Text(Constants.Hello);
            var s = input.Read(5);
            Assert.AreEqual(s, "hello");
            s = input.Read();
            Assert.AreEqual(s, ",");
        }
    }
}