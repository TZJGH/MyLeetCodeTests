using System;
using System.Collections.Generic;
using System.Linq;


namespace FindMedianSortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = {1, 1};
            int[] nums2 = {1, 2};
            Console.WriteLine($"nums1:[{string.Join(",", nums1)}]");

            Console.WriteLine($"nums2:[{string.Join(",", nums2)}]");
            Console.WriteLine($"结果：{FindMedianSortedArrays(nums1, nums2)}");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine();
        }


        static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var len = nums1.Length + nums2.Length;

            if (len == 0)
                return 0;

            var queue1 = new Queue<int>(nums1);
            var queue2 = new Queue<int>(nums2);

            var i = -1;
            var nums = new int[len];

            while (queue1.Count > 0 && queue2.Count > 0)
            {
                nums[++i] = queue1.Peek() > queue2.Peek() ? queue2.Dequeue() : queue1.Dequeue();
            }

            while (queue1.Count > 0)
            {
                nums[++i] = queue1.Dequeue();
            }

            while (queue2.Count > 0)
            {
                nums[++i] = queue2.Dequeue();
            }


            if (len % 2 == 1)
            {
                return nums[len >> 1];
            }

            var index = len >> 1;
            return (nums[index - 1] + nums[index]) / 2.0d;
        }
    }
}