using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyParse
{
    public interface ISource
    {
        int Position { get; }
        string Read(int length = 1);
        string Peek(int length = 1);
        void Seek(int position = 0);
    }
    public class Source : ISource
    {
        private int _position = 0;
        private string _text;

        public int Position => _position;

        public Source(string text)
        {
            _text = text;
        }
        public string Peek(int length = 1)
        {
            try
            {
                return _text.Substring(_position, length);
            }
            catch (Exception innerException)
            {
                throw new BoundsError(innerException);
            }
        }

        public string Read(int length = 1)
        {
            var value = Peek(length);
            _position += length;
            return value;
        }

        public void Seek(int position = 0)
        {
            if (position < 0 || position >= _text.Length)
            {
                throw new BoundsError();
            }
            else
            {
                _position = position;
            }
        }
    }
}
