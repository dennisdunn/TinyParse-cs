using TinyParse;

namespace TinyParseTests
{
    [TestClass]
    public class SourceTextTests : BaseTest
    {
        [TestMethod]
        public void SeekError()
        {
            Assert.ThrowsException<SeekError>(() => TextInput.Seek(100));
        }

        [TestMethod]
        public void PeekOne()
        {

            var s = TextInput.Peek();
            Assert.AreEqual(s, "h");
            s = TextInput.Peek();
            Assert.AreEqual(s, "h");
        }

        [TestMethod]
        public void ReadOne()
        {

            var s = TextInput.Read();
            Assert.AreEqual(s, "h");
            s = TextInput.Read();
            Assert.AreEqual(s, "e");
        }

        [TestMethod]
        public void PeekMany()
        {

            var s = TextInput.Peek(5);
            Assert.AreEqual(s, "hello");
            s = TextInput.Peek(5);
            Assert.AreEqual(s, "hello");
        }

        [TestMethod]
        public void ReadMany()
        {

            var s = TextInput.Read(5);
            Assert.AreEqual(s, "hello");
            s = TextInput.Read();
            Assert.AreEqual(s, ",");
        }
    }
}