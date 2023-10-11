using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyParse;

namespace TinyParseTests
{
    [TestClass]
    public abstract class BaseTest
    {
        internal ISourceText TextInput { get; } = new SourceText(Constants.Text);
        internal ISourceText IntegerInput { get; } = new SourceText(Constants.Integer);
        internal ISourceText FloatInput { get; } = new SourceText(Constants.Float);

        [TestInitialize]
        public void Initialize()
        {
            TextInput.Seek();
            IntegerInput.Seek();
            FloatInput.Seek();
        }
    }
}
