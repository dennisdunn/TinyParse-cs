using TinyParse;

namespace TinyParseTests
{
    public static class Strings
    {
        public static string Text => "hello, world";
        public static string Text2 => "helloworld";
        public static string Integer => "388";
        public static string Float => "-3.88";
        public static string Digits => "1234567890";
        public static string Sign => "+-";
        public static string Whitespace => @" \t\n\l";
        public static string Lower=>"abcdefghijklmnopqrstuvwxyz";
    
        public static IText Source(this string str)
        {
            return new Text(str);
        }
    }
}
