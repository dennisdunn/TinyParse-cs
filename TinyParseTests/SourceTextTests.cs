using TinyParse;

namespace TinyParseTests
{
    [TestClass]
    public class SourceTextTests
    {
        [TestMethod]
        public void SeekError()
        {
            var source =Strings.Text.Source();
            Assert.ThrowsException<SeekError>(() => source.Seek(100));
        }

        [TestMethod]
        public void PeekOne()
        {
            var source = Strings.Text.Source();
            var s = source.Peek();
            Assert.AreEqual(s, "h");
            s = source.Peek();
            Assert.AreEqual(s, "h");
        }

        [TestMethod]
        public void ReadOne()
        {
            var source = Strings.Text.Source();
            var s = source.Read();
            Assert.AreEqual(s, "h");
            s = source.Read();
            Assert.AreEqual(s, "e");
        }

        [TestMethod]
        public void PeekMany()
        {
            var source = Strings.Text.Source();
            var s = source.Peek(5);
            Assert.AreEqual(s, "hello");
            s = source.Peek(5);
            Assert.AreEqual(s, "hello");
        }

        [TestMethod]
        public void ReadMany()
        {
            var source = Strings.Text.Source();
            var s = source.Read(5);
            Assert.AreEqual(s, "hello");
            s = source.Read();
            Assert.AreEqual(s, ",");
        }
    }
}