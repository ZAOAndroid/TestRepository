using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Realization
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
                    Console.WriteLine("Введите для выбора варианта события:" + "\n" + "1 - новая крточка" + "\n" + "2 - новый контакт" + "\n" + "3 - удалить контакты" + "\n" + "4 - завершить" + "\n" + "5 - отобразить список контактов" + "\n" + "6 - сравнить две карточки по id проекта" + "\n" + "7 - поиск одинаковых контактов" + "\n" + "8 - клонировать карточку" + "\n" + "9 - записать список контактов в файл" + "\n" + "10 - считать и вывести на консоль список контактов из файла" + "\n" + "11 - создать xml-файл");
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
                        case "6":
                            Compare();
                            break;
                        case "7":
                            TheSame();
                            break;
                        case "8":
                            cards.Add(Clonning());
                            break;
                        case "9":
                            File();
                            break;
                        case "10":
                            writeFile();
                            break;
                        case "11":
                            xx();
                            break;
                        default:
                            Console.WriteLine("Try again"+"\n");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Попробуй ещё раз", e.Message);
                }
            }
        }

        //добавление карточки
        private static Card AddCard()
        {
            Card card = new Card();
            Console.WriteLine("Введите имя:");

            try
            {
                card.Name = Console.ReadLine();
                if (card.Name=="")
                throw new ArgumentNullException();

                Console.WriteLine("Введите синкод:");
                card.SynCode = Convert.ToInt64(Console.ReadLine());
                if ((card.SynCode < 0)|(card.SynCode == 0)|(Convert.ToString(card.SynCode)==""))
                throw new Exception ("Ошибка: ");

                Console.WriteLine("Введите идентификатор проекта:");
                card.ProjectId = Convert.ToInt32(Console.ReadLine());
               // throw new Exception("Ошибка: ");

                if (cards.Count > 0)
                {
                    card.Id = cards.Max(c => c.Id) + 1;
                }
                else
                {
                    card.Id = 1;
                }
                Console.WriteLine("Карточка с Id {0} создан", card.Id);
                Console.WriteLine();
            }
            
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message); 
            }
            catch (Exception e)
            {
                 Console.WriteLine(e.Message + " Некорректное значение"); 
            }
            return card;
            }

        //создание нового контакта
        private static void NewContact()
        {
            Console.WriteLine("Введите id");
            int id = Convert.ToInt32(Console.ReadLine());
            bool Added = false;
            try
            {
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
                                //   number.Code = Console.ReadLine();
                                number.parametr = Console.ReadLine();
                                Console.WriteLine("Введите номер");
                                number.contact = Console.ReadLine();
                                cd.AddContact(number);
                                Console.WriteLine("Контакт создан:)");
                                Console.WriteLine();
                                break;
                            case "2":
                                MailContact mail = new MailContact();
                                Console.WriteLine("Введите email");
                                mail.contact = Console.ReadLine();
                                Console.WriteLine("Введите alias");
                                //    mail.Alias = Console.ReadLine();
                                mail.parametr = Console.ReadLine();
                                cd.AddContact(mail);
                                Console.WriteLine("Контакт создан:)");
                                Console.WriteLine();
                                break;
                            default:
                                Console.WriteLine("Try again" + "\n");
                                break;
                        }
                        break;
                    }
                    if (Added)
                    {
                        Console.WriteLine("Контакт с Id {0} не был найден" + "\n", id);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " Некорректное значение");
            }
        }

        //запись в файл       
        public static void File()
        {
            string path = "D:\\contaxt.txt.txt";
            Console.WriteLine("Введите id карточки");
            int id = Convert.ToInt32(Console.ReadLine());
            System.IO.File.WriteAllLines(path, cards[id-1].readContact(), Encoding.UTF8);
            Console.WriteLine("Файл со списком контактов создан"+"\n");
        }
        
        //считать файл и вывести на консоль
        public static void writeFile()
        {
            string path = "D:\\contaxt.txt.txt";
            string[] readText = System.IO.File.ReadAllLines(path, Encoding.UTF8);
            Console.WriteLine("Содержание файла: ");
            foreach (string s in readText)
            {
                Console.WriteLine(s);            
            }
            Console.WriteLine();
        }

        //вывод контактов одной карты
        private static void WriteContact()
        {
            Console.WriteLine("Введите id");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (var cd in cards)
            {
                if (cd.Id == id)
                {
                    Console.WriteLine("Список контактов для карточки с Id = {0}", cd.Id);
                    cd.PrContact();
                }
                else
                { Console.WriteLine("Таких нет"+"\n"); }
            }
        }

        //удаление контактов карты
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
                Console.WriteLine("Подумай еще раз", e.Message);
            }
        }

        //сравнение 2х карточек по совпадению ид проектов
        private static void Compare()
        {
            Console.WriteLine("Введите Id первой карточки");
            int id1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите Id второй карточки");
            int id2 = Convert.ToInt32(Console.ReadLine());

            if ((id1 == id2)|(cards.Count-1<id1)|(cards.Count-1<id2))
            { Console.WriteLine("Карточка сравнивается сама с собой, лиюо такой карточки нет"); }
            else
            {
                cards.Sort();
                Console.Write("Сравнение выполнено: ");
                if (cards[id1].a == 1)
                { Console.WriteLine("Id проектов данных карточек равны"); }
                else
                { Console.WriteLine("Id проектов данных карточек не равны"); }
            }
        }

        //поиск дублей контактов в карточке
        private static void TheSame()
        {
            //только вызываем сам метод сравнения и ввод ид, конечно
            //для ид, наверн, следует тожк проверку на исключение сделать
            Console.WriteLine("Введите id карточки");
            int i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ведется поиск одинковый контактов...");

            cards[i-1].TheSameContatcs();
            
            Console.WriteLine("WEllDone");
        }

        //копирование карточки
        private static Card Clonning()
        {
            Console.WriteLine("Введите id карточки");
            int i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Клонирование...");

            Card clon = new Card();
            clon = (Card)cards[i - 1].Clone();
            clon.Id = cards[cards.Count-1].Id + 1;
          //  Console.WriteLine(clon.ToString());
            Console.WriteLine("Новая карточка создана");
            return clon;
        }

        public static void xx()
        {
            Console.WriteLine("Введите id карточки");
            int i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Создание xml-файла");
            cards[i-1].XXX();
            Console.WriteLine("sdelano");
        }
    }
}
