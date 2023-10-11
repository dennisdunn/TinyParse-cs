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
        internal ISourceText Input { get; } = new SourceText(Constants.Text);

        [TestInitialize]
        public void Initialize()
        {
            Input.Seek();
        }
    }
}
