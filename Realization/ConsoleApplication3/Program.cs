using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryToExtension
{
    using Extensions;
    class Program
    {
        static void Main(string[] args)
        {
            int[] massiv = new int[] { 1, 2, 3 };
            Console.WriteLine("Введите разделяющий символ");
            string symbol = Console.ReadLine();
            Console.WriteLine(massiv.ExtensionMethod(symbol));
            Console.ReadLine();
        }
    }
}

namespace Extensions
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public static class ArrayExtension
    {
        public static string ExtensionMethod(this int[] array, string symbol)
        {
            string[] lines = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                lines[i] = array[i].ToString();
            }
            string result = string.Join(symbol, lines);
            return result;
        }
    }
}
