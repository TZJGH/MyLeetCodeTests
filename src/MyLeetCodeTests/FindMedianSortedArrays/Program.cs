using System;
using System.Collections.Generic;


namespace FindMedianSortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = {1, 2};
            int[] nums2 = {3, 4};

            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine($"nums1:[{string.Join(",", nums1)}]");
            Console.WriteLine($"nums2:[{string.Join(",", nums2)}]");
            Console.WriteLine($"结果：{FindMedianSortedArrays(nums1, nums2)}");
            Console.WriteLine("--------------------------------------------------------------------\n");
        }


        static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int len1 = nums1.Length, len2 = nums2.Length;
            var len = len1 + len2;

            if (len == 0)
                return 0;

            int i = -1, i1 = 0, i2 = 0;
            var nums = new int[len];

            while (i1 < len1 && i2 < len2)
            {
                var num1 = nums1[i1];
                var num2 = nums2[i2];

                if (num1 < num2)
                {
                    nums[++i] = num1;
                    ++i1;
                }
                else
                {
                    nums[++i] = num2;
                    ++i2;
                }
            }

            while (i1 < len1)
            {
                nums[++i] = nums1[i1];
                ++i1;
            }

            while (i2 < len2)
            {
                nums[++i] = nums2[i2];
                ++i2;
            }

            var index = len >> 1;

            return len % 2 == 1 ? nums[index] : (nums[index - 1] + nums[index]) / 2.0d;
        }

        static double FindMedianSortedArrays1(int[] nums1, int[] nums2)
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