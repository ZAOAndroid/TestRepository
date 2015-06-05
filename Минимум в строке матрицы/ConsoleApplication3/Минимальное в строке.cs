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
            Console.WriteLine("Введите размер матрицы");
            Random rand = new Random();
            int n = Convert.ToInt32(Console.ReadLine());
            //создаем 3 матрицы
            int[,] M = new int[n, n];
            int[,] N = new int[n, n];
            int[,] L = new int[n, n];
            //заполняем рандомно 2 матрицы, одну выводим на конслось
            Console.WriteLine("Матрица 1:" + "\n");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    M[i, j] = rand.Next(100);
                    N[i, j] = rand.Next(100);
                    Console.Write(M[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
            //найти минимум в каждой строке 1й матрицы
            
            for (int i = 0; i < n; i++)
            {
                int min = M[i, 0];
                for (int j = 0; j < n; )
                {
                    if (M[i, j] < min)
                    {
                        min = M[i, j];
                    }
                    j++;
                }
                Console.WriteLine ("Минимальное значение в строке"+" "+i+" "+min);
                Console.WriteLine ("\n");
            }

            Console.ReadLine();

        }
    }
}
