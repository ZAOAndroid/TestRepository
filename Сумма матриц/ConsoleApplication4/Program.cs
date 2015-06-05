using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            // размер матрицы
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
            //выводим 2ю матрицу на консоль
            Console.WriteLine("Матрица 2:" + "\n");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {

                    Console.Write(N[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
            //складываем в 3й массив и выводим 
            Console.WriteLine("Сумма матриц:" + "\n");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    L[i, j] = M[i, j] + N[i, j];
                    Console.Write(L[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
            Console.ReadLine();
        }
    }
}
