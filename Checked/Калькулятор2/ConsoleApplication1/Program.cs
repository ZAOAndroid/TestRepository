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
            // можно сделать ввод нескольких операция, т.е. четная/нечетная строка число/знак  
            Console.WriteLine("Введите в строку через пробел операнд1, арифметический знак и операнд2");
            double rez = 0;
            string s = Console.ReadLine();
            string[] st = s.Split(' ');
            double x = Convert.ToDouble(st[0]);
            double y = Convert.ToDouble(st[2]);
            string z = st[1];
            try
            {
                if (z == "+")
                {
                    rez = sum(x, y);
                    Console.WriteLine("Результат" + " " + rez);
                }
                else
                {
                    if (z == "-")
                    {
                        rez = min(x, y);
                        Console.WriteLine("Результат" + " " + rez);
                    }
                    else
                    {
                        if (z == "*")
                        {
                            rez = pr(x, y);
                            Console.WriteLine("Результат" + " " + rez);
                        }
                        else
                        {
                            if ((z == "/") && (y != 0))
                            {
                                rez = del(x, y);
                                Console.WriteLine("Результат" + " " + rez);
                            }
                            else
                            { Console.WriteLine("Ввод некорректен"); }
                        }
                    }
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e);
            }
            
            Console.ReadLine();
        }
        public static double sum(double a, double b)
        {
            double s = a + b;
            return s;
        }
        public static double min(double a, double b)
        {
            double s = a - b;
            return s;
        }
        public static double pr(double a, double b)
        {
            double s = a * b;
            return s;
        }
        public static double del(double a, double b)
        {
            double s = a / b;
            return s;
        }
    }
}
