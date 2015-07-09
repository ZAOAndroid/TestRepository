using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace Data
{
    public class Card : IComparable<Card>, ICloneable
    {
        private List<Contact> _contacts = new List<Contact>();

        public string Name { get; set; }

        public long SynCode { get; set; }

        public int Id { get; set; }

        public long ProjectId { get; set; }

        public bool k { get; set; }

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
        }

        public void DelContact()
        {
            _contacts.Clear();
        }

        //записать в строки
        public string[] readContact()
        {
            string[] lines = new string[_contacts.Count];
            for (int i = 0; i < _contacts.Count; )
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
        public int CompareTo(Card pers)
        {
            Card temp = (Card)pers;
            return this.ProjectId.CompareTo(temp.ProjectId);
        }

        //здесь вывод для каждого не нужен, следует указывать, какие равные контакты, если случай с количеством карточек больше 2х
        // следует обрабатывать случай, где контакты в карточке мэйл и телефон и между собой вообще не сравнимы
        //добавть сравнение для тел=тел и мэйл=мэйл по 2му параметру
        //следовательно надо записывать в какую-то переменную одинаковые пары
        public int TheSameContatcs()
        {
            _contacts.Sort();
            int countt = 0;

            for (int i = 0; i < _contacts.Count - 1; i++)
            {
                foreach (var c in _contacts)
                {

                    if (_contacts[i].CompareTo(c) == 0)
                    {
                        countt++;
                    }
                }
            }
            return countt;
            //по факту просто есть или нет дубли
        }

        //копирование, Id карты он в program добавляет
        public object Clone()
        {

            Card card = (Card)this.MemberwiseClone();
            card.Id = this.Id + 1;
            card.Name = this.Name;
            card.ProjectId = this.ProjectId;
            card.SynCode = this.SynCode;
            card._contacts = this._contacts;

            return card;

        }

        // xml-ки
        public void XXX()
        {
            foreach (var ctc in _contacts)
            {
                ctc.toXml().Save("x.xml");
            }
        }
        public XElement toXml()
        {
            XElement x = new XElement("Name", new XAttribute("Id", Id), new XAttribute("Name", Name), new XAttribute("IdOfProject", ProjectId), new XAttribute("SysCode", SynCode));
            return x;
        }
    }
}
