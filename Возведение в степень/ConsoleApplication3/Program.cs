using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            double x,n;
            double xor = 0;
            try
            {
                Console.WriteLine("Введите число");
                x = checked(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Введите степень для нового числа");
                n = checked(Convert.ToInt32(Console.ReadLine()));
                xor = checked(Math.Pow(x, n)); //эта функция вроде как поудачнее, чем "^", но исключение не ловит, пишет "?"
            }
                //исключение переполнения
            catch (System.OverflowException e)
            {
                Console.WriteLine("Слишком большое число" + e.ToString());
            }
            Console.WriteLine (/*"{0:E}",*/xor); //можно и с E выводить, не знаю, как лучше
            Console.ReadLine();


        }

    }
}
