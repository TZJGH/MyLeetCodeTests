using System;
using System.Collections.Generic;

namespace FindMedianSortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] nums1 = {1, 3};
            int[] nums2 = {2};

            Console.WriteLine(FindMedianSortedArrays(nums1, nums2));
        }

        static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var nums = new List<int>();

            int i = 0, j = 0;
            for (i = 0; i < nums1.Length; i++)
            {
                for (j = 0; j < nums2.Length; j++)
                {
                    
                }
            }

            var len = nums.Count;

            switch (len)
            {
                case 0:
                    return 0;
                case 1:
                    return nums[0];
                case 2:
                    return (nums[0] + nums[1]) >> 1;
            }

            if (len % 2 == 1)
            {
                return nums[len >> 1];
            }

            var index = len >> 1;
            var first = nums[index - 1];
            var second = nums[index];

            return (first + second) >> 1;
        }
    }
}