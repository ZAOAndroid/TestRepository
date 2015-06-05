using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            long id = 1267165676175383;
            string s = Convert.ToString(id,2);
            string st = s.PadLeft(64, '0');
            Console.WriteLine("Дан идентификатор" + " " + id);
            Console.WriteLine("По нему получаем:");
            
            Console.WriteLine("id Типа"+" "+Convert.ToInt32(st.Remove(2), 2));
            Console.WriteLine("id Города" + " " + Convert.ToInt32(st.Remove(0,2).Remove(15) , 2));
            Console.WriteLine("id Таблицы" + " " + Convert.ToInt32(st.Remove(0,16).Remove(15), 2));
            Console.WriteLine("id Объекта" + " " + Convert.ToInt64(st.Remove(0, 31), 2));
            Console.ReadLine();
            
        }
    }
}
