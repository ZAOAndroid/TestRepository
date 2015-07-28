using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            //считали строку
            Console.WriteLine("Введите текст");
            string str = Console.ReadLine();
           
            //делим через пробел и считаем
            string[] st = str.Trim().Split(' ');
            //Два счетчика, чтобы учитывал пустое слово
            int count = 0;
            int count1 = 0;
              foreach (string s in st)
            {
                count++;
                count1++;
                
            }
            //если есть описка лишних пробелов подряд, то вычитаем лишнее слово
            for (int i = 1; i < (str.Length-1); i++)
            {
                char ch = str[i];
                char ch1 = str[i+1];
                char pr = Convert.ToChar(" ");
                if ((ch == pr) && (ch1 == pr))
                {
                    count--;
                }
            }
            //Количество каждого слова
            //Удалим запятые в словах
            for (int k = 0; k < count; k++)
            {
                st[k] = st[k].Trim(Convert.ToChar(","));
            }
            //потом считаем
            int[] n = new int[count1];
            for (int j = 0; j < (count1); j++)
            {
                for (int i = 0; i < (count1); i++)
                {
                    if (st[j] == st[i])
                    {
                        n[j]++;
                    }
                }
            }
            //Выводим слова и их количество, учитывая, что пустые слова не нужны
            Console.WriteLine(st[0] + " " + n[0]);
            for (int j = 1; j < (count); j++)
            {
                if ((n[j] == 1)&&(st[j]!=""))
                { Console.WriteLine(st[j] + " " + n[j]); }
            }
            Console.WriteLine("Количество слов"+" "+count+" ");
            Console.ReadLine();
        }

    }
}
