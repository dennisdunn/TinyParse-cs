namespace TinyParse
{
    public interface IText
    {
        int Position { get; }
        string Source { get; }
        string Read(int length = 1);
        string Peek(int length = 1);
        void Seek(int position = 0);
    }
    public class Text : IText
    {
        public int Position { get; private set; }
        public string Source { get; init; }

        public Text(string str)
        {
            Source = str;
        }

        public string Peek(int length = 1)
        {
            try
            {
                return Source.Substring(Position, length);
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
            if (position < 0 || position >= Source.Length)
            {
                throw new BoundsError();
            }
            else
            {
                Position = position;
            }
        }
    }
}
