using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexExpressions
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Вещественные числа

            Console.WriteLine("Нахождение первого вещественногочисла");

            var regExp = new Regex(@"\-?\d+(\.\d{0,})?");
            const string str = ",5.4f,21,32,4,52,6,733,8,9,0";

            var match = regExp.Match(str);

            if (match.Success)
            {
                Console.WriteLine(match.Groups[0]);
            }

            // Дата
            var regExp2 =
                        new Regex(
            "(0[1-9]|1[0-9]|2[0-9]|3[01])[ ]((Jan)|(Feb)|(Mar)|(Apr)|(May)|(Jun)|(Jul)|(Aug)|(Sep)|(Oct)|(Nov)|(Dec)){1}[ ][0-9]{4}");

            const string str2 = "15 Oct 2012 , 12.12.12, 12-12-12, 12 Dec 2015, 24 Mar 2012";

            Console.WriteLine("Возвращает все даты:");
            Console.WriteLine("Количество вхождений {0}:", regExp2.Matches(str2).Count);

            var matches = regExp2.Matches(str2);

            foreach (Match m in matches)
            {
                Console.WriteLine(m.Value);
            }

            Console.ReadLine();
        }
    }
}
