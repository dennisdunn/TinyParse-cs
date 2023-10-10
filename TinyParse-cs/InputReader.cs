using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyParse
{
    public interface IInputReader
    {
        string Text { get; }
        string Read(int length = 1);
        string Peek(int length = 1);
        void Seek(int index = 0);
    }
    public class InputReader : IInputReader
    {
        private int _offset = 0;
        public string Text { get; private set; }=string.Empty;

        public InputReader()
        {

        }

        public InputReader(string text)
        {
            Text = text;
        }
        public string Peek(int length = 1)
        {
            return Text.Substring(_offset, length);
        }

        public string Read(int length = 1)
        {
            var value = Peek(length);
            _offset += length;
            return value;
        }

        public void Seek(int index = 0)
        {
            _offset = index;
        }
    }
}
