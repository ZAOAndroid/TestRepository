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
            try
            {
                int z = 0;
                int x, y;
                // Калькулятор
                Console.WriteLine("Введите первой число");

                // здесь надо отлаливать ошибки, что бы не было букв и оверчисел

                bool xx = Int32.TryParse(Console.ReadLine(), out checked(x));
                Console.WriteLine("Введите второе число");
                bool yy = Int32.TryParse(Console.ReadLine(), out checked(y));

                // ввод знака
                Console.WriteLine("Введите арифетическую операцию");
                // считаем, если ввод прошел проверку
                string s = Console.ReadLine();
                if ((xx != false) && (yy != false))
                {
                    if
                    (s == "+")
                    {
                        z = checked(x + y);
                        Console.WriteLine(z);
                    }
                    else
                        if (s == "-")
                        {
                            z = checked(x - y);
                            Console.WriteLine(z);
                        }
                        else
                            if (s == "*")
                            {
                                z = checked(x * y);
                            }
                            else
                                if ((s == "/") && (y != 0))
                                {
                                    z = checked(x / y);
                                    Console.WriteLine(z);
                                }
                                else { Console.WriteLine("Ввод некорректен"); }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
                //ловим исключения
            catch (Exception e)
            { Console.WriteLine("poimali" + " " + e.ToString()); }

            Console.ReadLine();

        }
    }
}
