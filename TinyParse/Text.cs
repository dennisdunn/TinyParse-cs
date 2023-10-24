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
        private readonly string _text;

        public int Position { get; private set; }

        public Text(string text)
        {
            _text = text;
        }
        public string Peek(int length = 1)
        {
            try
            {
                return _text.Substring(Position, length);
            }
            catch (Exception innerException)
            {
                throw new BoundsError(innerException);
            }
        }

        public string Read(int length = 1)
        {
            var value = Peek(length);
            Position += length;
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
                Position = position;
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
