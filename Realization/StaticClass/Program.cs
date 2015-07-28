using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClass
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] massiv = new int[] {1,2,3};
            Console.WriteLine("Введите разделяющий символ");
            string symbol = Console.ReadLine();
            Console.WriteLine( ArrayExtentions.Extantion(massiv, symbol));
            Console.ReadLine();
        }

        public static class ArrayExtentions
        {
            public static string Extantion(int[] array,string symbol)
            {


                StringBuilder result = new StringBuilder("");

                result.Append(array[0].ToString());
                for (int i = 1; i < array.Length; i++)
                {
                    result.AppendFormat("{1} {0}", array[i].ToString(), symbol);
                }
                return result.ToString();
            }
        }
       /* public static class ArrayExtentio
        {
            public static string DelayString(this int[] array)
            {
                return array.ToString();
            }
        }*/
    }
}
