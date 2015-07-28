using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество чисел");
            int N = Convert.ToInt32(Console.ReadLine());
            int sum =0;
            Console.WriteLine("Введите указанное количество чисел через Enter");
            for (int i=0; i < N; i++)
            {
                sum = sum + Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Сумма чисел равна"+" "+sum);
            Console.ReadLine();
        }
    }
}
