using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TinyParse
{
    public interface IText
    {
        int Position { get; }
        string Read(int length = 1);
        string Peek(int length = 1);
        void Seek(int position = 0);
    }
    public class Text : IText
    {
        private int _position = 0;
        private readonly string _text;

        public int Position => _position;

        public Text(string text)
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
    public static class Extensions
    {
        public static IText Source(this string str)
        {
            return new Text(str);
        }
    }
}
