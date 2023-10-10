using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyParse
{
    public interface IText
    {
        string Read(int length = 1);
        string Peek(int length = 1);
        int Offset { get; }
        void Seek(int offset=0);
    }
    public class Text : IText
    {
        private int _offset = 0;
        private string _text;

        public int Offset => _offset;

        public Text(string text)
        {
            _text = text;
        }
        public string Peek(int length = 1)
        {
            return _text.Substring(_offset, length);
        }

        public string Read(int length = 1)
        {
            var value = Peek(length);
            _offset += length;
            return value;
        }
        public void Seek(int offset = 0)
        {
            _offset = offset;
        }
    }
}
