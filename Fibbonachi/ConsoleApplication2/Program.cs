using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число n для вычисления резульатата");
            var result = Fibonachi(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static int Fibonachi(int n)
        {
            if ((n == 1) | (n == 2))
                return 1;
            else
            {
                Console.WriteLine("Результат:");
                return Fibonachi(n - 1) + Fibonachi(n - 2);
            }
        }
    }
}
