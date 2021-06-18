using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            int len = (int)Math.Pow(10, 4);
            int absValue = (int)Math.Pow(10, 9);

            var nums = new int[len];
            int target = 0;

            int min = -absValue - 1;
            int max = absValue;

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = random.Next(min, max);
            }

            do
            {
                int first = random.Next(len);
                int second = random.Next(len);

                if (first == second)
                    continue;

                target = nums[first] + nums[second];

                //if(absValue>=num>=absValue){}
            } while (target > absValue || target < -absValue);


            Console.WriteLine($"输入：");
            Console.WriteLine($"nums:[{string.Join(',', nums)}]");
            Console.WriteLine($"target:{target}");

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int[] result = TwoSum(nums, target);
            for (int i = 0; i < 1000; i++)
            {
                result = TwoSum(nums, target);
            }

            stopwatch.Stop();

            Console.WriteLine($"耗时：{stopwatch.ElapsedMilliseconds}");

            if (result.Length == 0)
                Console.WriteLine("未找到对应得值");
            else
            {
                Console.WriteLine($"答案[{result[0]},{result[1]}]");
                Console.WriteLine($"对应的值[{nums[result[0]]},{nums[result[1]]}]");
            }

            Console.Read();
        }

        static int[] TwoSum(int[] nums, int target)
        {
            var len = nums.Length;

            var set = new Dictionary<int, int>();

            for (int i = 0; i < len; i++)
            {
                var num = nums[i];

                int sNum = target - num;
                if (set.ContainsKey(sNum))
                {
                    return new[] { set[sNum], i };
                }

                if (!set.ContainsKey(num))
                    set.Add(num, i);
            }

            return Array.Empty<int>();
        }
    }
}