using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Linq.Expressions;






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
                    Console.WriteLine("Введите для выбора варианта события:" + "\n" + "1 - новая карточка" + "\n" + "2 - новый контакт" + "\n" + "3 - удалить контакты" + "\n" + "4 - завершить" + "\n" + "5 - отобразить список контактов" + "\n" + "6 - сравнить две карточки по id проекта" + "\n" + "7 - поиск одинаковых контактов" + "\n" + "8 - клонировать карточку" + "\n" + "9 - записать список контактов в файл" + "\n" + "10 - считать и вывести на консоль список контактов из файла" + "\n" + "11 - создать xml-файл" + "\n" + "12 - сортировка" + "\n" + "13 - статусы карт");
                    k = Console.ReadLine();
                    switch (k)
                    {
                        case "1":
                            cards.Add(AddCard());
                            break;
                        case "2":
                            NewContact();
                            break;
                        case "3":
                            Del();
                            break;
                        case "4":
                            break;
                        case "5":
                            WriteContact();
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
                            ToXML();
                            break;
                        case "12":
                            LINQ();
                            break;
                        case "13":
                            toEnum();
                            break;
                        case "14":
                            TryToReadFromRepository();
                            break;
                        default:
                            Console.WriteLine("Try again" + "\n");
                            break;
                    }
                    Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Попробуй ещё раз", e.Message);
                }
            }
        }

        //public static 

        //добавление карточки
        private static Card AddCard()
        {
            Card card = new Card();

            Console.WriteLine("Введите имя:");

            try
            {
                card.Name = Console.ReadLine();
                if (card.Name == "")
                    throw new ArgumentNullException();

                Console.WriteLine("Введите синкод:");
                card.SynCode = Convert.ToInt64(Console.ReadLine());
                if ((card.SynCode < 0) | (card.SynCode == 0) | (Convert.ToString(card.SynCode) == ""))
                    throw new Exception("Ошибка: ");

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
                        cd.cardStatus = Data.CardStatus.Verified;  //Card.CardStatus.Verified;
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
                                if ((number.contact == "") | (number.parametr == ""))
                                    throw new ArgumentNullException();
                                Console.WriteLine("Контакт создан:)");
                                cd.k = true;
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
                                if ((mail.contact == "") | (mail.parametr == ""))
                                    throw new ArgumentNullException();
                                Console.WriteLine("Контакт создан:)");
                                cd.k = true;
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
            cards[id - 1].cardStatus = Data.CardStatus.Assigned; //Card.CardStatus.Assigned;
            System.IO.File.WriteAllLines(path, cards[id - 1].readContact(), Encoding.UTF8);
            Console.WriteLine("Файл со списком контактов создан" + "\n");
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

            Console.WriteLine("Имя: " + cards[id - 1].Name);
            Console.WriteLine("Список контактов для карточки с Id = {0}", cards[id - 1].Id);

            string[] lines = cards[id - 1].readContact();
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine("Значение контакта: {0}", lines[i]);
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
                        cd.k = false;
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

            if ((id1 == id2) | (id1 > cards.Count) | (id2 > cards.Count))
            { Console.WriteLine("Карточка сравнивается сама с собой, лиюо такой карточки нет"); }
            else
            {
                cards.Sort();
                Console.Write("Сравнение выполнено: ");
                if (cards[id1 - 1].CompareTo(cards[id2 - 1]) == 0)
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

            if (cards[i - 1].TheSameContatcs() > 1)
            { Console.WriteLine("Est' dubli"); }
            else
            { Console.WriteLine("Net dublei"); }
        }

        //копирование карточки
        private static Card Clonning()
        {
            Console.WriteLine("Введите id карточки");
            int i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Клонирование...");

            Card card1 = (Card)cards[i - 1].Clone();

            cards[i - 1].cardStatus = Data.CardStatus.Archived; //Card.CardStatus.Archived;

            cards.Add(card1);
            Console.WriteLine(card1.ToString());
            Console.WriteLine(cards[i].ToString());
            Console.WriteLine("Новая карточка создана");

            return card1;
        }

        // Работа с xml
        public static void ToXMLContacts()
        {
            Console.WriteLine("Введите id карточки");
            int i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Создание xml-файла");

            cards[i-1].XXX();
            Console.WriteLine(System.IO.File.ReadAllText("xmlka"));
        }
        public static void ToXMLCard()
        {
            Console.WriteLine("Введите id карточки");
            int i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Создание xml-файла");
            cards[i - 1].toXmlCard().Save("x.xml");
            string str = System.IO.File.ReadAllText("x.xml");
            Console.WriteLine(str);
        }

        public static void ToXMLStatus()
        {
            if (System.IO.File.Exists("xStatus.xml"))
            {
                System.IO.File.Delete("xStatus.xml");
            }

            foreach (var c in cards)
            {
                System.IO.File.AppendAllText("xStatus.xml", c.toXMLStatus().ToString() + "\n");
            }
            Console.WriteLine(System.IO.File.ReadAllText("xStatus.xml"));
        }

        //Для выбора создания xml-файла
        public static void ToXML()
        {
            Console.WriteLine("Для создания xml-файла карточки - 1, для списка контакот карточки - 2, для статуса карты - 3");
            switch (Console.ReadLine())
            {
                case "1":
                    ToXMLCard();
                    break;
                case "2":
                    ToXMLContacts();
                    break;
                case "3":
                    ToXMLStatus();
                    break;
                default:
                    Console.WriteLine("Something wrong");
                    break;
            }
        }

        //Для поиска контактов
        public static void LINQ()
        {
            Console.WriteLine("Введите id карты, в которой будет вестись поиск");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("1 - сортировка контактов по номерам телефонов");
            Console.WriteLine("2 - сортировка контактов по Email");
            int a = Convert.ToInt32( Console.ReadLine());
            if (a == 1)
            {
                string[] lines = cards[id - 1].toLINQNumberContact();
                for (int i = 0; i < lines.Length; i++)
                { Console.WriteLine(lines[i]); }
            }
            else
            {
                if (a == 2)
                {
                    string[] lines = cards[id - 1].toLINQMailContact();
                    for (int i = 0; i < lines.Length; i++)
                    { Console.WriteLine(lines[i]); }
                }
                else
                { Console.WriteLine("В своем приложении будешь левые символы вводить"); }
            }
        }

        //for enum
        public static void toEnum()
        {
            for (int i = 0; i < cards.Count ; i++)
            {
            Console.WriteLine("card {0}: status {1}",cards[i].Id, cards[i].cardStatus);
            }
        }

        // чтобы проверить
        public static void TryToReadFromRepository()
        {

            var repForCards = new XmlRepository<Data.IXmlSerializable>();

            repForCards.Save(cards[0]);
            Console.WriteLine("save");
            repForCards.Load(cards[1],cards[0]);
            Console.WriteLine("load");
            Console.WriteLine(cards[1].Name.ToString());

        }
    }
}
