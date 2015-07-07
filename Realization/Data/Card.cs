using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Data
{
    public class Card:IComparable<Card>, ICloneable
    {
        private List<Contact> _contacts = new List<Contact>();

        public string Name { get; set; }

        public long SynCode { get; set; }

        public int Id { get; set; }

        public long ProjectId { get; set; }

        bool k = false;

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);        
            k = true;
        }

        public void DelContact()
        {
            _contacts.Clear();
            k = false;
        }

        public void PrContact()
        {
            Console.WriteLine("Имя: " + Name);
            if (k)
            {
                foreach (var ctc in _contacts)
                {
                    Console.WriteLine("Значение контакта {0}: {1}", _contacts.IndexOf(ctc)+1 , ctc.ToString());
                }
            }
            else
            { Console.WriteLine("Список контактов пуст"); }
        }
        
        //записать в строки
        public string[] readContact()
        {
            string[] lines = new string[_contacts.Count];
            for (int i =0; i<_contacts.Count;)
            {
        foreach (var ctc in _contacts)
        {
        lines[i] = ctc.ToString();
        i++;
        }
            }
            return lines;
        }

        //Сравнение по проекту
        public int a
        { get; set; }
        public int CompareTo(Card pers)
        {
            Card temp = (Card)pers;
            if (this.ProjectId == temp.ProjectId)
            { a = 1; }
            else
            { a = 0; }
            return a;
        }

        //здесь вывод для каждого не нужен, следует указывать, какие равные контакты, если случай с количеством карточек больше 2х
        // следует обрабатывать случай, где контакты в карточке мэйл и телефон и между собой вообще не сравнимы
        //добавть сравнение для тел=тел и мэйл=мэйл по 2му параметру
        //следовательно надо записывать в какую-то переменную одинаковые пары
        public void TheSameContatcs()
        {
           // _contacts.Sort();
            int countt = 0;
           
                for (int i = 0; i < _contacts.Count - 1; i++)
                {
                    foreach (var c in _contacts)
                    {
                        _contacts[i].CompareTo(c);
                        if (_contacts[i].count==1)
                        {
                            _contacts[i].dubl = true;
                            countt ++;
                        }
                        else
                        {  _contacts[i].dubl = false; }
                    }
                }
            //здесь думала выводить сам контакт и соответственно подпись, есть ли дубль, но чет не зашло
          /* foreach (var c in _contacts)
           {
               if (c.dubl)
               { Console.WriteLine("est' dybli"); }
               else
               {Console.WriteLine("Net duble'");}
           }*/

            //по факту просто есть или нет дубли
                if (countt > 0)
                { Console.WriteLine("Est' dubli"); }
                else
                { Console.WriteLine("Net dublei"); }
        }

        //копирование, Id карты он в program добавляет
        public object Clone()
        { 
            Card clone = new Card();
            clone.Name = Name;
            clone.ProjectId = ProjectId;
            clone.SynCode = SynCode;
  
            return clone;
        }

        // xml-ки
        public void XXX()
        {
            foreach (var ctc in _contacts)
            {
                ctc.toXml().Save("x.xml");
                string str = File.ReadAllText("x.xml");
                Console.WriteLine(str);
            }
        }
    }
}
