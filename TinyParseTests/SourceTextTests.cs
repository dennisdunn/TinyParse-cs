using TinyParse;

namespace TinyParseTests
{
    [TestClass]
    public class SourceTextTests : BaseTest
    {
        [TestMethod]
        public void SeekError()
        {
            Assert.ThrowsException<SeekError>(() => Input.Seek(100));
        }

        [TestMethod]
        public void PeekOne()
        {

            var s = Input.Peek();
            Assert.AreEqual(s, "h");
            s = Input.Peek();
            Assert.AreEqual(s, "h");
        }

        [TestMethod]
        public void ReadOne()
        {

            var s = Input.Read();
            Assert.AreEqual(s, "h");
            s = Input.Read();
            Assert.AreEqual(s, "e");
        }

        [TestMethod]
        public void PeekMany()
        {

            var s = Input.Peek(5);
            Assert.AreEqual(s, "hello");
            s = Input.Peek(5);
            Assert.AreEqual(s, "hello");
        }

        [TestMethod]
        public void ReadMany()
        {

            var s = Input.Read(5);
            Assert.AreEqual(s, "hello");
            s = Input.Read();
            Assert.AreEqual(s, ",");
        }
    }
}