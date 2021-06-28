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

            int startIndex = 0, longLen = 0;

            var length = s.Length;
            for (var i = 0; i < length; i++)
            {
                var c = s[i];

                if (i == 0)
                {
                    continue;
                }

                /*
                var leftIndex = 0;
                var rightIndex = i;
                */
                
                

                
            }


            return s.Substring(startIndex, longLen);
        }
    }
}