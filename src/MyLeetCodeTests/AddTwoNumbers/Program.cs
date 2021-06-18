using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace AddTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int count = 1568;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(
                    "-----------------------------------------------------------------------------------");
                var l1 = CreateList(20);
                var l2 = CreateList(15);

                DisPlay(l1);
                DisPlay(l2);

                DisPlay(AddTwoNumbers(l1, l2));
            }

            stopwatch.Stop();

            Console.WriteLine($"耗时：{stopwatch.ElapsedMilliseconds/count}");
        }


        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var firstNode = new ListNode();

            var lastNode = firstNode;

            int into = 0;

            while (true)
            {
                bool b1 = l1 != null;
                bool b2 = l2 != null;

                ListNode node;
                if (!(b1 || b2))
                {
                    if (into > 0)
                    {
                        node = new ListNode(into);
                        lastNode.next = node;
                    }

                    break;
                }

                int value = into;
                if (b1)
                {
                    value += l1.val;
                    l1 = l1.next;
                }

                if (b2)
                {
                    value += l2.val;
                    l2 = l2.next;
                }

                into = value / 10;

                node = new ListNode(value % 10);
                lastNode.next = node;
                lastNode = node;
            }

            return firstNode.next;
        }


        private static void DisPlay(ListNode listNode)
        {
            Console.WriteLine($"[{string.Join(',', GetValues(listNode))}]");
        }

        private static IEnumerable<int> GetValues(ListNode listNode)
        {
            while (listNode != null)
            {
                yield return listNode.val;
                listNode = listNode.next;
            }
        }

        private static ListNode CreateList(int len)
        {
            ListNode l = new ListNode();

            ListNode lastNode = l;
            var random = new Random();
            for (int i = 0; i < len; i++)
            {
                lastNode.next = new ListNode(random.Next(9));
                lastNode = lastNode.next;
            }

            return l.next;
        }
    }


    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}