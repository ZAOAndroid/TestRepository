using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите два числа через клавишу Enter");
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());
            int summ = x + y;
            Console.WriteLine("Сумма введенных чисел = "+summ);
            Console.ReadLine();

        }
    }
}
