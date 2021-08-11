using System;

namespace IntegerReverse
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int x = -2147483648;


            Console.WriteLine($"{x}:{Reverse(x)}");
        }

        public static int Reverse(int x)
        {
            if (x == 0 || x == int.MaxValue || x == int.MinValue)
                return 0;


            var charArray = Math.Abs(x).ToString().ToCharArray();
            var len = charArray.Length;

            if (len > 10)
            {
                return 0;
            }


            var newCharArray = new char[len];
            for (var i = 0; i < len; i++)
            {
                newCharArray[i] = charArray[len - 1 - i];
            }

            if (len == 10)
            {
                var maxCharArray = "2147483647".ToCharArray();
                var minCharArray = "2147483648".ToCharArray();

                var array = x < 0 ? minCharArray : maxCharArray;
                for (var i = 0; i < 10; i++)
                {
                    var newValue = byte.Parse(newCharArray[i].ToString());
                    var value = byte.Parse(array[i].ToString());

                    if (newValue == value)
                    {
                        continue;
                    }

                    if (newValue < value)
                    {
                        break;
                    }

                    return 0;
                }
            }

            return int.Parse(string.Concat(newCharArray)) * (x > 0 ? 1 : -1);
        }
    }
}