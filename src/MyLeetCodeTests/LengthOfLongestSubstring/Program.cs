using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace LengthOfLongestSubstring
{
    class Program
    {
        static void Main()
        {
            var random = new Random();

            var len = random.Next(50000);

            var ss = new char[len];
            for (var i = 0; i < len; i++)
            {
                ss[i] = (char) random.Next(32, 126);
            }

            string s = new string(ss);

            //Console.WriteLine(s);
            //s = "pwwkew";
            //s = "d";
            //s = "";
            //s = "sddsd";

            var stopwatch = new Stopwatch();

            Console.WriteLine("字符串：");
            Console.WriteLine(s);
            Console.WriteLine($"总长度：{s.Length}");

            stopwatch.Start();
            len = LengthOfLongestSubstring(s);
            stopwatch.Stop();
            Console.WriteLine($"长度：{len}，耗时：{stopwatch.ElapsedMilliseconds}");

            stopwatch.Restart();
            len = LengthOfLongestSubstringFor(s);
            stopwatch.Stop();
            Console.WriteLine($"官方长度：{len}，耗时：{stopwatch.ElapsedMilliseconds}");

            Console.Read();
        }

        public static int LengthOfLongestSubstring(string s)
        {
            var set = new Dictionary<char, int>();

            var longString = "";

            int longStartIndex = -1, longLength = 0;

            var n = s.Length;
            var start = -1;

            for (int i = 0; i < n; i++)
            {
                var c = s[i];

                if (set.ContainsKey(c))
                {
                    //记录新的子字符串开头（左边界）
                    //从重复字符的上个位置的下个索引接着走
                    i = start = set[c];

                    set.Clear();

                    continue;
                }

                set.Add(c, i);

                //左边界到当前位置的长度
                var length = i - start;
                if (longLength >= length) continue;
                longStartIndex = start;
                longLength = length;
                
            }
            //longString = s.Substring(start + 1, length);
            Console.WriteLine($"最长不重复字符串：{s.Substring(longStartIndex + 1, longLength)}");

            return longLength;
        }


        public static int LengthOfLongestSubstringFor(string s)
        {
            ISet<char> occ = new HashSet<char>();
            var n = s.Length;

            // 右指针，初始值为 -1，相当于我们在字符串的左边界的左侧，还没有开始移动
            int rk = -1, ans = 0;
            for (var i = 0; i < n; ++i)
            {
                if (i != 0)
                {
                    // 左指针向右移动一格，移除一个字符
                    occ.Remove(s[i - 1]);
                }

                while (rk + 1 < n && !occ.Contains(s[rk + 1]))
                {
                    // 不断地移动右指针
                    occ.Add(s[rk + 1]);
                    ++rk;
                }

                // 第 i 到 rk 个字符是一个极长的无重复字符子串
                ans = Math.Max(ans, rk - i + 1);
            }

            return ans;
        }
    }
}