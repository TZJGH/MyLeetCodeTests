using System;
using System.Collections.Generic;

namespace LongestPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "babad";
            s = "cbbd";
            s = "a";
            s = "ac";
            s = "";

            Console.WriteLine(LongestPalindrome(s));
        }


        public static string LongestPalindrome(string s)
        {

            if (string.IsNullOrWhiteSpace(s))
                return s;
            
            var set = new Dictionary<char, int>();

            var len = s.Length;

            int start = 0, length = 0;
            for (var i = 0; i < len; i++)
            {
                var c = s[i];
                if (set.ContainsKey(c))
                {
                    var index = set[c];

                    if (length < i - index)
                    {
                        length = i - index;
                        start = index;
                    }

                    set.Remove(c);
                }

                set.Add(c, i);
            }

            return s.Substring(start, length + 1);
        }
    }
}