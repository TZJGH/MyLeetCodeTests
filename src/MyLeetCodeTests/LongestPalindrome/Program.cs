using System;
using System.Collections.Generic;

namespace LongestPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "babad";
            //s = "cbbbd";
            //s = "cbbd";
            //s = "a";
            //s = "ac";
            //s = "ccc";
            s = "acbcccc";
            //s = "acbccc";
            //s = "abcbccc";
            //s = "";
            //s = "aacabdkacaa";

            Console.WriteLine(LongestPalindrome(s));
        }


        public static string LongestPalindrome(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return s;

            int startIndex = 0, LongLen = 0;

            var length = s.Length;
            for (var i = 0; i < length; i++)
            {
                var c = s[i];

                if (i == 0)
                {
                    continue;
                }


                for (var j = 1; j < i + 1 && j + i < length; j++)
                {
                    var cn = s[i + j];
                    var cp = s[i - j];

                    Console.WriteLine($"i:{i} j:{j} {i + j}:{cn},{i - j}:{cp}");

                    if (cn == cp)
                    {
                        if (2 * j + 1 > LongLen)
                        {
                            startIndex = i - j;
                            LongLen = 2 * j + 1;
                        }

                        continue;
                    }

                    break;
                }

                for (var j = 1; j < i + 1 && j + i < length; j++)
                {
                    var cn = s[i + j];
                    var cp = s[i - 1];

                    Console.WriteLine($"i:{i} j:{j} {i + j}:{cn},{i - j}:{cp}");

                    if (cn == cp)
                    {
                        if (j + 2 > LongLen)
                        {
                            startIndex = i - 1;
                            LongLen = j + 2;
                        }

                        continue;
                    }

                    break;
                }
            }


            return s.Substring(startIndex, LongLen);
        }
    }
}