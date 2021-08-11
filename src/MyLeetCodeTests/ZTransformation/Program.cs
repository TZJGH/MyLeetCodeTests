using System;
using System.Text;

namespace ZTransformation
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            const string s = "PAYPALISHIRING";
            var str = Convert(s, 3);

            Console.WriteLine(str);
        }

        private static string Convert(string s, int numRows)
        {
            if (string.IsNullOrWhiteSpace(s))
                return s;

            if (numRows == 1)
                return s;

            var r = new StringBuilder[numRows];
            for (var i = 0; i < numRows; i++)
            {
                r[i] = new StringBuilder();
            }

            var len = s.Length;
            var numRowsIndex = numRows - 1;
            var pageSize = 2 * numRowsIndex;

            for (var i = 0; i < len; i++)
            {
                var rowIndex = numRowsIndex - Math.Abs(i % pageSize + 1 - numRows);

                r[rowIndex].Append(s[i]);
            }

            var sb = new StringBuilder(len);
            foreach (var t in r)
            {
                sb.Append(t);
            }

            return sb.ToString();
        }
    }
}