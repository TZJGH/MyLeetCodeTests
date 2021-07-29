/*
 * 最长回文字符串
 */

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
            s = "a";
            //s = "ac";
            //s = "ccc";
            //s = "acbccbcc";
            //s = "acbccc";
            //s = "abcbccc";
            s = "";
            //s = "aacabdkacaa";
            //s = "bb";

            Console.WriteLine(LongestPalindrome(s));
        }


        public static string LongestPalindrome(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return s;

            int startIndex = 0;
            int maxLen = 0;

            var length = s.Length;

            for (var i = 0; i < length; i++)
            {
                var iii = new int[2][];

                iii[0] = new[] {i, i + 1};
                iii[1] = new[] {i - 1, i + 1};

                foreach (var ii in iii)
                {
                    var leftIndex = ii[0];
                    var rightIndex = ii[1];

                    while (leftIndex > -1 && rightIndex < length)
                    {
                        if (s[leftIndex] == s[rightIndex])
                        {
                            if (maxLen < rightIndex - leftIndex)
                            {
                                startIndex = leftIndex;
                                maxLen = rightIndex - leftIndex;
                            }

                            --leftIndex;
                            ++rightIndex;

                            continue;
                        }

                        break;
                    }
                }
            }


            return s.Substring(startIndex, maxLen + 1);
        }
    }
}