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
            int z = 0;
            int x,y;
            // Калькулятор
            Console.WriteLine("Введите первой число");

            // здесь надо отлаливать ошибки, что бы не было букв и оверчисел
            
            
                bool xx = Int32.TryParse(Console.ReadLine(), out x);
                Console.WriteLine("Введите второе число");
                bool yy = Int32.TryParse(Console.ReadLine(), out y);
                // ввод знака
                Console.WriteLine("Введите арифетическую операцию");
                // здесь надо отлаливать ошибки на всякую херню, можно проще, сразу вычисления делаем
                string s = Console.ReadLine();
                if ((xx != false) && (yy != false))
                {
                    
                    if
                    (s == "+")
                    {
                        z = x + y;
                        Console.WriteLine(z);
                    }
                    else
                        if (s == "-")
                        {
                            z = x - y;
                            Console.WriteLine(z);
                        }
                        else
                            if (s == "*")
                            {
                                    z = x * y;
                            }
                            else
                                if ((s == "/") && (y != 0))
                                {
                                    z = x / y;
                                    Console.WriteLine(z);
                                }
                                else {Console.WriteLine("Ввод некорректен");}
                

                    Console.ReadLine();
                    
                   // catch (System.OverflowException e)
                  //  {
                  //      Console.WriteLine("Слишком большое число" + e.ToString());
                    //}
                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                    Console.ReadLine();
                }
            
            
        }
    }
}
