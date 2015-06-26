using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    using Data;

    class Program
    {
        public static List<Card> cards = new List<Card>();
        //консолюшка вся
        static void Main(string[] args)
        {
            string k = "";
            //варианты событий
            while (k != "4")
            {
                try
                {
                    Console.WriteLine("Введите для выбора варианта события:" + "\n" + "1 - новая крточка" + "\n" + "2 - новый контакт" + "\n" + "3 - удалить контакты" +"\n" + "4 - завершить" + "\n" + "5 - отобразить список контактов");
                    k = Console.ReadLine();
                    switch (k)
                    {
                        case "1":
                            cards.Add(AddCard());
                            break;
                        case "2":
                            NewContact();
                            break;
                        case "5":
                            WriteContact();
                            break;
                        case "3":
                            Del();
                            break;
                        case "4":
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Попробуй ещё раз", e.Message);
                }
            }
        }
        private static Card AddCard()
        {
            Card card = new Card();
            Console.WriteLine("Введите имя:");
            card.Name = Console.ReadLine();
            Console.WriteLine("Введите синкод:");
            card.SynCode = Convert.ToInt64(Console.ReadLine());
            if (cards.Count > 0)
            {
                card.Id = cards.Max(c => c.Id) + 1;
            }
            else
            {
                card.Id = 1;
            }
            Console.WriteLine("Карточка с Id {0} создан", card.Id);
            return card;
        }
        private static void NewContact()
        {
            Console.WriteLine("Введите id");
            int id = Convert.ToInt32(Console.ReadLine());
            bool Added = false;
            foreach (var cd in cards)
            {
                if (cd.Id == id)
                {
                    Added = true;
                    Console.WriteLine("Введите для создания контакта с телефоном - 1, с почтой - 2");
                    string vibor = Console.ReadLine();
                    switch (vibor)
                    {
                        case "1":
                            NumbContact number = new NumbContact();
                            Console.WriteLine("Введите код города");
                            number.Code = Console.ReadLine();
                            Console.WriteLine("Введите номер");
                            number.contact = Console.ReadLine();
                            cd.AddContact(number);
                            Console.WriteLine("Контакт создан:)");
                            break;
                        case "2":
                            MailContact mail = new MailContact();
                            Console.WriteLine("Введите email");
                            mail.contact = Console.ReadLine();
                            Console.WriteLine("Введите alias");
                            mail.Alias = Console.ReadLine();
                            cd.AddContact(mail);
                            Console.WriteLine("Контакт создан:)");
                            break;
                        default:
                            Console.WriteLine("Try again");
                            break;
                    }
                    break;
                }
                if (!Added)
                {
                    Console.WriteLine("Контакт с Id {0} не был найден", id);
                }
            }
        }
        private static void WriteContact()
        {
            Console.WriteLine("Введите id");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (var cd in cards)
            {
                if (cd.Id == id)
                {
                    Console.WriteLine("Список контактов для карточки с Id = {0}",cd.Id);
                    cd.PrContact();
                }
                else
                {Console.WriteLine("Таких нет");}
            }
        }
        private static void Del()
        {
            try
            {
                Console.WriteLine("Введите id");
                int id = Convert.ToInt32(Console.ReadLine());
                foreach (var cd in cards)
                {
                    if (cd.Id == id)
                    {
                        cd.DelContact();
                    }
                }
                Console.WriteLine("Контакты удалены");
            }
            catch (NotImplementedException e)
            {
                Console.WriteLine("Подумай еще раз",e.Message);
            }
        }
    }
}

//внутри оствила 2й проект
namespace Data
{
    public class Card
    {
        private List<Contact> _contacts = new List<Contact>();

        public string Name { get; set; }

        public long SynCode { get; set; }

        public int Id { get; set; }

        int k = 0;

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
            k = 1;
        }
        public void DelContact()
        {
                _contacts.Clear();
                k = 0;
        }
        public void PrContact()
        {
            Console.WriteLine("Имя: " + Name);
            if (k != 0)
            {
                k = 1;
                foreach (var ctc in _contacts)
                {
                    Console.WriteLine("Значение контакта {0}: {1}", k, ctc.ToString());
                    k++;
                }
            }
            else
            { Console.WriteLine("Список контактов пуст"); }
        }
    }
    public class Contact
    {
        //поле, которое наследуют
        public string contact { get; set; }
    }
    public class NumbContact : Contact
    {
        public string Code { get; set; }
        public override string ToString()
        {
            return Code+" " + contact;
        }
    }
    public class MailContact : Contact
    {
        public string Alias { get; set; }
        public override string ToString()
        {
            return contact + "_" + Alias;
        }
    }
}




